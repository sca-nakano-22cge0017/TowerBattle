using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// カウントダウン・タイマー制御
/// </summary>
public class TimeController : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField, Header("制限時間")] float timeLimit;
    [SerializeField] Text countText;
    [SerializeField] Text timeupText;
    float timer;

    bool isWait;
    /// <summary>
    /// 待機状態かどうか
    /// </summary>
    public bool iswait => isWait;
    /// <summary>
    /// 残り時間
    /// </summary>
    public float Timer => timer;

    void Start()
    {
        isWait = true; //待機状態

        timer = timeLimit;
        timeText.text = "" + timer.ToString("n2");

        StartCoroutine("CountDown"); //カウントダウン開始
        timeupText.enabled = false;
    }

    void Update()
    {
        //待機状態から解除されていたら
        if(!isWait)
        {
            timer -= Time.deltaTime;
            timeText.text = "" + timer.ToString("n2");

            countText.enabled = false;
        }

        //制限時間が来たら
        if (timer <= 0)
        {
            timer = 0f;
            timeText.text = "0";

            isWait = true;

            timeupText.enabled = true;
            StartCoroutine("Result");
        }
    }

    /// <summary>
    /// カウントダウン
    /// </summary>
    IEnumerator CountDown()
    {
        //3秒のカウントダウン
        for (int i = 3; i >= 0; i--)
        {
            countText.text = "" + i;
            if(i == 0) {
                countText.text = "START!!";
            }
            yield return new WaitForSeconds(1);
        }

        isWait = false; //待機状態解除
        //state = TIME_STATE.PLAY; //プレイ状態にする

        yield break;
    }

    //時間が終わったらリザルト画面に遷移
    IEnumerator Result()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ResultScene");
    }
}