using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelcontroller : MonoBehaviour
{
    public Rigidbody wheelRigidbody; // ���ӵĸ���
    public float forceMagnitude = 10f; // ʩ�����Ĵ�С

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
        // ʩ��һ����ǰ����
        Debug.Log("1111");
        Vector3 force = transform.forward * forceMagnitude;
        wheelRigidbody.AddForce(force, ForceMode.Force);
    }
}
