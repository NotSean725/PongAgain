using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int ballYHitDirection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            HitBall(collision.gameObject.GetComponent<Ball>());
        }
    }

    public void HitBall(Ball pongBall)
    {
        Vector3 directionToHit = new Vector3(pongBall.direction.x, ballYHitDirection, 0);
        pongBall.GetHit(directionToHit);
    }
}
