using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Beallithato pontok kozott mozgatja a platformot
public class PlatformMover : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform platformPos1;
    [SerializeField] Transform platformPos2;
    [SerializeField] float speed;

    Vector3 moveTo;

    void Start()
    {
        transform.position = startPos.position;
    }

    void Update()
    {
        if (transform.position == platformPos1.position)
            moveTo = platformPos2.position;
        if (transform.position == platformPos2.position)
            moveTo = platformPos1.position;

        transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(platformPos1.position, platformPos2.position);
    }
}
