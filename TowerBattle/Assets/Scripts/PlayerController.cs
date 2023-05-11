﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Rigidbody2D rbody;
    Collider2D col;
    bool isOver;
    bool isCol, isMag;
    public ScoreController scoreController;
    public MainGameManager mainGameManager;
    enum SCORE_STATE {BASIC, NORMAL, SPECIAL,}
    SCORE_STATE scoreState = 0;
    float time = 0;

    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<Collider2D>();
        rbody.simulated = false;
        isOver = false;
        isCol = false;
        isMag = false;
        time = 0f;
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
                mainGameManager.IsFall();
                StartCoroutine("scoreUp");
            }
        }

        if (time >= 0.2f)
        {
            isCol = true;
            isMag = true;
            time = 0f;
        }
        if (isCol)
        {
            scoreState = SCORE_STATE.SPECIAL;
            StartCoroutine("objDestroy");
            isCol = false;
        }

        switch (scoreState)
        {
            case SCORE_STATE.BASIC:
            break;
            case SCORE_STATE.NORMAL:
                scoreController.NormalUp();
                scoreState = SCORE_STATE.BASIC;
            break;
            case SCORE_STATE.SPECIAL:
                scoreController.SpecialUp();
                scoreState = SCORE_STATE.BASIC;
            break;
        }

        if(this.transform.position.y <= -7.0f) {
            isOver = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        if(collision.gameObject.tag == this.gameObject.tag) {
            time += Time.deltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.gameObject.tag)
        {
            time = 0f;
        }
    }

    IEnumerator objDestroy() {
        if(isMag)
        {
            if(this.gameObject.tag == "Circle" || this.gameObject.tag == "Square")
            {
                col.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
            }
            else
            {
                col.transform.localScale = new Vector3(1.56f, 1.56f, 1f);
            }
            isMag = false;
        }
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    IEnumerator scoreUp()
    {
        yield return new WaitForSeconds(0.5f);
        scoreState = SCORE_STATE.NORMAL;
    }
}
