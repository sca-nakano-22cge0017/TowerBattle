using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ���U���g�\��
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
        //�V�L�^�̕\��������
        NewRecord.SetActive(false);

        //����̃X�R�A���擾
        nowScore = PlayerPrefs.GetInt("Score", 0);

        //�z��ɍ��܂ł�1�ʁ`5�ʂ̃X�R�A������
        for (int i = 0; i < scoreRank.Length; i++)
        {
            scoreRank[i] = PlayerPrefs.GetInt("No" + i.ToString(), 0);
        }

        //����̃X�R�A�����܂ł̍ō��X�R�A��荂��������uNewRecord�v��\��
        if (nowScore >= scoreRank[0])
        {
            NewRecord.SetActive(true);
        }

        //����̃X�R�A�\��
        scoreText.text = nowScore.ToString();
        //�z���6�Ԗڂɍ���̃X�R�A������
        scoreRank[5] = nowScore;

        //�~���\�[�g
        System.Array.Sort(scoreRank);
        System.Array.Reverse(scoreRank);

        //�����L���O�\��
        for (int i = 0; i < Ranking.Length; i++)
        {
            Ranking[i].text = scoreRank[i].ToString();
        }

        //�����L���O�ۑ�
        for (int i = 0; i < scoreRank.Length; i++)
        {
            PlayerPrefs.SetInt("No" + (i + 1).ToString(), scoreRank[i]);
        }
    }
}
