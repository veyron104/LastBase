using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMngr : MonoBehaviour
{
    public static GameMngr gM;
    public List<Item> itemsDB = new List<Item>();

    void Awake()
    {
        gM = this;
    }

    public void UpdateStatsUI()
    {

    }

    public void ShowMsg(string msg)
    {
        Debug.Log(msg);
    }
}
