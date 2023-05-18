using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    bool isKey, coolTime, isFall;

    [SerializeField] GameObject[] obj;
    Rigidbody2D objBody0, objBody1, objBody2, objBody3, objBody4, objBody5;
    Rigidbody2D[] objBody;
    int ran, num;

    void Start()
    {
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
