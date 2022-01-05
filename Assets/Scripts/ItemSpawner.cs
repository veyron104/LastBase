using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public SphereCollider col;
    public Item item;
    public int count = 1;
    public Transform itemPos;
    bool moveUp = true;

    private void Start()
    {
        item = GameMngr.gM.itemsDB[Random.Range(0, GameMngr.gM.itemsDB.Count)];
        Instantiate(item.primaryObj, itemPos.position, Quaternion.identity, itemPos);

        // изменить размер коллайдера под размер итема
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
        if (moveUp) itemPos.position += Vector3.up * Time.deltaTime;
        else itemPos.position -= Vector3.up * Time.deltaTime;

        if (itemPos.position.y < 0.5f) moveUp = true;
        else if (itemPos.position.y > 0.8f) moveUp = false;
    }
}
