using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    int span;
    float x, timer;
    [SerializeField] GameObject obj;
    bool create, isSpan;
    public TimeController timeController;

    void Start()
    {
        timer = timeController.Timer;
        create = false;
    }

    void Update()
    {
        if(!isSpan)
        {
            StartCoroutine("Span");
        }
        
        if(create && timer != 0)
        {
            x = Random.Range(-3, 3);
            Instantiate(obj, new Vector3(x, -3.3f, 0), Quaternion.identity);
            create = false;
        }
    }

    IEnumerator Span()
    {
        isSpan = true;
        span = Random.Range(5, 10);
        yield return new WaitForSeconds(span);
        create = true;
        isSpan = false;
    }
}
