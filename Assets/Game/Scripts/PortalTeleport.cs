using System.Collections;
using UnityEngine;

// Ha a Player erintkezik azzal az objet colliderevel amire ezt a scriptet rarakom es lenyomom a beallitott gombot, akkor teleportaljon a finishPoint-nak beallitott obj. poziciojahoz
// Ha lenyomtam a teleport gombjat, akkor a kamera elindul es elkezd befordulni addig amig el nem eri ugyan azt a poziciot mint az elore beallitott transform

// egyelore csak akkor mozog a kamera ha le van nyomva a teleport gomb
// hogyan tudom elerni azt hogy magatol mozogjon amig el nem eri az adott transform poziciojat ?

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] KeyCode teleportButton;
    [SerializeField] GameObject player;
    [SerializeField] Transform finishPoint;
    [Space]
    [SerializeField] Camera cam;
    [SerializeField] Transform cameraPos;
    [SerializeField] float cameraRotationSpeed;

    void OnValidate()
    {
        if (cam == null)
            cam = GetComponent<Camera>();
    }

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
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, cameraPos.transform.position, cameraRotationSpeed * Time.deltaTime);
        cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, cameraPos.localRotation, cameraRotationSpeed * Time.deltaTime);
        yield return new WaitUntil(isReached);
        player.transform.position = new Vector3(
            finishPoint.transform.position.x,
            finishPoint.transform.position.y,
            finishPoint.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        player.isStatic = false;
    }

    // kamera mozgatasahoz kell
    bool isReached()
    {
        if (cam.transform.rotation == cameraPos.localRotation && cam.transform.position == cameraPos.localPosition)
            return true;
        else
            return false;
    }
}
