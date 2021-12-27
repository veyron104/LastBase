using System;
using System.Collections.Generic;
using UnityEngine;

public enum FireType { Automatic, Munal };
public enum ItemType { Equipment, Resource, Recepie, Potion };
public enum EquipmentType { Head, Weapon, Shield, Body, Legs, Gloves, Boots, Necklace, Earring, Ring};

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int itemID;
    public Sprite sprite;
    public string itemName;
    public bool stackAble;
    public GameObject primaryObj;

    public ItemType itemType;
    public EquipmentType equipmentType;
    public FireType fireType;

    public float hp;
    public float speed;
    public float attack;
    public float def;
    public float fireRate;

    public int craftChance;                     // Для рецепта
    public int completeId;                      // Для рецепта
    public int completeQuantity;                // Для рецепта

    public int time;                    // Для зелья

    public virtual bool Use(PlayerController _player)
    {
        switch (itemType)
        {
            case ItemType.Equipment:
                {
                    Debug.Log("Одеваю вещь");
                    GameObject newGun = Instantiate(primaryObj, _player.gunParent.position, _player.gunParent.rotation, _player.gunParent);
                    _player.gun = newGun.GetComponent<Gun>();
                    _player.gun.Equip(_player);
                    _player.gun.attack = attack;
                    _player.gun.fireRate = fireRate;
                    _player.gun.fireType = fireType;
                    return true;
                }
            case ItemType.Resource:
                {
                    Debug.Log("Can't use it");
                    return false;
                }
            case ItemType.Recepie:
                {

                    return false;
                }
            case ItemType.Potion:
                {
                    Debug.Log("Пью бутылёк!");
                    return true;
                }
            default:
                return false;
        }
    }
}