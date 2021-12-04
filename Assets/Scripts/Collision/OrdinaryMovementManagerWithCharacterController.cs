
using UnityEngine;

public class OrdinaryMovementManagerWithCharacterController : MovementManagerWithCharacterController
{
    protected override void Awake()
    {
        base.Awake();
        m_type = this.GetType();
    }
    protected override Vector3 CalculateMovement()
    {
         return m_BeyBladeParameters.attackMode_MovementMultiplier * m_inputController.MoveDirection;
    }
}
