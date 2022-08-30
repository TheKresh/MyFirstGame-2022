using System.Collections;
using UnityEngine;

// Ha a Player erintkezik azzal az objet colliderevel amire ezt a scriptet rarakom es lenyomom a beallitott gombot, akkor teleportaljon a B-nek beallitott obj. poziciojahoz

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] KeyCode teleportButton;
    [SerializeField] GameObject player;
    [SerializeField] Transform finishpoint;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKey(teleportButton))
        {
            StartCoroutine("Teleport");
        }
    }

    IEnumerator Teleport()
    {
        player.isStatic = true;
        yield return new WaitForSeconds(0.1f);
        player.transform.position = new Vector3(
            finishpoint.transform.position.x,
            finishpoint.transform.position.y,
            finishpoint.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        player.isStatic = false;
    }
}
