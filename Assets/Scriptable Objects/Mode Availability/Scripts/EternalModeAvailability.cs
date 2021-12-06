using UnityEngine;

[CreateAssetMenu(fileName = "New Eternal Mode Availabitlity", menuName = "Mode Availability/Eternal Mode Availabitlity")]

public class EternalModeAvailability : ModeAvailability
{
    private void Awake()
    {
        m_isModeAvailable = true;
    }
}
