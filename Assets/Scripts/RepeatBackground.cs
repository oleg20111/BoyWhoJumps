using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWifth;

    void Start()
    {
        startPos = transform.position;
        repeatWifth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if(transform.position.x < startPos.x - repeatWifth)
        {
            transform.position = startPos;
        }
    }
}
