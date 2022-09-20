using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    [SerializeField] GameObject player;
    [Space]
    [SerializeField] GameObject lampLight;
    [SerializeField] Renderer lampBulbCovers;

    void OnTriggerEnter (Collider col)
    {
        if (player)
        {
            lampLight.SetActive(true);
            lampBulbCovers.material.EnableKeyword("_EMISSION");

            Destroy(gameObject);
        }
    }
}
