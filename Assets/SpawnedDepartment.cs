using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedDepartment : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer rend;
    public int id;
    public static Action OnDamageReceived;
    public static Action OnCorrectLanding;
    private RaycastHit hitDetect;
    private bool hit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (Mathf.Abs(collision.transform.position.x - transform.position.x) < rend.bounds.size.x / 2 || id == 0)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            Destroy(rb);
            if(OnCorrectLanding != null)
            {
                OnCorrectLanding();
            }
            Destroy(GetComponent<SpawnedDepartment>());
        }
        else if(collision.transform.CompareTag("Floor"))
        {
            if (OnDamageReceived != null)
            {
                OnDamageReceived();
            }
            Destroy(gameObject);
        }
        else
        {
            if (OnDamageReceived != null)
            {
                OnDamageReceived();
            }
            Destroy(gameObject, 0.1f);
        }
    }

}
