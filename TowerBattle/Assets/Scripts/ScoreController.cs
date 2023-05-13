using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text scoreText;
    bool normalUp, specialUp, scoreDown;
    int score;

    void Start()
    {
        score = -100;
        normalUp = false;
        specialUp = false;
        scoreDown = false;
        scoreText.text = "0";
    }

    void Update()
    {
        scoreText.text = "" + score;

        if(score <= 0)
        {
            scoreText.text =  "0";
        }

        if(normalUp) {
            score += 100;
            normalUp = false;
        }

        if(specialUp) {
            score += 250;
            specialUp = false;
        }

        if(scoreDown)
        {
            score -= 250;
            scoreDown = false;
        }
    }

    public void NormalUp()
    {
        normalUp = true;
    }

    public void SpecialUp()
    {
        specialUp = true;
    }

    public void ScoreDown()
    {
        Debug.Log("減少");
        scoreDown = true;
    }
}
