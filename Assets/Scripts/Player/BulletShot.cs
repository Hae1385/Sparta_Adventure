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
        inventory.ThrowWeapon();  //인벤토리에 공격시 소모되도록 조치
        GameObject bullet = Instantiate(Bullet, bulletPos.position, bulletPos.rotation); //총알이 발사될 위치 불러오기
        bullet.GetComponent<Rigidbody>().AddForce(bulletPos.forward * firePower);  //총알을 firePower만큼 앞으로 발사
        Destroy(bullet, 5f); //5초뒤 파괴되게

    }
}
