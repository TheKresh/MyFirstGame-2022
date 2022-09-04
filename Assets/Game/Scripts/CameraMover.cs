using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ha lenyomtam a teleport gombjat, akkor a kamera elindul es elkezd befordulni addig amig el nem eri ugyan azt a poziciot mint a vegcelnak beallitott transform

public class CameraMover : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform cameraPos;
    [SerializeField] float speed;

    void OnValidate()
    {
        if (cam == null)
            cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, cameraPos.transform.position, speed * Time.fixedDeltaTime);
        cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, cameraPos.localRotation, speed * Time.fixedDeltaTime);
    }
}
