using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DepartmentSpawn : MonoBehaviour
{
    [SerializeField] private GameObject departmentPrefab;
    [SerializeField] private GameObject city;
    [SerializeField] private GameObject[] limits;
    private MeshRenderer mr;
    private Renderer rend;
    private bool deparmentAlreadySpawned = false;
    private bool moveUp = false;
    private bool inMovement = false;
    private GameObject lasDepartmentSpawned;
    private int departmentID = 0;
    private float speed = 0;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        rend = departmentPrefab.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !deparmentAlreadySpawned)
        {
            if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject != null)
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
        if(city.transform.Find("Departments").transform.childCount >= 15 && !inMovement)
        {
            inMovement = true;
            StartCoroutine(MoveDepartments());
        }
    }

    private IEnumerator DepartmentSpawned()
    {
        mr.enabled = false;
        lasDepartmentSpawned.AddComponent<SpawnedDepartment>();
        lasDepartmentSpawned.GetComponent<SpawnedDepartment>().id = departmentID;
        departmentID++;
        yield return new WaitForSeconds(1f);
        moveUp = false;
        yield return new WaitForSeconds(0.5f);
        mr.enabled = true;
        deparmentAlreadySpawned = false;
    }


    private IEnumerator MoveDepartments()
    {
        while (true)
        {
            while (city.transform.Find("Departments").transform.GetChild(city.transform.Find("Departments").transform.childCount - 1).transform.position.x - 1 > limits[1].transform.position.x)
            {
                city.transform.Find("Departments").transform.position  = Vector3.Lerp(city.transform.Find("Departments").transform.position, limits[1].transform.position, speed * Time.deltaTime);
                speed += Time.deltaTime * 0.5f;
                yield return null;
            }
            speed = 0.5f;
            while(city.transform.Find("Departments").transform.GetChild(city.transform.Find("Departments").transform.childCount - 1).transform.position.x + 1 < limits[0].transform.position.x)
            {
                city.transform.Find("Departments").transform.position = Vector3.Lerp(city.transform.Find("Departments").position, limits[0].transform.position, speed * Time.deltaTime);
                speed += Time.deltaTime * 0.5f;
                yield return null;
            }
            speed = 0.5f;
            yield return null;
        }
        
        
    }
}
