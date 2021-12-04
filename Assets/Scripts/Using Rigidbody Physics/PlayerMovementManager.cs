using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class PlayerMovementManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rbd;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private Vector3 moveDirection;
    [SerializeField]
    private float moveForce = 100;
    [SerializeField]
    private float collisionImpulseMultiplier = 1000f;
    [SerializeField]
    private InputController inputController;
    private RotationManager rotationManager;
    private CharacterStateMachine stateMachine;
    private Vector3 m_moveVector;
    private void Awake()
    {
        rotationManager = GetComponent<RotationManager>();
        stateMachine = GetComponent<CharacterStateMachine>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (rotationManager.IsRotationStopped)
            return;
        moveDirection = inputController.MoveDirection; 
        var _moveMultipier = stateMachine.CalculateMovementMultiplier();
        rbd.AddForce(moveDirection * moveForce * _moveMultipier, ForceMode.Impulse);
        velocity = rbd.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.CompareTag("Stadium"))
        {
            Debug.Log($" {gameObject.name} Hit ground");
            rbd.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        }
    }

}
