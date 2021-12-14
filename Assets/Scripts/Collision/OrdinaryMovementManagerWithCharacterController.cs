
using UnityEngine;

public class OrdinaryMovementManagerWithCharacterController : MovementManagerWithCharacterController
{
    [SerializeField]
    private BeyBladeValues beyBladeValues;
    protected override void Awake()
    {
        base.Awake();
        m_type = this.GetType();
    }
    protected override Vector3 CalculateMovement()
    {
         return beyBladeValues.Speed * m_inputController.MoveDirection;
    }
}
