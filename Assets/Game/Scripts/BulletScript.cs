using UnityEngine;

// Mozgatja a lovedeket, majd beallitott ido mulva megsemmisiti a lovedeket

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float destroyTime;
    [SerializeField] Rigidbody rigidBody;

    void Update()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.up * speed;
        Destroy(gameObject, destroyTime);
    }
}
