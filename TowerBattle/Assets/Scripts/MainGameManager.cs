using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// メインゲーム制御
/// </summary>
public class MainGameManager : MonoBehaviour
{
    bool isCreate, coolTime, isFall;

    [SerializeField, Header("生成オブジェクト")] GameObject[] obj;
    Rigidbody2D[] objBody;
    int ran;

    //フィーバーゲージ関連
    [SerializeField] Image guage;
    [SerializeField] float incSpeed, decSpeed;
    [SerializeField] Text FeverTime;
    bool isFever;

    [SerializeField] float cooltime = 1f;

    TimeController timeController;

    void Start()
    {
        timeController = this.GetComponent<TimeController>();

        objBody = new Rigidbody2D[obj.Length];
        for (int i = 0; i < obj.Length; i++)
        {
            objBody[i] = obj[i].GetComponent<Rigidbody2D>();
            objBody[i].simulated = false; //最初落ちないように
        }

        //図形生成
        ran = Random.Range(0, obj.Length);
        Instantiate(obj[ran], new Vector3(0, 3.5f, 0), Quaternion.identity);

        isCreate = false;
        coolTime = false;
        isFall = false;

        guage.fillAmount = 0;
        isFever = false;
        FeverTime.enabled = false;
    }

    void Update()
    {
        //クールタイム解除　落下可能かどうか
        if(!coolTime && isFall) {
            StartCoroutine("CoolTime");
        }

        //ランダム生成
        if (isCreate) {
            ran = Random.Range(0, obj.Length);
            Instantiate(obj[ran], new Vector3(0, 3.5f, 0), Quaternion.identity);
            isCreate = false;
        }

        //ゲージ処理
        if(!timeController.iswait) {
            //フィーバー状態じゃなかったら増加
            if(guage.fillAmount <= 1 && !isFever) {
                guage.fillAmount += incSpeed * Time.deltaTime;
                cooltime = 1f;
                FeverTime.enabled = false;
            }

            //ゲージ最大になったらフィーバー状態に変更
            if(guage.fillAmount >= 1) {
                isFever = true;
            }

            //フィーバー状態になったら減少
            if(guage.fillAmount >= 0 && isFever) {
                guage.fillAmount -= decSpeed * Time.deltaTime;
                cooltime = 0.5f;
                FeverTime.enabled = true;
            }

            //ゲージが0になったらフィーバー状態解除
            if (guage.fillAmount <= 0) {
                isFever = false;
            }
        }
    }

    /// <summary>
    /// クールタイム
    /// </summary>
    IEnumerator CoolTime() {
        coolTime = true;
        yield return new WaitForSeconds(cooltime);

        isCreate = true;

        isFall = false;
        coolTime = false;
    }

    /// <summary>
    /// オブジェクトが落下可能か
    /// </summary>
    public void IsFall()
    {
        isFall = true;
    }
}
