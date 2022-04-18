using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    [SerializeField] private bool xVector;
    [SerializeField] private bool yVector;
    [SerializeField] private bool zVector;
    [SerializeField] private float xVectorVelocity;
    [SerializeField] private float yVectorVelocity;
    [SerializeField] private float zVectorVelocity;

    private void Update()
    {
        if(xVector)
            transform.Rotate(xVectorVelocity * Time.deltaTime, 0, 0, Space.Self);
        if(yVector)
            transform.Rotate(0, yVectorVelocity * Time.deltaTime, 0, Space.Self);
        if(zVector)
            transform.Rotate(0, 0, zVectorVelocity * Time.deltaTime, Space.Self);
    }
}
