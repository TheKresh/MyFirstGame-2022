using UnityEngine;


// Ez a script rendesen mukodik

public class BallMover2 : MonoBehaviour
{
    /* [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode jumpKey;
    [Space] */
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpForce = 60f;
    [SerializeField] bool isJumping;
    [Space]
    [SerializeField] Rigidbody rigidBody;

    [SerializeField]float moveHorizontal;
    float moveVertical;

    void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
            rigidBody.AddForce(new Vector3(moveHorizontal * moveSpeed, 0f, 0f), ForceMode.Impulse); // AddForce-nal nem kell Time.deltaTime vagy fixedDeltaTime, mert mar alapbol bele van implementalva

        if (!isJumping && moveVertical > 0.1f)
            rigidBody.AddForce(new Vector3(0f, moveVertical * moveSpeed, 0f), ForceMode.Impulse);
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
