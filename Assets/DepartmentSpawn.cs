using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DepartmentSpawn : MonoBehaviour
{
    [SerializeField] private GameObject departmentPrefab;
    [SerializeField] private GameObject city;
    private MeshRenderer mr;
    private Renderer rend;
    private bool deparmentAlreadySpawned = false;
    private bool moveUp = false;
    private GameObject lasDepartmentSpawned;
    private int departmentID = 0;


    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        rend = departmentPrefab.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !deparmentAlreadySpawned)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            deparmentAlreadySpawned = true;
            moveUp = true;
            lasDepartmentSpawned = Instantiate(departmentPrefab, transform.position, Quaternion.identity);
            StartCoroutine(DepartmentSpawned());
        }
        if (deparmentAlreadySpawned)
        {
            city.transform.position = Vector3.Lerp(city.transform.position, city.transform.position - new Vector3(0,rend.bounds.size.y/1.7f,0), Time.deltaTime);
        }
    }

    private IEnumerator DepartmentSpawned()
    {
        mr.enabled = false;
        lasDepartmentSpawned.AddComponent<SpawnedDepartment>();
        lasDepartmentSpawned.GetComponent<SpawnedDepartment>().id = departmentID;
        lasDepartmentSpawned.transform.SetParent(city.transform);
        departmentID++;
        yield return new WaitForSeconds(1f);
        moveUp = false;
        yield return new WaitForSeconds(0.5f);
        mr.enabled = true;
        deparmentAlreadySpawned = false;
    }

}
