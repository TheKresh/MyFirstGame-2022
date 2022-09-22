using UnityEngine;

// Oldal iranyban mozgatja a Playert, amig levan nyomva az adott gomb, kulonben "lefagyasztja" a Playert
// Ugrani is tud, adott gomb lenyomasakor, de csak akkor ha a Player collidere erintkezik a platformmal

public class PlayerMover : MonoBehaviour
{
    [SerializeField] KeyCode rightKey = KeyCode.D;
    [SerializeField] KeyCode leftKey = KeyCode.A;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [Space]
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpForce = 60f;     
    [Space]
    [SerializeField] Rigidbody rigidBody;

    bool isJumping;
    string button;


    void Start()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerHealth playerHP = gameObject.GetComponentInChildren<PlayerHealth>();

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

        if (playerHP.health == 0)
            gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        rigidBody.freezeRotation = false;

        if (button == "right")
            rigidBody.AddForce (new Vector3(moveSpeed, 0f, 0f), ForceMode.Impulse);
        
        else if (button == "left")
            rigidBody.AddForce(new Vector3(-moveSpeed, 0f, 0f), ForceMode.Impulse);
        
        else if (!isJumping && button == "jump")
            rigidBody.AddForce (new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        
        else
            rigidBody.freezeRotation = true;
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

    // Csabatol kapott segitseg script resz
    // Player iranyai ennek a segitsegevel a kamera iranyaitol fog fuggni
    
    /* [SerializeField] float speed = 10f;

    void Update()
    {
        Vector3 right = Camera.main.transform.right;
        Vector3 left = right * -1;

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(left * speed * Time.deltaTime);
    } */
}
