using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10;
    float damage;
    bool hit = false;

    public void Starter(float _damage)
    {
        damage = _damage;
    }

    void Update()
    {
        if (hit) return;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Stats target = other.GetComponent<Stats>();
        if (target != null && !other.CompareTag("Player"))
        {
            target.GetDamage(damage);
            Destroy(gameObject);
        }
    }
}