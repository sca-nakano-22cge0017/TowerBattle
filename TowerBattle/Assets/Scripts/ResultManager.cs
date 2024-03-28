using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// リザルト表示
/// </summary>
public class ResultManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text[] Ranking;
    [SerializeField] GameObject NewRecord;
    int nowScore;
    int[] scoreRank = new int[6];

    void Start()
    {
        //新記録の表示を消す
        NewRecord.SetActive(false);

        //今回のスコアを取得
        nowScore = PlayerPrefs.GetInt("Score", 0);

        //配列に今までの1位～5位のスコアを入れる
        for (int i = 0; i < scoreRank.Length; i++)
        {
            scoreRank[i] = PlayerPrefs.GetInt("No" + i.ToString(), 0);
        }

        //今回のスコアが今までの最高スコアより高かったら「NewRecord」を表示
        if (nowScore >= scoreRank[0])
        {
            NewRecord.SetActive(true);
        }

        //今回のスコア表示
        scoreText.text = nowScore.ToString();
        //配列の6番目に今回のスコアを入れる
        scoreRank[5] = nowScore;

        //降順ソート
        System.Array.Sort(scoreRank);
        System.Array.Reverse(scoreRank);

        //ランキング表示
        for (int i = 0; i < Ranking.Length; i++)
        {
            Ranking[i].text = scoreRank[i].ToString();
        }

        //ランキング保存
        for (int i = 0; i < scoreRank.Length; i++)
        {
            PlayerPrefs.SetInt("No" + (i + 1).ToString(), scoreRank[i]);
        }
    }
}
