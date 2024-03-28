using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �J�E���g�_�E���E�^�C�}�[����
/// </summary>
public class TimeController : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField, Header("��������")] float timeLimit;
    [SerializeField] Text countText;
    [SerializeField] Text timeupText;
    float timer;

    bool isWait;
    /// <summary>
    /// �ҋ@��Ԃ��ǂ���
    /// </summary>
    public bool iswait => isWait;
    /// <summary>
    /// �c�莞��
    /// </summary>
    public float Timer => timer;

    void Start()
    {
        isWait = true; //�ҋ@���

        timer = timeLimit;
        timeText.text = "" + timer.ToString("n2");

        StartCoroutine("CountDown"); //�J�E���g�_�E���J�n
        timeupText.enabled = false;
    }

    void Update()
    {
        //�ҋ@��Ԃ����������Ă�����
        if(!isWait)
        {
            timer -= Time.deltaTime;
            timeText.text = "" + timer.ToString("n2");

            countText.enabled = false;
        }

        //�������Ԃ�������
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
    /// �J�E���g�_�E��
    /// </summary>
    IEnumerator CountDown()
    {
        //3�b�̃J�E���g�_�E��
        for (int i = 3; i >= 0; i--)
        {
            countText.text = "" + i;
            if(i == 0) {
                countText.text = "START!!";
            }
            yield return new WaitForSeconds(1);
        }

        isWait = false; //�ҋ@��ԉ���
        //state = TIME_STATE.PLAY; //�v���C��Ԃɂ���

        yield break;
    }

    //���Ԃ��I������烊�U���g��ʂɑJ��
    IEnumerator Result()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ResultScene");
    }
}