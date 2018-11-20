using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    //https://www.youtube.com/watch?v=IvT8hjy6q4o
    public Rigidbody ball;
    public Transform target;
    public float h = 25;
    public float gravity = -18;
    // Use this for initialization
    void Start()
    {
        ball.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    public Vector3 CalculateLaunchVelocity()
    {
        float displaceY = target.position.y - ball.position.y;
        Vector3 displaceXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displaceXZ / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displaceY - h) / gravity));

        return velocityXZ + velocityY * (-Mathf.Sign(gravity));
    }

    public void Launch()
    {
        Physics.gravity = Vector3.up * gravity;
        ball.useGravity = true;
        ball.velocity = CalculateLaunchVelocity();

        print(CalculateLaunchVelocity());
    }
}
