using UnityEngine;

// Nem mukodik rendesen

public class BallMover : MonoBehaviour
{
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode jumpKey;
    [Space]
    [SerializeField] Rigidbody rigidBody;
    [Space]
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpForce = 10;
    void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 velocity = GetInputVector();

        rigidBody.velocity = velocity.normalized * moveSpeed;

        if (Input.GetKeyDown(jumpKey))
        {
            transform.position += new Vector3(0,jumpForce * Time.deltaTime, 0);
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
