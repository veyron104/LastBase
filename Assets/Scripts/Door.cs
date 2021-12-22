using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    public bool blocked = true;
    public Transform doorObject;
    public NavMeshObstacle nmo;

    bool opening = false;
    public AudioSource openingSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (blocked)
            {
                GameMngr.gM.ShowMsg("Дверь заблокирована!");
            }
            else
            {
                opening = true;
                nmo.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (opening)
        {
            doorObject.position = new Vector3(doorObject.position.x, doorObject.position.y + Time.deltaTime, doorObject.position.z);
            if (doorObject.position.y >= 12)
            {
                doorObject.position = new Vector3(doorObject.position.x, 12, doorObject.position.z);
                opening = false;
            }
        }
    }
}
