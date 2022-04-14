using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    Rigidbody rb;

    public Vector3 moveSpeed;
    public float leftAngle;
    public float rightAngle;

    bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            rb.angularVelocity = moveSpeed;
        }

        if (!movingClockwise)
        {
            rb.angularVelocity = -1 * moveSpeed;
        }
    }
}
