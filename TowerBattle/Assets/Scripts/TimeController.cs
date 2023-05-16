using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] float timeLimit;
    [SerializeField] Text countText;
    [SerializeField] Text timeupText;
    float timer;
    enum TIME_STATE { WAIT = 0, PLAY, }
    TIME_STATE state = 0;

    bool isWait;
    public bool iswait => isWait;
    public float Timer => timer;

    void Start()
    {
        isWait = true;
        timer = timeLimit;
        timeText.text = "" + timer.ToString("n2");
        StartCoroutine("CountDown");
        timeupText.enabled = false;
    }

    void Update()
    {
        if(state == TIME_STATE.PLAY)
        {
            timer -= Time.deltaTime;
            timeText.text = "" + timer.ToString("n2");
            countText.text = "";
        }

        if (timer <= 0)
        {
            timer = 0f;
            timeText.text = "0";
            isWait = true;
        }

        if(timer == 0)
        {
            timeupText.enabled = true;
            StartCoroutine("Result");
        }
    }

    IEnumerator CountDown()
    {
        for (int i = 3; i >= 0; i--)
        {
            countText.text = "" + i;
            if(i == 0) {
                countText.text = "START!!";
            }
            yield return new WaitForSeconds(1);
        }
        isWait = false;
        state = TIME_STATE.PLAY;
        yield break;
    }

    IEnumerator Result()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ResultScene");
    }
}