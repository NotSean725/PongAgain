using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard Instance;

    // These are the variables that make up the scoreboard
    private int _p1Score;
    private int _p2Score;
    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    public TextMeshProUGUI winText;

    [Range(1,7)]
    public int scoreToWin;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoint(bool isForPlayer1)
    {
        if (isForPlayer1)
        {
            _p1Score++;
            BallSpawner.Instance.ServeBall(1);
        }
        else
        {
            _p2Score++;
            BallSpawner.Instance.ServeBall(-1);
        }
        UpdateScoreText();
        DetermineWinStatus();
    }

    void UpdateScoreText()
    {
        p1ScoreText.SetText(_p1Score.ToString());
        p2ScoreText.SetText(_p2Score.ToString());
    }

    void DetermineWinStatus()
    {
        if (_p1Score >= scoreToWin)
        {
            winText.SetText("P2 got Pong'd by P1");
            BallSpawner.Instance.gameObject.SetActive(false);
            SoundManager.Instance.PlayPointScoredSound();
        }
        else if (_p2Score >= scoreToWin)
        {
            winText.SetText("P1 got Pong'd by P2");
            BallSpawner.Instance.gameObject.SetActive(false);
            SoundManager.Instance.PlayPointScoredSound();
        }
        else
        {
            winText.SetText("");
            SoundManager.Instance.PlayWinSound();
        }
    }
}
