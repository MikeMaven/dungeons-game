using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : EnemyClass
{
    public override void Attack(){
        base.Attack();
        Debug.Log("Special Attack");
    }

    public override void Update()
    {
        Debug.Log("Spider Updating");
    }
}
