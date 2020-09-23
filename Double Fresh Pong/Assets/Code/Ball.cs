using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 direction;
    public int maxXposition;
    public float speedAdder;

    private void Update()
    {
        Move();
        CheckBoundaries();
    }

    public void GetHit(Vector3 hitDirection)
    {
        direction = hitDirection;

        // makes ball faster after every hit
        movementSpeed = movementSpeed + speedAdder;
    }

    public void Move()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    public void CheckBoundaries()
    {
        if(transform.position.x > maxXposition)
        {
            Scoreboard.Instance.AddPoint(true);
            Destroy(gameObject);
        }
        else if (transform.position.x < -maxXposition)
        {
            Scoreboard.Instance.AddPoint(false);
            Destroy(gameObject);
        }
    }
}
