using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public MonsterController pref;

    void Start()
    {
        MonsterController monster = Instantiate(pref, transform.position, transform.rotation);
    }
}
