using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public GameObject spring;
    public float jumpForce = 500f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);  //떨어지는 힘을 상쇄시키고
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);      //jumpForce만큼 위로 밀어내기
        }
    }
}