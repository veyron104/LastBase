using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Stats
{
    public List<Stats> targets = new List<Stats>();
    float nextShot = 0f;
    public float fireRate = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Monster")) return;
        Stats _target = other.GetComponent<Stats>();

        if (_target != null && !targets.Contains(_target)) targets.Add(_target);
    }

    private void Update()
    {
        if (targets.Count > 0)
        {
            if (targets[0] == null) targets.RemoveAt(0);
            else
            {
                transform.LookAt(targets[0].transform);
                if (Time.time >= nextShot)
                {
                    nextShot = Time.time + 1f / fireRate;
                    Fire();
                }
            }    
        }
    }

    void Fire()
    {
        if (Physics.Raycast(transform.position, targets[0].transform.position - transform.position, out RaycastHit _hit))
        {
            Stats _target = _hit.collider.GetComponent<Stats>();
            if (_target != null && _hit.collider.CompareTag("Monster")) _target.GetDamage(attack, this);
            else targets.Remove(_target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Stats _target = other.GetComponent<Stats>();

        if (targets.Contains(_target)) targets.Remove(_target);
    }
}
