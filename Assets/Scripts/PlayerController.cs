using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Stats
{
    public Camera myCam;
    Vector3 direction;
    public Rigidbody rb;

    public float sens;
    public Transform gun;
    bool dead;

    float nextShot = 0f;
    public float fireRate = 1f;
    public AudioSource shotSound;

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
        gun.Rotate(yRot * sens, 0, 0);

        if (Input.GetButton("Fire1") && Time.time >= nextShot)
        {
            nextShot = Time.time + 1f / fireRate;
            Fire();
        }
    }

    void Fire()
    {
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit _hit))
        {
            Stats target = _hit.collider.GetComponent<Stats>();
            if (target != null && _hit.collider.CompareTag("Monster")) target.GetDamage(attack, this);
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