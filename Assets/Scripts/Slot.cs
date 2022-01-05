using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Inventory inventory;
    public Item item;
    public int itemCount = 0;
    public int slotID;
    public TMP_Text stackTxt, nameTxt;
    public Image contentSl;
    public GameObject itemNamePanel;
    bool picked = false;

    public void AddItem(Item _item, int count)
    {
        item = _item;
        itemCount += count;
        
        if (itemCount > 1) stackTxt.text = itemCount.ToString();
        else stackTxt.text = "";
        nameTxt.text = _item.itemName;
        contentSl.sprite = _item.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && item != null) UseItem();

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item == null) return;
            if (inventory.pickedSlot == this)
            {
                if (Time.time < inventory.picking) UseItem();
            }
            else
            {
                if (inventory.pickedSlot != null) inventory.pickedSlot.UnPick();
                Pick();
            }
        }
    }

    void UseItem()
    {
        if (inventory.player.gun != null)
        {
            inventory.player.hp -= GameMngr.gM.itemsDB[inventory.player.gun.itemID].hp;
            inventory.player.speed -= GameMngr.gM.itemsDB[inventory.player.gun.itemID].speed;
            inventory.player.attack -= GameMngr.gM.itemsDB[inventory.player.gun.itemID].attack;
            inventory.player.def -= GameMngr.gM.itemsDB[inventory.player.gun.itemID].def;
            Destroy(inventory.player.gun.gameObject);
        }

        item.Use(inventory.player);
        DeleteItem(1);
    }

    public void DeleteItem(int y)
    {
        itemCount -= y;
        if (itemCount > 1) stackTxt.text = itemCount.ToString();
        else
        {
            if (itemCount == 1) stackTxt.text = string.Empty;
            else
            {
                item = null;
                contentSl.sprite = inventory.spriteNeutral;
                nameTxt.text = string.Empty;
                stackTxt.text = string.Empty;
                UnPick();
            }
        }
    }

    public void Pick()
    {
        inventory.pickedSlot = this;
        inventory.pickedSlotID = slotID;
        contentSl.color = Color.green;
        itemNamePanel.SetActive(true);
        inventory.picking = Time.time + 0.5f;
    }

    public void UnPick()
    {
        contentSl.color = Color.white;
        itemNamePanel.SetActive(false);
        inventory.pickedSlot = null;
    }
}