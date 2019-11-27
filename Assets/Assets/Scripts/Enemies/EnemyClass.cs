using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyClass : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;

    [SerializeField]
    protected  Transform pointA, pointB;

   private void Start(){
       Attack();
   }

   public virtual void Attack()
   {
       Debug.Log("Base Attack");
   }

   public abstract void Update();
}
