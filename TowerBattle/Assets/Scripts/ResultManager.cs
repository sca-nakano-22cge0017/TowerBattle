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
    int[] scoreRank = new int[6];

    void Start()
    {
        NewRecord.SetActive(false);
        score = PlayerPrefs.GetInt("Score", 0);
        scoreRank[0] = PlayerPrefs.GetInt("No1", 0);
        scoreRank[1] = PlayerPrefs.GetInt("No2", 0);
        scoreRank[2] = PlayerPrefs.GetInt("No3", 0);
        scoreRank[3] = PlayerPrefs.GetInt("No4", 0);
        scoreRank[4] = PlayerPrefs.GetInt("No5", 0);
        scoreRank[5] = PlayerPrefs.GetInt("No6", 0);

        if (score >= scoreRank[0])
        {
            NewRecord.SetActive(true);
        }

        scoreText.text = score + "";

        scoreRank[5] = score;
        System.Array.Sort(scoreRank);
        System.Array.Reverse(scoreRank);

        No1.text = scoreRank[0] + "";
        No2.text = scoreRank[1] + "";
        No3.text = scoreRank[2] + "";
        No4.text = scoreRank[3] + "";
        No5.text = scoreRank[4] + "";

        PlayerPrefs.SetInt("No1", scoreRank[0]);
        PlayerPrefs.SetInt("No2", scoreRank[1]);
        PlayerPrefs.SetInt("No3", scoreRank[2]);
        PlayerPrefs.SetInt("No4", scoreRank[3]);
        PlayerPrefs.SetInt("No5", scoreRank[4]);
        PlayerPrefs.SetInt("No6", scoreRank[5]);
    }

    void Update()
    {
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
