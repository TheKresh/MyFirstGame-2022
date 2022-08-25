using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode jumpKey;
    [Space]
    [SerializeField] float acceleration = 9.81f;
    [SerializeField] float jumpVelocity = 1;

    float speed = 0;

    void FixedUpdate()
    {
        speed -= acceleration * Time.fixedDeltaTime;
    }
    void Update()
    {

    }
    Vector3 GetInputVector()
    {
        bool right = Input.GetKey(rightKey);
        bool left = Input.GetKey(leftKey);
        bool jump = Input.GetKey(jumpKey);

        float x = ToAxis(right, left);

        Vector3 velocity = new Vector3(x, 0, 0);
        return velocity;
    }

    float ToAxis(bool positive, bool negative)
    {
        float value;
        if (positive)
        {
            value = 1;
        }
        else if (negative)
        {
            value = -1;
        }
        else
        {
            value = 0;
        }
        return value;
    }
}
