using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���J�ڏ���
/// </summary>
public class SceneChanger : MonoBehaviour
{
    string sceneName; //���݂̃V�[����

    void Start()
    {
        //�V�[�����擾
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        switch (sceneName)
        {
            case "TitleScene":
                TitleScene();
                break;
            case "ExplainScene":
                ExplainScene();
                break;
            case "ResultScene":
                ResultScene();
                break;
        }
    }

    //�^�C�g����ʂɂ���Ƃ�
    void TitleScene()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("ExplainScene");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.E))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    //���������ʂɂ���Ƃ�
    void ExplainScene()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    //���U���g��ʂɂ���Ƃ�
    void ResultScene()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
