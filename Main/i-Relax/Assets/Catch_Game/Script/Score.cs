using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int ballValue;

    private int score;

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        score += ballValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "SCORE:\n" + score;
    }
}
