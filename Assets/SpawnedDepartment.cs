using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedDepartment : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer rend;
    private bool failedSpawn = false;
    public int id;
    public static Action OnDamageReceived;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!failedSpawn)
        {
            if (Mathf.Abs(collision.transform.position.x - transform.position.x) < rend.bounds.size.x / 2 || id == 0)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                transform.rotation = Quaternion.identity;
                Destroy(rb);
                Destroy(GetComponent<SpawnedDepartment>());
            }
            else
            {
                failedSpawn = true;
                if (OnDamageReceived != null)
                {
                    OnDamageReceived();
                }
            }
        }
        else
        {
            if (collision.transform.CompareTag("Floor") && id != 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
