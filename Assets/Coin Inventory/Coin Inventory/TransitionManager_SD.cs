using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransitionManager_SD : MonoBehaviour
{
    // Start is called before the first frame update
    public List<TransitionCard_SD> cards;
    public GameObject Perks;
    
    [SerializeField]
    float diff = 287.7399f;
    float index;
    float count = 0f;
    private void OnEnable()
    {
        PerkButtonClickManager.OnPerkButtonClicked += GetIndexAndStartAnimation;
    }
    private void OnDisable()
    {
        PerkButtonClickManager.OnPerkButtonClicked -= GetIndexAndStartAnimation;
        
    }
    public void GetIndexAndStartAnimation(GameObject gameObj)
    {
        int len = cards.Count;
        foreach(TransitionCard_SD card in cards){
            card.TimeElapsed = 0f;
        }
        for (int i = 0; i < len; i++)
        {
            if (cards[i] && cards[i].gameObject == gameObj)
            {
                AnimateTransition(i, cards[i].gameObject);
            }
        }
    }

    void AnimateTransition(int index, GameObject obj)
    {
        // obj.GetComponent<TransitionCard_SD>().DisableManager();
        obj.SetActive(false);

        for (int i = index + 1; i < cards.Count; i++)
        {
            Vector3 start = cards[i].gameObject.transform.localPosition;
            Vector3 end = cards[i].gameObject.transform.localPosition - new Vector3(diff, 0, 0);
            cards[i].TimeElapsed = 0f;
            StartCoroutine(AnimateCard(start, end, cards[i].gameObject));
        }

        //Destroy(obj);
    }


    IEnumerator AnimateCard(Vector3 start, Vector3 end, GameObject obj)
    {
        obj.GetComponent<TransitionCard_SD>().TimeElapsed = 0f;
        while (start != end)
        {
            obj.transform.localPosition = Vector3.Lerp(start, end, obj.GetComponent<TransitionCard_SD>().TimeElapsed);
            obj.GetComponent<TransitionCard_SD>().TimeElapsed += Time.deltaTime;
            start = obj.transform.localPosition;
            yield return null;
        }

        obj.GetComponent<TransitionCard_SD>().TimeElapsed = 0f;
    }

    IEnumerator AnimateParent(Vector3 start, Vector3 end, GameObject obj)
    {
        float timeElapsed = 0f;
        while (start != end)
        {
            obj.transform.localPosition = Vector3.Lerp(start, end,timeElapsed);
            timeElapsed += Time.deltaTime;
            start = obj.transform.localPosition;
            yield return null;
        }

        timeElapsed = 0f;
    }

    public void ChangeRightClick()
    {
        if (count >= cards.Count - 5)
        {
            count = cards.Count-4;
        }
        else
        {
            count++;
        }
        Debug.Log(count);
        if (count < cards.Count - 4)
            StartCoroutine(AnimateParent(Perks.transform.localPosition, Perks.transform.localPosition - new Vector3(diff, 0, 0), Perks));
    }
    public void ChangeLeftClick()
    {
        if(count > 0){
            count --;
        }
        else{
            count = 0;
        }
        Debug.Log(count);
        if (count > 0)
            StartCoroutine(AnimateParent(Perks.transform.localPosition, Perks.transform.localPosition + new Vector3(diff, 0, 0), Perks));
    }

    public void AddToCardList(TransitionCard_SD _card)
    {
        if (cards.Contains(_card))
            return;
        Debug.Log("Initial pos = " + _card.gameObject.transform.localPosition);
        _card.gameObject.transform.localPosition = cards[cards.Count - 1].transform.localPosition + new Vector3(diff, 0f, 0f);
        Debug.Log("final pos = " + _card.gameObject.transform.localPosition);
        cards.Add(_card);
    }
}
