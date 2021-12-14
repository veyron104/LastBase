using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float hp;
    public float speed;
    public float attack;
    public float def;
    Stats target;


    public void DealDamage ()
    {
        target.GetDamage(attack);
    }

    public virtual void GetDamage(float _damage)
    {
        hp -= _damage * (1 - 0.7f * def / 150);
        if (hp <= 0)
        {
            hp = 0;
            Die();
        }
    }

    public virtual void Die()
    {

    }
}