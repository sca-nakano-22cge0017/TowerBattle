using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// îöíeê∂ê¨
/// </summary>
public class ObstacleSpawn : MonoBehaviour
{
    int span;
    float xPos, timer;
    [SerializeField] GameObject obj;
    bool create, isSpan;

    [SerializeField] int posMin = -3;
    [SerializeField] int posMax = 3;
    [SerializeField] int timeSpanMin = 5;
    [SerializeField] int timeSpanMax = 10;

    [SerializeField] TimeController timeController;

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
            //ê∂ê¨
            xPos = Random.Range(posMin, posMax);
            Instantiate(obj, new Vector3(xPos, -3.3f, 0), Quaternion.identity);
            create = false;
        }
    }

    /// <summary>
    /// àÍíËä‘äuñàÇ…ê∂ê¨
    /// </summary>
    IEnumerator Span()
    {
        isSpan = true;
        span = Random.Range(timeSpanMin, timeSpanMax);

        yield return new WaitForSeconds(span);

        create = true;
        isSpan = false;
    }
}
