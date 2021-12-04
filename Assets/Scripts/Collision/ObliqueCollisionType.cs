using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Oblique Collision", menuName = "BeyBlade Collision/Oblique Collision")]
public class ObliqueCollisionType : BeyBladeCollisionType
{
    public override List<CollidingBeyBlade> GetAttacker(BeyBladeCollision _collision)
    {
        var _attackerList = new List<CollidingBeyBlade>();
        if (_collision.BeyBlade1.CollisionAngle > _collision.BeyBlade2.CollisionAngle)
            _attackerList.Add(_collision.BeyBlade2);
        else _attackerList.Add(_collision.BeyBlade1);
        return _attackerList;
    }

    public override List<CollidingBeyBlade> GetVictim(BeyBladeCollision _collision)
    {
        var _victimList = new List<CollidingBeyBlade>();
        if (_collision.BeyBlade1.CollisionAngle > _collision.BeyBlade2.CollisionAngle)
            _victimList.Add(_collision.BeyBlade1);
        else _victimList.Add(_collision.BeyBlade2);
        return _victimList;
    }
}