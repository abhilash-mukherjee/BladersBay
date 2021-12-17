using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    private Light light;
    [SerializeField]
    private float normalIntensity, specialModeIntensity;
    [SerializeField]
    private BeyBladeStateName balanceStateName;
    [SerializeField]
    private List<StateController> stateControllers = new List<StateController>();
    private void Update()
    {
        foreach(var c in stateControllers)
        {
            if (c.CurrentState.Name != balanceStateName)
            {
                light.intensity = specialModeIntensity;
                break;
            }
            else light.intensity = normalIntensity;
        }
    }
}
