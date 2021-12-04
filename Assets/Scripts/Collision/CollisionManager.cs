using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionManager : MonoBehaviour
{
    public delegate void BeyBladeCollisionHealthHandler(BeyBladeCollision _collision);
    public delegate void BeyBladeCollisionPhysicsHandler(BeyBladeCollision _collision);
    public delegate void CollisionStartEndHandler(BeyBladeCollision _collision);
    public static event BeyBladeCollisionHealthHandler OnBeyBladesCollided;
    public static event BeyBladeCollisionPhysicsHandler OnCollisionPhysicsCalculated;
    public static event CollisionStartEndHandler OnCollisionStarted;
    public static event CollisionStartEndHandler OnCollisionEnded;
    [SerializeField]
    private List<BeyBladeCollisionType> collisionTypes = new List<BeyBladeCollisionType>();
    [SerializeField]
    private float timeGapBetweenTwoCollisions= 1f;
    [SerializeField]
    private Collider player1Collider, player2Collider;
    [SerializeField]
    private string beybladeHitSound= "BeyBladeClash";
    [SerializeField]
    private GameObject collisionSpark;
    [SerializeField]
    private float collisionVelocityMultiplier;
    [SerializeField]
    [Tooltip("Minimum velocity possessed by a beyblade below which beyblade is considered static while colliding")]
    private float staticCollisionVelocityLimit;
    [SerializeField]
    [Tooltip("Multiplying factor to a beyblade's final velocity after collision when it is static")]
    private float staticCollisionVelocityMultiplier = 0.1f;
    private BeyBladeCollision m_collision;
    private bool m_isCollisionPhaseOn = false;

    void Update()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        if (m_isCollisionPhaseOn)
            return;
        if (player1Collider.bounds.Intersects(player2Collider.bounds))
        {
            Instantiate(collisionSpark, (player1Collider.gameObject.transform.position + player2Collider.gameObject.transform.position) / 2f, Quaternion.identity);
            AudioManager.Instance.PlaySoundOneShot(beybladeHitSound);
            m_collision = new BeyBladeCollision(player1Collider.gameObject, player2Collider.gameObject, collisionTypes, collisionVelocityMultiplier,
                staticCollisionVelocityLimit, staticCollisionVelocityMultiplier);            
            //Physics Calculation Event must be triggered prior to starting the collision phase, or else movement will lag

            //Physics Calculation
            OnCollisionPhysicsCalculated?.Invoke(m_collision);
            OnBeyBladesCollided?.Invoke(m_collision);
            //Start Collision Phase
            OnCollisionStarted?.Invoke(m_collision);
            m_isCollisionPhaseOn = true;
            StartCoroutine(TurnOffCollisionPhaseAfterGivenTime(timeGapBetweenTwoCollisions));
        }
    }

    IEnumerator TurnOffCollisionPhaseAfterGivenTime(float _timeGapBetweenTwoCollisions)
    {
        yield return new WaitForSeconds(_timeGapBetweenTwoCollisions);
        OnCollisionEnded?.Invoke(m_collision);
        m_isCollisionPhaseOn = false;
    }
}
