using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedDepartment : MonoBehaviour
{
    private GameObject city;
    private Rigidbody rb;
    private Renderer rend;
    private AudioSource audio;
    public int id;
    public static Action OnDamageReceived;
    public static Action OnCorrectLanding;
    private RaycastHit hitDetect;
    private bool hit;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        city = GameObject.FindGameObjectWithTag("City");
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio.pitch = UnityEngine.Random.Range(0.7f, 1.3f); 
        audio.Play();
        if (Mathf.Abs(collision.transform.position.x - transform.position.x) < rend.bounds.size.x / 2 && collision.transform.CompareTag("Department") || id == 0)
        {
            Debug.Log(id);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            Destroy(rb);
            OnCorrectLanding();
            transform.SetParent(city.transform.Find("Departments").transform);
            Destroy(GetComponent<SpawnedDepartment>());
        }
        else
        {
            OnDamageReceived();
            Destroy(gameObject);
        }
    }

}
