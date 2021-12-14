
using UnityEngine;

[CreateAssetMenu(fileName = "New Compare state availability index", menuName = "State Availability / Decissions / Compare State Availability Index")]
public class CompareStateAvailabilityIndex_StateAvailabilityDecission : StateAvailabilityDecission
{
    public override bool Decide(StateAvailabilityController _stateAvailabilityController)
    {
        if (_stateAvailabilityController.CurrentStateAvailability.CurrentAvailabilityIndex >= _stateAvailabilityController.CurrentStateAvailability.ThresholdAvailabilityIndex)
        {
            return true;
        }
        else return false;
    }
}
