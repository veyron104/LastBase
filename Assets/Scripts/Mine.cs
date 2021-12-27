using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    List<Stats> targets = new List<Stats>();
    bool timerStarted = false;
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        Stats _target = other.GetComponent<Stats>();

        if (targets.Contains(_target)) Boom();
        else if (_target != null) targets.Add(_target);
    }

    void Boom()
    {
        foreach (var _target in targets)
        {
            if (_target != null) _target.GetDamage(damage, null);
        }

        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        Stats _target = other.GetComponent<Stats>();

        if (targets.Contains(_target)) targets.Remove(_target);
    }
}