using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("落下速度")] float moveSpeed = 5;
    Rigidbody2D rbody;
    Collider2D col;

    bool isCol, isPlayable;

    ScoreController scoreController;
    MainGameManager mainGameManager;
    TimeController timeController;

    enum SCORE_STATE {BASIC = 0, NORMAL, SPECIAL,}
    SCORE_STATE scoreState = 0;
    
    float time = 0;

    void Start()
    {
        scoreController = GameObject.FindObjectOfType<ScoreController>();
        mainGameManager = GameObject.FindObjectOfType<MainGameManager>();
        timeController = GameObject.FindObjectOfType<TimeController>();

        rbody = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<Collider2D>();

        rbody.simulated = false;
        isCol = false;
        isPlayable = true;

        time = 0f;
    }

    void Update()
    {
        Transform playerTransform = this.transform;
        Vector2 pos = playerTransform.position;

        //移動
        if(isPlayable && !timeController.iswait) 
        {
            if(Input.GetKey(KeyCode.A)) {
                pos.x -= moveSpeed * Time.deltaTime;
                playerTransform.position = pos;
            }
            if(Input.GetKey(KeyCode.D)) {
                pos.x += moveSpeed * Time.deltaTime;
                playerTransform.position = pos;
            }

            //エンターキーで落下
            if(Input.GetKeyDown(KeyCode.Return)) {
                isPlayable = false; //操作不可になる
                rbody.simulated = true;
                mainGameManager.IsFall();
            }
        }

        //同じ図形に当たったら
        if (isCol)
        {
            scoreState = SCORE_STATE.SPECIAL;
            StartCoroutine("objDestroy");
            isCol = false;
        }

        //スコア増加処理
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

    void OnCollisionEnter2D(Collision2D collision) {
        //同じタグのobject = 同じ図形に当たったら
        if(collision.gameObject.tag == this.gameObject.tag) {
            isCol = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //地面から落下したらスコア減少処理
        if (collision.gameObject.tag == "ScoreDown")
        {
            scoreController.ScoreDown();
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //爆弾の範囲内にあった場合消去
        if (collision.gameObject.tag == "Judge")
        {
            Destroy(gameObject);
            scoreController.Erace();
        }
    }

    /// <summary>
    /// 図形消去
    /// </summary>
    IEnumerator objDestroy() {

        //消えるときにサイズが大きくなる
        if (this.gameObject.tag == "Circle" || this.gameObject.tag == "Square")
        {
            col.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
        }
        else
        {
            col.transform.localScale = new Vector3(1.56f, 1.56f, 1f);
        }

        //タグの変更　"Vanish"にObstacleが触れるとObstacleの周囲のオブジェクトが消える
        this.gameObject.tag = "Vanish";

        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
