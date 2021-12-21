using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Stats
{
    public Bullet bulletPref;
    public Transform bulletSpawner;
    Vector3 direction;
    public Rigidbody rb;

    public float sens;
    public Transform cameraView;
    public Transform gun;
    bool dead;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 5, 0);
        }
        transform.Translate(direction * speed * Time.deltaTime);
        //transform.position += direction * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Bullet bullet = Instantiate(bulletPref, bulletSpawner.position, bulletSpawner.rotation);
            bullet.Starter(attack);
        }

        float xRot = Input.GetAxis("Mouse X");
        float yRot = - Input.GetAxis("Mouse Y");

        transform.Rotate(0, xRot * sens, 0);
        cameraView.Rotate(yRot * sens, 0, 0);
        gun.Rotate(yRot * sens, 0, 0);
    }

    public override void GetDamage(float _damage)
    {
        base.GetDamage(_damage);
        GameMngr.gM.ShowMsg("Получено урона " + _damage);
    }

    public override void Die()
    {
        dead = true;
        GameMngr.gM.ShowMsg("Вы умерли!");
    }
}