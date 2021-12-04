using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStateMachine : MonoBehaviour
{
    protected CharacterState state;
    public void TakeDamage(float _dmg)
    {
        Debug.Log($"TakeDamage of {gameObject} called");
        state.TakeDamage(_dmg);
    }
    public void DoDamage( GameObject _enemyObject)
    {
        Debug.Log($"DoDamge of {gameObject} called");
        Debug.Log($"_enemyObject = {_enemyObject}");
        state.DoDamage( _enemyObject.GetComponent<CharacterStateMachine>());
    }

    public float CalculateMovementMultiplier()
    {
        return state.CalculateMovementMultiplier();
    }

    public float CalculateStaminaLoss()
    {
        return state.CalculateStaminaLoss();
    }
    public void ChangeState(CharacterState _newState)
    {
        if(state != null)
            Destroy(state);
        this.state = _newState;
        state.Enter(GetComponent<BeyBladeParameters>().SafeDistance);
    }
    public virtual Vector3 Move(float _safeDistance)
    {
        return Vector3.zero;
    }
    
}
