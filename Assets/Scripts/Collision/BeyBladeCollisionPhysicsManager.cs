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

    private void HandleCollsion(IBasicCollision _collision)
    {
        Debug.Log("Physis calculated");
        if(_collision.CheckIfPassedGameObjectIsInvolvedInCollision(gameObject))
        {
            m_initialVelocityAfterCollision = _collision.GetVelocityAfterCollision(gameObject);
        }
    }
}
