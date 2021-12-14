using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakInGameComputer : MonoBehaviour
{
    public Door openedDoor;
    public int hard;

    private void OnTriggerEnter(Collider other)
    {
        if (openedDoor.blocked && other.CompareTag("Player")) BreakInGameMngr.bigM.StartBreakIn(openedDoor, hard);
    }
}
