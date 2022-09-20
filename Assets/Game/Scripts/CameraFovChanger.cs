using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFovChanger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera cam;

    void OnTriggerStay(Collider col)
    {
        if (player)
            cam.fieldOfView = 38.3f;
    }

    void OnTriggerExit(Collider other)
    {
        if (player)
            cam.fieldOfView = 26.9f;
    }
}
