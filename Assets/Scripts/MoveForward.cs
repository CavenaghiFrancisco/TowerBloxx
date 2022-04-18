using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;  
    }

    private void Start()
    {
        StartCoroutine(MoveAndRespawn());
    }

    private void Update()
    {
        transform.position += transform.forward * 3 * Time.deltaTime;
    }

    private IEnumerator MoveAndRespawn()
    {
        yield return new WaitForSeconds(Random.Range(15f, 35f));
        transform.position = startPosition;
        StartCoroutine(MoveAndRespawn());
    }
    
}
