using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakInGameMngr : MonoBehaviour
{
    public Door targetDoor;
    public static BreakInGameMngr bigM;
    public GameObject gameWndw;
    public GameObject winnerWndw;
    public Text openedDoorText;

    void Awake()
    {
        bigM = this;
    }

    public void StartBreakIn(Door _targetDoor, int _hard)
    {
        Cursor.lockState = CursorLockMode.None;
        targetDoor = _targetDoor;
        gameWndw.SetActive(true);
        openedDoorText.text = $"Дверь {targetDoor.name} открыта!";
    }

    public void Cancel()
    {
        gameWndw.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenDoor()
    {
        gameWndw.SetActive(false);
        targetDoor.blocked = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
