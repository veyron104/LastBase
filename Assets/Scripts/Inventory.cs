using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{
    public Transform inventoryWindow;
    public Sprite spriteNeutral;
    public List<Slot> allSlots;
    public Slot slotPref;
    public Slot pickedSlot;
    public int pickedSlotID;
    public float picking = 0f;
    public PlayerController player;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Slot newSlot = Instantiate(slotPref, inventoryWindow);
            allSlots.Add(newSlot);
            newSlot.inventory = this;
        }
        CloseWindow();
    }

    public bool AddItem(Item item, int count)
    {
        foreach (Slot slot in allSlots)
        {
            if (slot.item == null)
            {
                slot.AddItem(item, count);
                return true;
            }
            else
            {
                if ((item.stackAble) && (slot.item.itemID == item.itemID))
                {
                    slot.AddItem(item, count);
                    return true;
                }
            }
        }
        return false;
    }

    public void DropItem()
    {
        if (pickedSlot != null)
        {
            //  итемы на полу
            pickedSlot.DeleteItem(pickedSlot.itemCount);
            pickedSlot.UnPick();
        }
    }

    public void UnPickSLot()
    {
        if (pickedSlot != null) pickedSlot.UnPick();
    }

    public void CloseWindow()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player.canShoot = true;
        gameObject.SetActive(false);
    }
}
