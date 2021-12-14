using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : Stats
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
