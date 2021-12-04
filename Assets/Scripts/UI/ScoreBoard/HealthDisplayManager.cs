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
    GameObject m_beyBlade;
    private bool m_shouldAnimateHealthBar;
    private float m_targetFill = 1f;

    public string Tag { get => m_tag; }

    private void OnEnable()
    {
        BeyBladeHealthManager.OnHealthChanged += UpdateHealth;
    }

    private void UpdateHealth(float _currentHealth, float _maxHealth, GameObject _beyBlade)
    {
        if (m_beyBlade == null) return;
        if(m_beyBlade == _beyBlade)
        {
            m_targetFill = _currentHealth/_maxHealth;
            if(Mathf.Abs(m_targetFill - healthSprite.fillAmount) <= healthBarAnimationThreshold)
            {
                healthSprite.fillAmount = m_targetFill;
                return;
            }
            m_shouldAnimateHealthBar = true;
        }
    }
    private void Update()
    {
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
    private void OnDisable()
    {
        
        BeyBladeHealthManager.OnHealthChanged -= UpdateHealth;
    }

    public void SetBeyBlade(GameObject _beyBladeObject)
    {
        m_beyBlade = _beyBladeObject;
    }
}
