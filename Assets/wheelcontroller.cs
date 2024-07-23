using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelcontroller : MonoBehaviour
{
    public Rigidbody wheelRigidbody; // 轮子的刚体
    public float forceMagnitude = 10f; // 施加力的大小

    void Start()
    {
        if (wheelRigidbody == null)
        {
            wheelRigidbody = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyForwardForce();
        }
    }

    void ApplyForwardForce()
    {
        // 施加一个向前的力
        Debug.Log("1111");
        Vector3 force = transform.forward * forceMagnitude;
        wheelRigidbody.AddForce(force, ForceMode.Force);
    }
}
