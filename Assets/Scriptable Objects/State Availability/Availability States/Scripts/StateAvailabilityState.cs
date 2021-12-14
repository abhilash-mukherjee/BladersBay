
using UnityEngine;
[CreateAssetMenu(fileName ="new Availability Status", menuName = "State Availability / Availability Status")]
public class StateAvailabilityStatus : MonoBehaviour
{
    [SerializeField]
    private BeyBladeStateAvailabilityEnum stateAvailabilityEnum;
    [SerializeField]
    private BeyBladeState state;
    [SerializeField]
    private float thresholdAvailabilityIndex;
    private float m_currentAvailabilityIndex;

    public float ThresholdAvailabilityIndex { get => thresholdAvailabilityIndex;  }
    public float CurrentAvailabilityIndex { get => m_currentAvailabilityIndex;  }

    public void UpdateStateAvailability(StateAvailabilityController _stateAvailabilityController)
    { 
    }
}
