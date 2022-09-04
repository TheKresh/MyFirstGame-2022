using System.Collections;
using UnityEngine;

// Ha a Player erintkezik azzal az objet colliderevel amire ezt a scriptet rarakom es lenyomom a beallitott gombot, akkor teleportaljon a finishPoint-nak beallitott obj. poziciojahoz
// Ha lenyomtam a teleport gombjat, akkor a kamera elindul es elkezd befordulni addig amig el nem eri ugyan azt a poziciot mint az elore beallitott transform

public class PortalTeleportAndCameraMover : MonoBehaviour
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

    // Megcsinálni, hogy ha lenyomtam a teleport gombot/player collidere elhagyta az adott collidert akkor kapcsolja be a cameraPos transformot
    // Csak akkor forogjon el a kamera ha bevan kapcsolva a cameraPos transform
    void FixedUpdate()
    {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, cameraPos.transform.position, cameraRotationSpeed * Time.fixedDeltaTime);
        cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, cameraPos.localRotation, cameraRotationSpeed * Time.fixedDeltaTime);
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
        player.transform.position = new Vector3(
            finishPoint.transform.position.x,
            finishPoint.transform.position.y,
            finishPoint.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        player.isStatic = false;
    }
}
