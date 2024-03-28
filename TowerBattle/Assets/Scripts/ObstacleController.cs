using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���e����
/// </summary>
public class ObstacleController : MonoBehaviour
{
    ScoreController scoreController;
    [SerializeField, Header("���j�͈�")] GameObject obj;
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
        //�n�ʂ��痎��������X�R�A����
        if(collision.gameObject.tag == "ScoreDown")
        {
            scoreController.ScoreDown();
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //������}�`�ɐG��Ă�����
        if (collision.gameObject.tag == "Vanish")
        {
            //���j�͈͂�Collider���I���ɂ���
            obj.SetActive(true);
            col.enabled = true;

            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            StartCoroutine("objDestroy");
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g�j��
    /// </summary>
    IEnumerator objDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
