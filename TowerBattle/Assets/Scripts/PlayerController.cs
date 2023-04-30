using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Rigidbody2D rbody;
    bool isKey, isSpown;

    [SerializeField] GameObject[] obj;
    Rigidbody2D objBody0, objBody1, objBody2, objBody3, objBody4, objBody5;
    int ran, num;

    void Start()
    {
        ran = Random.Range(0, obj.Length);
        Instantiate(obj[ran], new Vector3(0, 3.5f, 0), Quaternion.identity);

        rbody = this.GetComponent<Rigidbody2D>();
        rbody.simulated = false;

        num = obj.Length;
        /*for(int i = 0; i <= num; i++)
        {
            objBody[i] = obj[i].GetComponent<Rigidbody2D>();
            objBody[i].simulated = false;
        }*/
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
        isSpown = false;
    }

    void Update()
    {
        Transform playerTransform = this.transform;
        Vector2 pos = playerTransform.position;

        if(Input.GetKey(KeyCode.A))
        {
            pos.x -= moveSpeed * Time.deltaTime;
            playerTransform.position = pos;
        }
        if(Input.GetKey(KeyCode.D)) {
            pos.x += moveSpeed * Time.deltaTime;
            playerTransform.position = pos;
        }
        if(Input.GetKey(KeyCode.Return))
        {
            isKey = true;
            isSpown = true;
        }
        if(isKey)
        {
            rbody.simulated = true;
            if(isSpown)
            {
                ran = Random.Range(0, obj.Length);
                Instantiate(obj[ran], new Vector3(0, 3.5f, 0), Quaternion.identity);
                isSpown = false;
            }

            isKey = false;
        }
    }

    void OnColliderEnter2D(Collision2D collision)
    {

    }
}
