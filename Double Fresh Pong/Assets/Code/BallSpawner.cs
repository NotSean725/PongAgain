using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Ball ballPrefab;
    public int xDirectionToServe;

    public static BallSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ServeBall(1);
    }

    public void ServeBall(int xDirection)
    {
        StartCoroutine(DelayServe());
    }

    private IEnumerator DelayServe()
    {
        yield return new WaitForSeconds(2);
        SoundManager.Instance.PlayServeSound();
        Ball newBall = Instantiate(ballPrefab);
        newBall.direction = new Vector3(xDirectionToServe, 0, 0);
    }
}
