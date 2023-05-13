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
    enum STATE { WAIT = 0, PLAY, TIMEUP, }
    STATE state = 0;

    void Start()
    {
        timer = timeLimit;
        timeText.text = "" + timer.ToString("n2");
        StartCoroutine("CountDown");
    }

    void Update()
    {
        if(state == STATE.PLAY)
        {
            timer -= Time.deltaTime;
            timeText.text = "" + timer.ToString("n2");

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
            yield return new WaitForSeconds(1);
            countText.text = i.ToString();
        }
        state = STATE.PLAY;
        yield break;
    }
}
