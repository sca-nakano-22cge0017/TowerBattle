using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    bool isKey, coolTime, isFall, isGuageMove;

    [SerializeField] GameObject[] obj;
    Rigidbody2D[] objBody;
    int ran, num;
    [SerializeField] Image guage;
    [SerializeField] float incSpeed, decSpeed;
    [SerializeField] Text FeverTime;
    bool isFever;
    float cooltime = 1f;

    void Start()
    {
        StartCoroutine("wait");

        ran = Random.Range(0, obj.Length);
        Instantiate(obj[ran], new Vector3(0, 3.5f, 0), Quaternion.identity);

        num = obj.Length;

        for (int i = 0; i < obj.Length; i++)
        {
            objBody[i] = obj[i].GetComponent<Rigidbody2D>();
            objBody[i].simulated = false;
        }
        
        isKey = false;
        coolTime = false;
        isFall = false;
        isGuageMove = false;

        guage.fillAmount = 0;
        isFever = false;
        FeverTime.enabled = false;
    }

    void Update()
    {
        if(!coolTime && isFall) {
            StartCoroutine("CoolTime");
        }
        if(isKey) {
            ran = Random.Range(0, obj.Length);
            Instantiate(obj[ran], new Vector3(0, 3.5f, 0), Quaternion.identity);
            isKey = false;
        }

        if(isGuageMove) {
            if(guage.fillAmount <= 1 && !isFever) {
                guage.fillAmount += incSpeed * Time.deltaTime;
                cooltime = 1f;
                FeverTime.enabled = false;
            }

            if(guage.fillAmount >= 1) {
                isFever = true;
            }

            if(guage.fillAmount >= 0 && isFever) {
                guage.fillAmount -= decSpeed * Time.deltaTime;
                cooltime = 0.5f;
                FeverTime.enabled = true;
            }

            if(guage.fillAmount <= 0) {
                isFever = false;
            }
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(4);
        isGuageMove = true;
    }

    IEnumerator CoolTime() {
        coolTime = true;
        yield return new WaitForSeconds(cooltime);
        isKey = true;
        isFall = false;
        coolTime = false;
    }

    public void IsFall()
    {
        isFall = true;
    }
}
