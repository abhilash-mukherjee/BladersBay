using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BeyBladeDecission : ScriptableObject
{
    public abstract bool Decide(BeyBladeStateController _stateCntroller);
}
