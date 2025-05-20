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

    public event Action onTakeDamage;
    private void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);
    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void Die()
    {
        Debug.Log("die");
    }

    public void TakePhysiclaDamage(int damage)
    {
        health.Subject(damage);
        onTakeDamage?.Invoke();
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

}
