using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransitionManager_SD : MonoBehaviour
{
    [SerializeField]
    private List<TransitionCard_SD> cards;
    public GameObject PerksParent;
    
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
        Debug.Log("Inside Animation start  function");

        int len = cards.Count;
        foreach(TransitionCard_SD card in cards){
            card.TimeElapsed = 0f;
        }
        var _card = cards.Find(p => p.gameObject == gameObj);
        if(_card != null)
        {
            var _index = cards.IndexOf(_card);
            cards.Remove(_card);
            Destroy(_card.gameObject);
            AnimateTransition(_index);
        }
        else
        {
            Debug.Log($"{gameObj} does not have any card corresponding to it");
        }
    }

    void AnimateTransition(int index)
    {        
        for (int i = index ; i < cards.Count; i++)
        {
            Vector3 start = cards[i].gameObject.transform.localPosition;
            Vector3 end = cards[i].gameObject.transform.localPosition - new Vector3(diff, 0, 0);
            cards[i].TimeElapsed = 0f;
            StartCoroutine(AnimateCard(start, end, cards[i].gameObject));
        }

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
            StartCoroutine(AnimateParent(PerksParent.transform.localPosition, PerksParent.transform.localPosition - new Vector3(diff, 0, 0), PerksParent));
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
            StartCoroutine(AnimateParent(PerksParent.transform.localPosition, PerksParent.transform.localPosition + new Vector3(diff, 0, 0), PerksParent));
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
