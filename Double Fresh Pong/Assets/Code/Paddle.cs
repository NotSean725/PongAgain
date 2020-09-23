using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float verticalSpeed;
    public float maxYPosition;
    public int hitDirection;
    public KeyCode upKey;
    public KeyCode downKey;

    public Ball theBall;

    private void Update()
    {
        if (Input.GetKey(upKey) && transform.position.y <= maxYPosition)
        {
            MoveUp();
        }
        else if (Input.GetKey(downKey) && transform.position.y >= -maxYPosition)
        {
            MoveDown();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            HitBall(collision.gameObject.GetComponent<Ball>());
        }
    }

    public void MoveUp()
    {
       transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
    }

    public void MoveDown()
    {
        transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
    }

    public void HitBall(Ball pongBall)
    {
        float yDirection = pongBall.transform.position.y - transform.position.y;
        Vector3 directionToHit = new Vector3(hitDirection, yDirection, 0);
        pongBall.GetHit(directionToHit);
        SoundManager.Instance.PlayHitSound();
    }
}
