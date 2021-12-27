using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Stats
{
    public List<Stats> targets = new List<Stats>();
    public Gun gun;

    private void Start()
    {
        //gun.Equip(this);
    }

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
                //if (Time.time >= gun.nextShot)
                //{
                //    if (Physics.Raycast(transform.position, targets[0].transform.position - transform.position, out RaycastHit _hit)) gun.Fire(_hit);
                //}
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Stats _target = other.GetComponent<Stats>();

        if (targets.Contains(_target)) targets.Remove(_target);
    }
}