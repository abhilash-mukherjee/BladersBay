using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayManager : MonoBehaviour
{
    [SerializeField]
    private Image healthSprite;
    [SerializeField]
    float lerpSpeed = 10f;
    [SerializeField]
    private float healthBarAnimationThreshold;
    [SerializeField]
    private string m_tag;
    [SerializeField]
    FloatReference maxHealth;
    [SerializeField]
    FloatVariable currentHealth;
    GameObject m_beyBlade;
    private bool m_shouldAnimateHealthBar;
    private float m_targetFill = 1f;

    public string Tag { get => m_tag; }


    private void UpdateHealth()
    {
        m_targetFill = currentHealth.Value / maxHealth.Value;
        if (Mathf.Abs(m_targetFill - healthSprite.fillAmount) <= healthBarAnimationThreshold)
        {
            healthSprite.fillAmount = m_targetFill;
            return;
        }
        m_shouldAnimateHealthBar = true;
    }
    private void Update()
    {
        UpdateHealth();
        if(m_shouldAnimateHealthBar)
        {
            if (healthSprite.fillAmount <= m_targetFill)
            {
                m_shouldAnimateHealthBar = false;
                return;
            }
            healthSprite.fillAmount -= Time.deltaTime * lerpSpeed;
        }
    }
   
    public void SetBeyBlade(GameObject _beyBladeObject)
    {
        m_beyBlade = _beyBladeObject;
    }
}
