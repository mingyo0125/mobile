using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Entity<T, G>
{
    protected virtual float GetDamage()
    {
        return _entityStatSO.EntityStat.Damage;
    }
}
