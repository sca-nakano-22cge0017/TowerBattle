using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Rigidbody2D rbody;
    bool isCol, isOver;

    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        rbody.simulated = false;
        isCol = false;
        isOver = false;
    }

    void Update()
    {
        Transform playerTransform = this.transform;
        Vector2 pos = playerTransform.position;

        if(this.transform.position.y >= 3.5f) 
        {
            if(Input.GetKey(KeyCode.A)) {
                pos.x -= moveSpeed * Time.deltaTime;
                playerTransform.position = pos;
            }
            if(Input.GetKey(KeyCode.D)) {
                pos.x += moveSpeed * Time.deltaTime;
                playerTransform.position = pos;
            }
            if(Input.GetKeyDown(KeyCode.Return)) {
                rbody.simulated = true;
            }
        }

        if(this.transform.position.y <= -3.0f) {
            isCol = true;
        }

        if(this.transform.position.y <= -7.0f) {
            isOver = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == this.gameObject.tag) {
            Debug.Log("衝突");
            StartCoroutine("objDestroy");
        }
    }

    IEnumerator objDestroy() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
