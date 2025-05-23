using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int damage;

    List<IDamagelbe> things = new List<IDamagelbe>();

    void Damage()
    {
        things[0].TakePhysiclaDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagelbe damage))
        {
            things.Add(damage);
            damage.TakePhysiclaDamage(this.damage);
        }
    }
}
