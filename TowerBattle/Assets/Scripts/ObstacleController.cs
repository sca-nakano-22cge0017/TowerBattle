using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    int span = 10;
    float x, y;
    bool create;

    void Start()
    {
        create = true;
    }

    void Update()
    {
        if(create)
        {
            StartCoroutine("Create");
            create = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Vanish")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Create()
    {
        yield return new WaitForSeconds(span);
        x = Random.Range(-3, 3);
        y = Random.Range(-3.3f, 3);
        Instantiate(this, new Vector3(x, y, 0), Quaternion.identity);
    }
}
