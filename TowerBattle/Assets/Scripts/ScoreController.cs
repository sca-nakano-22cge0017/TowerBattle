﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text scoreText;
    bool normalUp, specialUp, scoreDown;
    enum SCORE_STATE {BASIC = 0, NORMAL, SPECIAL, ERACE, DOWN,}
    SCORE_STATE scoreState = 0;
    int score;

    void Start()
    {
        //score = -100;
        score = 0;
        scoreText.text = "0";
    }

    void Update()
    {
        scoreText.text = "" + score;

        if(score <= 0)
        {
            scoreText.text =  "0";
        }

        switch(scoreState)
        {
            case SCORE_STATE.BASIC:
            break;
            case SCORE_STATE.NORMAL:
                score += 100;
                scoreState = SCORE_STATE.BASIC;
            break;
            case SCORE_STATE.SPECIAL:
                score += 250;
                scoreState = SCORE_STATE.BASIC;
            break;
            case SCORE_STATE.ERACE:
                score += 500;
                scoreState = SCORE_STATE.BASIC;
            break;
            case SCORE_STATE.DOWN:
                score -= 250;
                scoreState = SCORE_STATE.BASIC;
            break;
        }
    }

    public void NormalUp()
    {
       scoreState = SCORE_STATE.NORMAL;
    }

    public void SpecialUp()
    {
        scoreState = SCORE_STATE.SPECIAL;
    }

    public void Erace()
    {
        scoreState = SCORE_STATE.ERACE;
    }

    public void ScoreDown()
    {
        scoreState = SCORE_STATE.DOWN;
    }
}
