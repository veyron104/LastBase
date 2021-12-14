using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool blocked = true;
    public Transform doorObject;

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
                doorObject.position = new Vector3(doorObject.position.x, 12 , doorObject.position.z);
            }
        }
    }
}
