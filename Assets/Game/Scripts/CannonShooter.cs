using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    [SerializeField] KeyCode shoot;

    [SerializeField] Transform startPos;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed = 1;

    // bool isExist;

    void FixedUpdate()
    {
        if (Input.GetKey(shoot))
        {
            GameObject newBullet = Instantiate(bullet); // kodbol GameObjectet hozunk letre

            newBullet.transform.position = startPos.position;

            Rigidbody rigidBody = newBullet.GetComponent<Rigidbody>();

            rigidBody.AddForce(new Vector3(-speed, 0, 0), ForceMode.Force);
        }
    }
}
