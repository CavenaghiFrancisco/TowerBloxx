using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepartmentSpawn : MonoBehaviour
{
    [SerializeField] private GameObject departmentPrefab;
    private MeshRenderer mr;
    private bool deparmentAlreadySpawned = false;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !deparmentAlreadySpawned)
        {
            deparmentAlreadySpawned = true;
            Instantiate(departmentPrefab, transform.position, Quaternion.identity);
            StartCoroutine(DepartmentSpawned());
        }    
    }

    private IEnumerator DepartmentSpawned()
    {
        mr.enabled = false;
        yield return new WaitForSeconds(3f);
        mr.enabled = true;
        deparmentAlreadySpawned = false;
    }

}
