using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    [SerializeField] GameObject player;
    [Space]
    [SerializeField] GameObject lampLight;
    [SerializeField] Renderer lampBulbCovers;
    [Space]
    [SerializeField] GameObject secretRoom;

    void Start()
    {
        secretRoom.SetActive(false);
        lampLight.SetActive(false);
    }

    void OnTriggerEnter (Collider col)
    {
        if (player)
        {
            secretRoom.SetActive(true);
            lampLight.SetActive(true);
            lampBulbCovers.material.EnableKeyword("_EMISSION");

            Destroy(gameObject);
        }
    }
}
