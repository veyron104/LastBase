using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : Stats
{
    public NavMeshAgent nma;

    void Start()
    {
        StartCoroutine(FindDirection());
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {

    }

    public IEnumerator FindDirection()
    {
        yield return new WaitForSeconds(Random.Range(0f, 5f));

        //nma.SetDestination(new Vector3 (transform.position.x + Random.Range(-3, 3), 0, transform.position.z + Random.Range(-3, 3)));
    }
}
