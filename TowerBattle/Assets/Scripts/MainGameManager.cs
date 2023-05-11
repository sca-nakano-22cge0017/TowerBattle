using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    bool isKey, coolTime, isFall;

    [SerializeField] GameObject[] obj;
    Rigidbody2D objBody0, objBody1, objBody2, objBody3, objBody4, objBody5;
    int ran, num;

    void Start()
    {
        ran = Random.Range(0, obj.Length);
        Instantiate(obj[ran], new Vector3(0, 3.5f, 0), Quaternion.identity);

        num = obj.Length;
        objBody0 = obj[0].GetComponent<Rigidbody2D>();
        objBody1 = obj[1].GetComponent<Rigidbody2D>();
        objBody2 = obj[2].GetComponent<Rigidbody2D>();
        objBody3 = obj[3].GetComponent<Rigidbody2D>();
        objBody4 = obj[4].GetComponent<Rigidbody2D>();
        objBody5 = obj[5].GetComponent<Rigidbody2D>();
        objBody0.simulated = false;
        objBody1.simulated = false;
        objBody2.simulated = false;
        objBody3.simulated = false;
        objBody4.simulated = false;
        objBody5.simulated = false;

        isKey = false;
        coolTime = false;
        isFall = false;
    }

    void Update()
    {
        if (!coolTime && isFall) {
            StartCoroutine("CoolTime");
        }
        if(isKey) {
            ran = Random.Range(0, obj.Length);
            Instantiate(obj[ran], new Vector3(0, 3.5f, 0), Quaternion.identity);
            isKey = false;
        }
    }

    IEnumerator CoolTime() {
        coolTime = true;
        yield return new WaitForSeconds(0.5f);
        isKey = true;
        isFall = false;
        coolTime = false;
    }

    public void IsFall()
    {
        isFall = true;
    }
}
