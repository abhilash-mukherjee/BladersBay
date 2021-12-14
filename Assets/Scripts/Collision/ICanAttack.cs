using UnityEngine;

public interface ICanAttack
{
    GameObject GetAttacker(GameObject _victimObject);
    bool IsAttacker(GameObject _gameObject);
}