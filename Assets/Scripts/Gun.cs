using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float nextShot = 0f;
    public bool shotAvailable = true;
    public float fireRate = 1f;
    public AudioSource shotSound;
    public Transform bulletSpawner;
    public float attack;
    public FireType fireType;
    public int itemID;
    public Stats owner;

    public void Equip(Stats _owner)
    {
        owner = _owner;
    }

    public void Fire(RaycastHit _hit)
    {
        Stats target = _hit.collider.GetComponent<Stats>();
        if (target != null && _hit.collider.CompareTag("Monster")) target.GetDamage(attack, owner);

        nextShot = Time.time + 1f / fireRate;
        if (fireType == FireType.Munal) shotAvailable = false;
        // запустить звук
        // запустить эфект выстрела
        // спавн пули
        // наложить эфект на объект цели
        // наложить картинку на объект цели
    }
}