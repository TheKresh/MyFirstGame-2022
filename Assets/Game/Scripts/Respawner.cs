using System.Collections;
using UnityEngine;

// Akarhol is legyek akarmelyik mappon, ha lenyomtam az adott beallitott gombot, (egyelore meg csak) az adott beallitott pontra respawnol

public class Respawner : MonoBehaviour
{
    [SerializeField] KeyCode respawnButton;
    [SerializeField] Transform respawnPoint;

    void Update()
    {
        if (Input.GetKey(respawnButton))
            StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        gameObject.isStatic = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(
            respawnPoint.transform.position.x,
            respawnPoint.transform.position.y,
            respawnPoint.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        gameObject.isStatic = false;
    }
}
