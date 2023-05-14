using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    int span = 7;
    float x;
    [SerializeField] GameObject obj;
    bool create, isSpan, isStop;
    public TimeController timeController;

    void Start()
    {
        isStop = timeController.iswait;
        create = false;
    }

    void Update()
    {
        if(!isSpan)
        {
            StartCoroutine("Span");
        }
        if(create && !isStop)
        {
            x = Random.Range(-3, 3);
            Instantiate(obj, new Vector3(x, -3.3f, 0), Quaternion.identity);
            create = false;
        }
    }

    IEnumerator Span()
    {
        isSpan = true;
        yield return new WaitForSeconds(span);
        create = true;
        isSpan = false;
    }
}
