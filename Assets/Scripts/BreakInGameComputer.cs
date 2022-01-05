using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType { Electricity, BreakIn };
public class BreakInGameComputer : MonoBehaviour
{
    public Door openedDoor;
    public GameType gameType;
    public int hard;

    private void OnTriggerEnter(Collider other)
    {
        if (openedDoor.blocked && other.CompareTag("Player"))
            switch (gameType)
            {
                case GameType.Electricity:
                    BreakInGameMngr.bigM.StartElectricity(openedDoor, hard);
                    break;
                case GameType.BreakIn:
                    BreakInGameMngr.bigM.StartBreakIn(openedDoor, hard);
                    break;
                default:
                    break;
            }
    }
}
