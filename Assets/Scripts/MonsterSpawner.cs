using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public MonsterController pref;
    public float delay;

    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    public IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(delay);

        Instantiate(pref, transform.position, transform.rotation);
    }
}