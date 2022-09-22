using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Beallithato pontok kozott mozgatja a platformot

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform platformPos1;
    [SerializeField] Transform platformPos2;
    [SerializeField] float velocity;
    [SerializeField] Rigidbody rigidBody;

    Vector3 moveTo;

    void Start()
    {
        transform.position = startPos.position;
    }

    void Update()
    {
        if (rigidBody.position == platformPos1.position)
            moveTo = platformPos2.position;
        if (rigidBody.position == platformPos2.position)
            moveTo = platformPos1.position;

        rigidBody.position = Vector3.MoveTowards(rigidBody.position, moveTo, velocity * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(platformPos1.position, platformPos2.position);
    }
}
