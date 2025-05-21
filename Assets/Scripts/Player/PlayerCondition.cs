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
    Condition stamina { get { return uiCondition.health; } }

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
    private IEnumerator CoTimer(float addHealth, float addStamina)
    {
        while (duration <= 0)
        {
            Heal(addHealth * Time.deltaTime);
            AddStamina(addStamina * Time.deltaTime);
            yield return null;
        }
    }

    public void StartAddCor(float addHealth, float addStamina)
    {
        if (coroutine != null)
        {
            coroutine = StartCoroutine(CoTimer(addHealth, addStamina));
        }
    }

}
