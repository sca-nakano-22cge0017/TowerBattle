using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text scoreText;
    bool normalUp, specialUp;
    int score;

    void Start()
    {
        normalUp = false;
        specialUp = false;
        scoreText.text = "0";
    }

    void Update()
    {
        scoreText.text = "" + score;

        if(normalUp) {
            score += 100;
            normalUp = false;
        }

        if(specialUp) {
            score += 500;
            specialUp = false;
        }
    }
}
