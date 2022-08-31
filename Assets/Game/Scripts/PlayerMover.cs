using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] KeyCode rightKey = KeyCode.D;
    [SerializeField] KeyCode leftKey = KeyCode.A;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [Space]
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpForce = 60f;     // 20-as Mass mellett
    [Space]
    [SerializeField] Rigidbody rigidBody;

    bool isJumping;
    string button;

    void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(rightKey))
        {
            button = "right";

            if (Input.GetKey(jumpKey))
                button = "jump";
        }

        else if (Input.GetKey(leftKey))
        {
            button = "left";

            if (Input.GetKey(jumpKey))
                button = "jump";
        }

        else if (Input.GetKey(jumpKey))
            button = "jump";
        
        else
            button = null;
    }

    void FixedUpdate()
    {
        if (button == "right")
            rigidBody.AddForce (new Vector3(moveSpeed, 0f, 0f), ForceMode.Impulse);
        
        else if (button == "left")
            rigidBody.AddForce(new Vector3(-moveSpeed, 0f, 0f), ForceMode.Impulse);
        
        else if (!isJumping && button == "jump")
            rigidBody.AddForce (new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        
        else
            rigidBody.AddForce(new Vector3(0f, 0f, 0f), ForceMode.VelocityChange);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Platform")
            isJumping = false;
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Platform")
            isJumping = true;
    }
}
