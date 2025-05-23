using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;
    public float useStamina;
    public GameObject Bullet;
    public BulletShot bulletShot;

    [Header("Resource Gathering")]
    public bool doesGatherResources;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;
    private Camera camera;

    private void Start()
    {
        animator = GetComponent<Animator>();
        camera = Camera.main;
        bulletShot = GetComponent<BulletShot>();
    }

    public override void OnAttackInput()
    {
        if (!attacking)
        {
            if (CharacterManager.Instance.Player.condition.UseStamina(useStamina))
            {
                attacking = true;
                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    public override void OnShotInput()
    {
        if (Bullet == null)  //불릿 프리팹이 없으면 예외처리
            return;


        if (!attacking) 
        {
            if (CharacterManager.Instance.Player.condition.UseStamina(useStamina))
            {
                attacking= true;
                animator.SetTrigger("Attack");
                if (bulletShot == null) {bulletShot = GetComponentInParent<BulletShot>();}
                bulletShot.OnShotBullet();  //총알이 발사되도록 설정
                Invoke("OnCanAttack", attackRate);  //공격시 발사가 안되도록 동일 딜레이 적용
            }
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
    }
}
