using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Stats
{
    public Camera myCam;
    Vector3 direction;
    public Rigidbody rb;

    public float sens;
    bool dead;

    public Transform gunParent;
    public Gun gun;

    public bool canShoot = true;
    public Inventory inventory;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        dead = false;
    }

    void Update()
    {
        if (dead) return;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)) rb.velocity = new Vector3(0, 5, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        float xRot = Input.GetAxis("Mouse X");
        float yRot = - Input.GetAxis("Mouse Y");

        transform.Rotate(0, xRot * sens, 0);
        myCam.transform.Rotate(yRot * sens, 0, 0);

        if (Input.GetButton("Fire1") && canShoot && Time.time >= gun.nextShot && gun.shotAvailable)
        {
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit _hit)) gun.Fire(_hit);
        }
        if (Input.GetButtonUp("Fire1")) gun.shotAvailable = true;

        if (Input.GetButtonDown("Fire2")) PickUpItem();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
            if (inventory.gameObject.activeSelf)
            {
                canShoot = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                canShoot = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    void PickUpItem()
    {
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit _hit))
        {
            ItemSpawner _target = _hit.collider.GetComponent<ItemSpawner>();
            if (_target != null && _hit.collider.CompareTag("Item"))
            {
                if (inventory.AddItem(_target.item, _target.count)) Destroy(_target.gameObject);
            }
        }
    }

    public override void GetDamage(float _damage, Stats _target)
    {
        base.GetDamage(_damage, _target);
        GameMngr.gM.ShowMsg("Получено урона " + _damage);
    }

    public override void Die()
    {
        dead = true;
        GameMngr.gM.ShowMsg("Вы умерли!");

        Cursor.lockState = CursorLockMode.None;
    }
}