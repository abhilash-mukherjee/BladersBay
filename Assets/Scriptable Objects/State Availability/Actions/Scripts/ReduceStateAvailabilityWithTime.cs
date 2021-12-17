
using UnityEngine;

[CreateAssetMenu(fileName = "new Reduce State Availability With Time", menuName = "State Availability / Action / Reduce State Availability With Time")]
public class ReduceStateAvailabilityWithTime : StateAvailabilityAction
{
    public override void Act(StateController _stateController, State _currentState)
    {
        foreach (var _dictState in _stateController.StateDict)
        {
            _dictState.Value.Data.CurrentAvailabilityIndex -= _dictState.Value.Data.StateDepletionRate;
        }
    }
}