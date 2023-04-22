using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;

    void Start()
    {
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.WithTag("Ground"))
        {
            Debug.Log("衝突");
        }*/
        Debug.Log("syoutotu");
    }
}
