﻿using UnityEngine;

public class BeyBladeModeAvailabilityManager : MonoBehaviour
{
    public delegate void PostCollisionModeAvailabilityHandler(string _uID, GameObject _gameObject,BeyBladeCollision _collision);
    public static event PostCollisionModeAvailabilityHandler OnCollided;
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    protected BeyBladeValues beyBladeValues;


    private void Awake()
    {
        CollisionManager.OnBeyBladesCollided += HandleModeAvailabilityAfterCollision;
    }

    private void OnDisable()
    {
        CollisionManager.OnBeyBladesCollided -= HandleModeAvailabilityAfterCollision;
    }

    private void HandleModeAvailabilityAfterCollision(BeyBladeCollision _Collision)
    {
        if (_Collision.IsAttacker(gameObject) == false && _Collision.IsVictim(gameObject) == false)
        {
            Debug.Log("Neither Attacker Nor Victim");
            return;
        }
        OnCollided?.Invoke(gameObject.GetComponent<BeyBladeTag>().UID, this.gameObject, _Collision);
    }

}

