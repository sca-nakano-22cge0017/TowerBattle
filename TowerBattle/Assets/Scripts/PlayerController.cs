using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Rigidbody2D rbody;
    Collider2D col;
    bool isCol, isPlayable, isWait;
    public ScoreController scoreController;
    public MainGameManager mainGameManager;
    public TimeController timeController;
    enum SCORE_STATE {BASIC = 0, NORMAL, SPECIAL,}
    SCORE_STATE scoreState = 0;
    
    float time = 0;

    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<Collider2D>();
        rbody.simulated = false;
        isCol = false;
        isPlayable = true;
        time = 0f;
    }

    void Update()
    {
        isWait = timeController.iswait;

        Transform playerTransform = this.transform;
        Vector2 pos = playerTransform.position;

        if(isPlayable && !isWait) 
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
                isPlayable = false;
                rbody.simulated = true;
                mainGameManager.IsFall();
                StartCoroutine("scoreUp");
            }
        }

        if (time >= 0.2f)
        {
            isCol = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ScoreDown")
        {
            Debug.Log("scoredown");
            scoreController.ScoreDown();
            Destroy(gameObject);
        }
    }

    IEnumerator objDestroy() {
        if (this.gameObject.tag == "Circle" || this.gameObject.tag == "Square")
        {
            col.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
        }
        else
        {
            col.transform.localScale = new Vector3(1.56f, 1.56f, 1f);
        }
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    IEnumerator scoreUp()
    {
        yield return new WaitForSeconds(0.7f);
        scoreState = SCORE_STATE.NORMAL;
    }
}
