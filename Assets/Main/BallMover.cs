using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode jumpKey;
    [Space]
    [SerializeField] float moveSpeed = 10;
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] float verticalVelocity;
    [SerializeField] float gravityForce = 20;
    [SerializeField] float jumpForce = 10;

    float speed = 1;
    void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 velocity = GetInputVector();

        rigidBody.velocity = velocity.normalized * moveSpeed;

        // verticalVelocity = (-gravityForce * Time.deltaTime) / 2;  // ha a padlon van, akkor is hat ra a gravitacio
       
        if (Input.GetKeyDown(jumpKey))
        {
            verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity -= gravityForce * Time.deltaTime;
        }
        Vector3 moveVector = new Vector3(0, verticalVelocity * Time.deltaTime, 0);
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
