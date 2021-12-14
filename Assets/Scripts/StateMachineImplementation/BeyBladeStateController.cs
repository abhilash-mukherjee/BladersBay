using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeyBladeStateController : MonoBehaviour
{
    public delegate void ModeChangeHandler(BeyBladeStateName _currentModeName, GameObject _gameObject);
    public static event ModeChangeHandler OnBeyBladeStateChanged;
    [SerializeField]
    private BeyBladeState startingState;
    [SerializeField]
    private BeyBladeValues beyBladeValues;
    [SerializeField]
    private List<StateEffectContainer> modeEffects = new List<StateEffectContainer>();
    private BeyBladeStateName m_currentStateRequest;
    private BeyBladeState m_currentState;

    public BeyBladeStateName CurrentStateRequest { get => m_currentStateRequest; }
    public List<StateEffectContainer> ModeEffects { get => modeEffects; }
    public BeyBladeState CurrentState
    {
        get
        {
            return m_currentState;
        }
    }

   
    public GameObject StateControllerObject { get => this.gameObject; }

    private void Awake()
    {
        m_currentState = startingState;
        OnBeyBladeStateChanged?.Invoke(m_currentState.StateName, gameObject);
    }
    private void Update()
    {
        if (m_currentState != null)
        {
            m_currentState.UpdateState(this);
            //Debug.Log(m_currentState);
        }
    }
    public void TransitionToState(BeyBladeState _state)
    {
        if (false)
        {
            Debug.Log("State unavailable");
            return;
        }
        if (m_currentState != _state)
        {
            // Debug.Log("Transitioned to " + _state + " from " + m_currentState);
            m_currentState = _state;
            OnBeyBladeStateChanged?.Invoke(m_currentState.StateName, gameObject);
        }
        else
        {
            //Debug.Log($"Already in {m_currentState}");
        }
    }
    private void OnDrawGizmos()
    {
        if (m_currentState != null)
            Gizmos.color = m_currentState.SceneGizmoColor;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
    public void ChangeCurrentStateRequest(BeyBladeStateName _newStateRequest)
    {
        m_currentStateRequest = _newStateRequest;
    }
}
[System.Serializable]
public class StateEffectContainer
{
    public GameObject effectPrefab;
    public BeyBladeStateName stateName;
}
