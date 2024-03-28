using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移処理
/// </summary>
public class SceneChanger : MonoBehaviour
{
    string sceneName; //現在のシーン名

    void Start()
    {
        //シーン名取得
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

    //タイトル画面にいるとき
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

    //操作説明画面にいるとき
    void ExplainScene()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    //リザルト画面にいるとき
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
