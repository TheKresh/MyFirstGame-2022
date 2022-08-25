using UnityEngine;

// lehet ugrani es mozog jobbra-balra, de tul lassan zuhan

public class BallMover : MonoBehaviour
{
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode jumpKey;
    [Space]
    [SerializeField] float speed = 1;
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] float acceleration = 9.81f;
    [SerializeField] float jumpVelocity = 1;
    float jumpSpeed = 0;

    void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        jumpSpeed -= acceleration * Time.fixedDeltaTime;
    }
    void Update()
    {
        Vector3 velocity = GetInputVector();

        rigidBody.velocity = velocity.normalized * speed;

        if (Input.GetKeyDown(jumpKey))
        {
            jumpSpeed += jumpVelocity;
            transform.position += new Vector3(0, jumpSpeed * Time.deltaTime, 0);
        }
    }
    Vector3 GetInputVector()
    {
        bool right = Input.GetKey(rightKey);
        bool left = Input.GetKey(leftKey);

        float x = ToAxis(right, left);

        Vector3 velocity = new Vector3(x, 0, 0);
        return velocity;
    }

    float ToAxis(bool positive, bool negative)
    {
        float value;
        if (positive)
            value = 1;
        else if (negative)
            value = -1;
        else
            value = 0;
        return value;
    }
}
