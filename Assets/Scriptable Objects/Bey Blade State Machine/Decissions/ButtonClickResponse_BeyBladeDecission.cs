using UnityEngine;

[CreateAssetMenu(fileName = "New ButtonResponse Decission", menuName = "State Machine / Decission / Button Response Decission")]
public class ButtonClickResponse_BeyBladeDecission : BeyBladeDecission
{
    [SerializeField]
    private KeyCode triggerKey;
    public override bool Decide(BeyBladeStateController _stateCntroller)
    {
        if (Input.GetKeyDown(triggerKey))
            return true;
        else return false;
    }
}