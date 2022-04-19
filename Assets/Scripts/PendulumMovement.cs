using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(SceneManager.GetActiveScene().name != "MainMenu")
        moveSpeed += new Vector3(0,0,0.05f * Time.deltaTime);
        Move();
    }

    private void ChangeMoveDir()
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

    private void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            rb.angularVelocity = moveSpeed;
        }
        else
        {
            rb.angularVelocity = -1 * moveSpeed;
        }
    }
}
