using System.Collections;
using UnityEngine;

// Ha a Player erintkezik azzal az objet colliderevel amire ezt a scriptet rarakom es lenyomom a beallitott gombot, akkor teleportaljon a finishPoint-nak beallitott obj. poziciojahoz.
// Ha lenyomtam a teleport gombjat, akkor a kamera elindul es elkezd befordulni addig, amig el nem eri ugyan azt a poziciot mint az elore beallitott pont GameObjective (cameraPos).
// Kamera csak akkor mozoghat, ha aktiv az adott elerni kivant GameObject (cameraPos).

// Kamera elforgatas mukodik, viszont azt nem tudtam megoldani, hogy a player mozgasanak iranyai a kamera lokalis tengelyeitol fuggjon

public class PortalTeleportAndCameraMover : MonoBehaviour
{
    [SerializeField] KeyCode teleportButton = KeyCode.E;
    [SerializeField] GameObject player;
    [SerializeField] Transform finishPoint;
    [Space]
    [SerializeField] Transform cam;
    [SerializeField] GameObject cameraPos;
    [SerializeField] float cameraMoveSpeed;
    [SerializeField] float cameraRotationSpeed;
    [Space]
    [SerializeField] GameObject interactButtonImage;

    void Start()
    {
        cameraPos.SetActive(false);

        interactButtonImage.SetActive(false);
    }


    void FixedUpdate()
    {
        if (cameraPos.active == true)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, cameraPos.transform.position, cameraMoveSpeed * Time.fixedDeltaTime);
            cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, cameraPos.transform.localRotation, cameraRotationSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (player)
            interactButtonImage.SetActive(true);

        if (player && Input.GetKey(teleportButton))
        {
            StartCoroutine("Teleport");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (player)
            interactButtonImage.SetActive(false);
    }

    IEnumerator Teleport()
    {
        
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        cameraPos.SetActive(true);
        yield return new WaitUntil(camPositionReached);
        cameraPos.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        player.transform.position = new Vector3(
            finishPoint.transform.position.x,
            finishPoint.transform.position.y,
            finishPoint.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        player.gameObject.SetActive(true);
    }

    bool camPositionReached()
    {
        if (cam.transform.position == cameraPos.transform.position && cam.transform.rotation == cameraPos.transform.localRotation)
            return true;
        else
            return false;
    }
}
