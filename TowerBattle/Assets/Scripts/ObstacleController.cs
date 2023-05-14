using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public ScoreController scoreController;
    [SerializeField] GameObject obj;
    Collider2D col;

    void Start()
    {
        col = obj.GetComponent<Collider2D>();
        col.enabled = false;
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Vanish")
        {
            col.enabled = true;
            scoreController.Erace();
            StartCoroutine("objDestroy");
            //Destroy(gameObject);
        }

        if(collision.gameObject.tag == "ScoreDown")
        {
            scoreController.ScoreDown();
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Vanish")
        {
            col.enabled = true;
            scoreController.Erace();
            StartCoroutine("objDestroy");
            Destroy(gameObject);
        }
    }

    IEnumerator objDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
