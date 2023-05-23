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
        obj.SetActive(false);
        col = obj.GetComponent<Collider2D>();
        col.enabled = false;
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
            obj.SetActive(true);
            col.enabled = true;
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            StartCoroutine("objDestroy");
        }
    }

    IEnumerator objDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
