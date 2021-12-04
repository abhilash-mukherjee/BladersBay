using System;
using System.Collections.Generic;
using UnityEngine;

public class BeyBladeCollision
{
    private CollidingBeyBlade m_beyBlade1, m_beyBlade2;
    public CollidingBeyBlade BeyBlade1 { get => m_beyBlade1; }
    public CollidingBeyBlade BeyBlade2 { get => m_beyBlade2; }
    public float AngleDifference { get => m_angleDifference; }
    public float CollisionIndex { get => m_collisionIndex; }

    private List<CollidingBeyBlade> attackers,victims;
    private float m_collisionIndex = 0;
    private float m_angleDifference = 180;
    private float m_collisionVelocityMultiplier = 1f;
    private float m_staticCollisionVelocityLimit;
    private float m_staticCollisionVelocityMultiplier;
    private BeyBladeCollisionType m_collisionType;

    public BeyBladeCollision(GameObject _player1, GameObject _player2, List<BeyBladeCollisionType> _collisionTypes, 
        float _collisionVelocityMultiplier, float _staticCollisionVelocityLimit, float _staticCollisionVelociyMultiplier)
    {
        m_beyBlade1 = new CollidingBeyBlade(_player1.GetComponent<CharacterController>(), _player1.transform.position,
            _player2.transform.position - _player1.transform.position, _player2.GetComponent<CharacterController>(),
            _staticCollisionVelocityLimit,_staticCollisionVelociyMultiplier);
        m_beyBlade2 = new CollidingBeyBlade(_player2.GetComponent<CharacterController>(), _player2.transform.position,
            _player1.transform.position - _player2.transform.position, _player1.GetComponent<CharacterController>(),
            _staticCollisionVelocityLimit, _staticCollisionVelociyMultiplier);
        m_angleDifference = CalculateAngleDifference();
        m_collisionType = GetCollisionType(_collisionTypes);
        if (m_collisionType == null)
            return;
        victims = m_collisionType.GetVictim(this);
        if(victims.Count != 0)
            attackers = m_collisionType.GetAttacker(this);
        if(attackers.Count != 0)
            m_collisionIndex = CalculateCollisionIndex();
        m_collisionVelocityMultiplier = _collisionVelocityMultiplier;
    }


    private float CalculateAngleDifference()
    {
        if (m_beyBlade1.VelocityBeforeCollision.magnitude ==0f || m_beyBlade2.VelocityBeforeCollision.magnitude == 0f)
        {
            return 180f;
        }
        else
        {
            Debug.Log($"{m_beyBlade1.BeyBladeObject} angle = {m_beyBlade1.CollisionAngle}, and {m_beyBlade2.BeyBladeObject} angle = {m_beyBlade2.CollisionAngle}");
            var _Angle = (m_beyBlade1.CollisionAngle - m_beyBlade2.CollisionAngle);
            _Angle = _Angle > 0 ? _Angle : -1f * _Angle;
            return _Angle;
        }
    }

    public Vector3 GetVelocityAfterCollision(GameObject _gameObject)
    {
        if (m_beyBlade1.BeyBladeObject == _gameObject)
            return m_beyBlade1.VelocityAfterCollision * m_collisionVelocityMultiplier;
        else if(m_beyBlade2.BeyBladeObject == _gameObject)
            return m_beyBlade2.VelocityAfterCollision * m_collisionVelocityMultiplier;
        else return Vector3.zero;
    }
    public bool CheckIfPassedGameObjectIsInvolvedInCollision(GameObject _gameObject)
    {
        if (m_beyBlade1.BeyBladeObject == _gameObject || m_beyBlade2.BeyBladeObject == _gameObject)
            return true;
        else
            return false;
    }
    private BeyBladeCollisionType GetCollisionType(List<BeyBladeCollisionType> _collisionTypes)
    {
        foreach (var _type in _collisionTypes)
        {
            if (_type.CheckCondition(this))
                return _type;
        }
        return null;
    }
    private float CalculateCollisionIndex()
    {
        return m_collisionType.CollisionIndex;
    }

    public bool IsAttacker(GameObject _gameObject)
    {
        var a = attackers.Find(p => p.BeyBladeObject == _gameObject);
        if (a == null)
            return false;
        else return true;
    }
    public bool IsVictim(GameObject _gameObject)
    {
        var v = victims.Find(p => p.BeyBladeObject == _gameObject);
        if (v == null)
            return false;
        else return true;
    }

    public GameObject GetVictim(GameObject _attackerObject)
    {
        var _beyBlade = victims.Find(p => p.BeyBladeObject != _attackerObject);
        if (_beyBlade != null)
            return _beyBlade.BeyBladeObject;
        else
            return null;
    }
    public GameObject GetAttacker(GameObject _victimObject)
    {
        var _beyBlade = attackers.Find(p => p.BeyBladeObject != _victimObject);
        if (_beyBlade != null)
            return _beyBlade.BeyBladeObject;
        else
            return null;
    }
}
