using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamagelbe
{
    void TakePhysiclaDamage(int damage);
}
public class PlayerCondition : MonoBehaviour, IDamagelbe
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    private Coroutine coroutine;
    public float duration;

    private void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);
    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void AddStamina(float amout)
    {
        stamina.Add(amout);
    }

    public void Die()
    {
        Debug.Log("die");
    }

    public void TakePhysiclaDamage(int damage)
    {
        health.Subject(damage);
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }
        stamina.Subject(amount);
        return true;
    }
    private IEnumerator CoTimer(float addHealth, float addStamina, float duration)
    {
        while (0f < duration)
        {
            Heal(addHealth * Time.deltaTime);  //입력된 값만큼 초당 체력회복
            AddStamina(addStamina * Time.deltaTime);  //입력된 값만큼 초당 스테미너 회복
            duration -= Time.deltaTime;  //지속 시간을 입력받기 위한 코드
            yield return null;
        }
    }

    public void StartAddCor(float addHealth, float addStamina, float duration)  //아이템 타입이 Duraition이면 실행하기 위한 코드
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);  //해당 Couroutine이 실행중이면 종료
            coroutine = null;
        }
        coroutine = StartCoroutine(CoTimer(addHealth, addStamina, duration));
    }

}
