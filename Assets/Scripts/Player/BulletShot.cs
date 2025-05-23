using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletPos;
    public float firePower;

    EquipTool equipTool;
    
    public Inventory inventory;

    private void Awake()
    {
        equipTool = GetComponent<EquipTool>();
    }
    public void OnShotBullet()
    {
        inventory.ThrowWeapon();
        GameObject bullet = Instantiate(Bullet, bulletPos.position, bulletPos.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletPos.forward * firePower);
        Destroy(bullet, 5f);

    }
}
