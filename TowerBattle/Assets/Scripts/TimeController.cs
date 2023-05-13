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
    float timer;
    enum TIME_STATE { WAIT = 0, PLAY, TIMEUP, }
    TIME_STATE state = 0;

    bool isWait;

    public bool iswait => isWait;

    void Start()
    {
        isWait = true;
        timer = timeLimit;
        timeText.text = "" + timer.ToString("n2");
        StartCoroutine("CountDown");
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
}