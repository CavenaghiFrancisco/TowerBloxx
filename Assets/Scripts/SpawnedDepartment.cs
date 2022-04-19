using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedDepartment : MonoBehaviour
{
    private GameObject city;
    private Rigidbody rb;
    private Renderer rend;
    private Collider coll;
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
        coll = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio.pitch = UnityEngine.Random.Range(0.7f, 1.3f); 
        audio.Play();
        if (Mathf.Abs(collision.transform.position.x - transform.position.x) < rend.bounds.size.x / 2 && collision.transform.CompareTag("Department") || id == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
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
            StartCoroutine(DestroyDepartment());
        }
    }

    private IEnumerator DestroyDepartment()
    {
        Destroy(coll);
        Destroy(gameObject, 0.5f);
        yield return new WaitForSeconds(0.4f);
        OnDamageReceived();
    }

}
