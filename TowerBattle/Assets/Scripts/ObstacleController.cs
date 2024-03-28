using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 爆弾制御
/// </summary>
public class ObstacleController : MonoBehaviour
{
    ScoreController scoreController;
    [SerializeField, Header("爆破範囲")] GameObject obj;
    Collider2D col;

    void Start()
    {
        scoreController = GameObject.FindObjectOfType<ScoreController>();

        obj.SetActive(false);
        col = obj.GetComponent<Collider2D>();
        col.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面から落下したらスコア減少
        if(collision.gameObject.tag == "ScoreDown")
        {
            scoreController.ScoreDown();
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //消える図形に触れていたら
        if (collision.gameObject.tag == "Vanish")
        {
            //爆破範囲のColliderをオンにする
            obj.SetActive(true);
            col.enabled = true;

            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            StartCoroutine("objDestroy");
        }
    }

    /// <summary>
    /// オブジェクト破壊
    /// </summary>
    IEnumerator objDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
