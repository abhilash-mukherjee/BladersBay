using UnityEngine;
[CreateAssetMenu(fileName ="New SwipeResponse Decission", menuName = "State Machine / Decission / State Change Response Decission")]
public class StateChangeResponse_BeyBladeDecission : BeyBladeDecission
{
    [SerializeField]
    BeyBladeStateName modeRequest;
    public override bool Decide(BeyBladeStateController _stateCntroller)
    {
        if (_stateCntroller.CurrentStateRequest == modeRequest) return true;
        else return false;
        
    }
}  