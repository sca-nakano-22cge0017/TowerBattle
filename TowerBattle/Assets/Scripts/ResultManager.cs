using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text No1, No2, No3, No4, No5;
    [SerializeField] GameObject NewRecord;
    int score, num;
    int[] scoreRanking = new int[6];
    bool x;

    void Start()
    {
        x = true;
        NewRecord.SetActive(false);
        score = PlayerPrefs.GetInt("Score", 0);
        scoreRanking[0] = PlayerPrefs.GetInt("No1", 0);
        scoreRanking[1] = PlayerPrefs.GetInt("No2", 0);
        scoreRanking[2] = PlayerPrefs.GetInt("No3", 0);
        scoreRanking[3] = PlayerPrefs.GetInt("No4", 0);
        scoreRanking[4] = PlayerPrefs.GetInt("No5", 0);
        scoreRanking[5] = PlayerPrefs.GetInt("No6", 0);
    }

    void Update()
    {
        if(score >= scoreRanking[0])
        {
            NewRecord.SetActive(true);
        }

        scoreText.text = score + "";

        if(x)
        {
            scoreRanking[5] = score;
            System.Array.Sort(scoreRanking);
            System.Array.Reverse(scoreRanking);

            No1.text = scoreRanking[0] + "";
            No2.text = scoreRanking[1] + "";
            No3.text = scoreRanking[2] + "";
            No4.text = scoreRanking[3] + "";
            No5.text = scoreRanking[4] + "";

            PlayerPrefs.SetInt("No1", scoreRanking[0]);
            PlayerPrefs.SetInt("No2", scoreRanking[1]);
            PlayerPrefs.SetInt("No3", scoreRanking[2]);
            PlayerPrefs.SetInt("No4", scoreRanking[3]);
            PlayerPrefs.SetInt("No5", scoreRanking[4]);
            PlayerPrefs.SetInt("No6", scoreRanking[5]);

            x = false;
        }

        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }

        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
