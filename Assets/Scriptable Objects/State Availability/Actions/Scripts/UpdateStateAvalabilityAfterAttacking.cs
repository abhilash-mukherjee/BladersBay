﻿
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Update State Avalability After Attacking", menuName = "State Availability / Action / Update State Availability After Collision")]
public class UpdateStateAvalabilityAfterAttacking : StateAvailabilityAction
{
    private List<ColisionData> m_collisionDataList = new List<ColisionData>();
    [SerializeField]
    private BeyBladeStateAvailabilityEnum UnAvailable;

    private void OnEnable()
    {
        BeyBladeHealthManager.OnBeyBladeAttacked += OnAttacked;
    }
    private void OnDisable()
    {
        BeyBladeHealthManager.OnBeyBladeAttacked -= OnAttacked;
        m_collisionDataList.Clear();
        
    }
    public override void Act(StateController _stateController, State _state)
    {
        var _dataFromList = m_collisionDataList.Find(p => p.stateController == _stateController);
        if (_state.AvailabilityStatus.Name != UnAvailable)
            return;
        if(_dataFromList != null)
        {
            foreach(var _dictState in _stateController.StateDict)
            {
                _dictState.Value.Data.CurrentAvailabilityIndex += _dataFromList.CollisionIndex * _dictState.Value.Data.StateReplenishmentRate;
            }
            m_collisionDataList.Remove(_dataFromList);
        }
    }

    public void OnAttacked(StateController _stateController, float _collisionIndex)
    {
        var _Data = new ColisionData(_stateController, _stateController.CurrentState.Name, _collisionIndex);
        var _dataFromList = m_collisionDataList.Find(p => p.stateController == _Data.stateController);
        if (_dataFromList == null)
        {
            m_collisionDataList.Add(_Data);
        }
    }

    private class ColisionData
    {
        public StateController stateController;
        public BeyBladeStateName stateName;
        public float CollisionIndex;
        public ColisionData(StateController _stateController, BeyBladeStateName _stateName, float _CollisionIndex)
        {
            stateController = _stateController;
            stateName = _stateName;
            CollisionIndex = _CollisionIndex;
        }
    }
}
