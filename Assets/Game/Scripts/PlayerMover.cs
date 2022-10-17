using UnityEngine;

// Oldal iranyban mozgatja a Playert, amig levan nyomva az adott gomb, kulonben "lefagyasztja" a Playert.
// Ugrani is tud, adott gomb lenyomasakor, de csak akkor ha a Player collidere erintkezik a "Platform" taggel ellatott GameObjecttel.
// A Player jobb es bal iranyai, a kamera jobb es bal iranyaitol fugg 

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

    void Start()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        PlayerHealth playerHP = gameObject.GetComponentInChildren<PlayerHealth>();
        
        // Rotation lockkal oldom meg, hogy lelassuljon a Player_Ball, ha egyik iranyba sincs mozgatva
        rigidBody.freezeRotation = false;
        if (!Input.GetKey(rightKey) && !Input.GetKey(leftKey) && !Input.GetKey(jumpKey))
            rigidBody.freezeRotation = true;

        if (playerHP.health == 0)
            gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 right = Camera.main.transform.right;
        Vector3 left = right * -1;
        
        // elvileg ForceMode.Impluse helyett ForceMode.Acceleration jobb lenne
        if (Input.GetKey(rightKey))
            rigidBody.AddForce(right * moveSpeed, ForceMode.Acceleration);

        if (Input.GetKey(leftKey))
            rigidBody.AddForce(left * moveSpeed, ForceMode.Acceleration);

        if (!isJumping && Input.GetKey(jumpKey))
            rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Acceleration);
    }

    void OnTriggerStay(Collider collision)
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
    /*  
    void Update()
    {
        Vector3 right = Camera.main.transform.right;
        Vector3 left = Camera.main.transform.right * -1; // vagy siman csak right a "Camera.main.transform.right" helyett, mert felette már meglett hatarozva, hogy mi a "right"

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(left * speed * Time.deltaTime);
    } 
    */
}
