using System.Collections;
using UnityEngine;

public class EnemyCollisionMovementSwitchManager : CollisionMovementSwitchManager
{
    protected override void HandleCollision()
    {
        collisionMovementManager.enabled = true;
        ordinaryMovementManager.enabled = false;
        StartCoroutine(EndCollsion(movementControlSwitchTime));
    }
    IEnumerator EndCollsion(float _endTime)
    {
        yield return new WaitForSeconds(_endTime);
        collisionMovementManager.enabled = false;
        ordinaryMovementManager.enabled = true;
    }
}