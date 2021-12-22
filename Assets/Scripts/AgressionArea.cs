using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressionArea : MonoBehaviour
{
    public MonsterController parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) parent.Attack(other.GetComponent<Stats>());
    }
}
