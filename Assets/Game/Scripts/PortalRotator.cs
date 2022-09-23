using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotator : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float rotateSpeed = 0.5f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed, Space.Self);
    }
}
