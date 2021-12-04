using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyBladeCollisionPhysicsManager : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    private Vector3 m_initialVelocityAfterCollision;

    public Vector3 InitialVelocityAfterCollision { get => m_initialVelocityAfterCollision; }

    private void Awake()
    {
        CollisionManager.OnCollisionPhysicsCalculated += HandleCollsion;
    }
    private void OnDisable()
    {
        CollisionManager.OnCollisionPhysicsCalculated -= HandleCollsion;
        
    }

    private void HandleCollsion(BeyBladeCollision _collision)
    {
        if(_collision.CheckIfPassedGameObjectIsInvolvedInCollision(gameObject))
        {
            m_initialVelocityAfterCollision = _collision.GetVelocityAfterCollision(gameObject);
        }
    }

    private Vector3 CalculateInitialVelocityAfterCollision(Vector3 _otherVelocity, Vector3 _directionVectorOtherToThis)
    {
        _directionVectorOtherToThis.Normalize();
        Vector3 _normalVelocity = Vector3.Dot(_directionVectorOtherToThis, _otherVelocity) * _directionVectorOtherToThis;
        Vector3 _directionVectorThisToOther = -1f * _directionVectorOtherToThis;
        Vector3 _vel = characterController.velocity;
        float _angleInDegrees = Vector3.Angle(_directionVectorThisToOther, _vel); ;
        float _angleInRadian = (Mathf.PI * _angleInDegrees / 180f);
        Vector3 _tangentialVelocity = characterController.velocity
            - characterController.velocity.magnitude * Mathf.Cos(_angleInRadian) * _directionVectorThisToOther;
        Vector3 _finalVelocity = _normalVelocity + _tangentialVelocity;
        return _finalVelocity;
    }
}
