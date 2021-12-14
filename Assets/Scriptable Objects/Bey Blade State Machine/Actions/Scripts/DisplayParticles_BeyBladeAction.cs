using UnityEngine;
[CreateAssetMenu(fileName ="New Display Particle Action", menuName = "State Machine / Action / Display Particles")]
public class DisplayParticles_BeyBladeAction : BeyBladeAction
{
    public override void Act(BeyBladeStateController _stateController)
    {
        foreach(var modeEffect in _stateController.ModeEffects)
        {
            if (modeEffect.stateName == _stateController.CurrentState.StateName)
            {
                modeEffect.effectPrefab.SetActive(true);
            }
            else
            {
                modeEffect.effectPrefab.SetActive(false);
            }
        }
    }
}