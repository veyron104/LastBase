using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : Stats
{
    public NavMeshAgent nma;
    bool moovibg = false;
    bool inCombat = false;
    Vector3 direction;

    void Update()
    {
        if (inCombat)
        {
            if (target != null) nma.SetDestination(target.transform.position);
            else inCombat = false;
        }
        else if (!moovibg)
        {
            StartCoroutine(FindDirection());
        }
    }

    public override void GetDamage(float _damage, Stats _target)
    {
        base.GetDamage(_damage, _target);
        Attack(_target);
    }

    public void Attack(Stats _target)
    {
        if (!inCombat)
        {
            target = _target;
            nma.speed *= 2;
            inCombat = true;
        }
    }

    public IEnumerator FindDirection()
    {
        moovibg = true;
        bool _onTheWay = false;
        NavMeshPath _path = new NavMeshPath();
        do
        {
            direction = new Vector3(transform.position.x + Random.Range(-3, 3), 0, transform.position.z + Random.Range(-3, 3));
            nma.SetDestination(direction);
            nma.CalculatePath(transform.position, _path);
            _onTheWay = _path.status == NavMeshPathStatus.PathComplete;
        } while (!_onTheWay);
        yield return new WaitForSeconds(Random.Range(3f, 7f));

        moovibg = false;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}