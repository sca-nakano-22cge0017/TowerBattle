using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Rigidbody2D rbody;
    bool isKey;

    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        rbody.simulated = false;
        isKey = false;
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
        }
        if(isKey)
        {
            rbody.simulated = true;
            isKey = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
