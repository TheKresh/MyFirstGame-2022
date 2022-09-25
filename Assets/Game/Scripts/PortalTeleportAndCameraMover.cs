using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Ha a Player erintkezik a Teleport colliderevel, megjelenik az interact gomb keppel kifejezve, ha azt a gombot hosszan lenyomom es betelik a kep,
// akkor aktiv lesz a kovetkezo mapphoz beallitott CameraPos es addig mozog a kamera amig el nem eri azt a poziciot mint  a CameraPos.
// Amikor a kamera elindul teljes mertekben kikapcsolja a Playert, ha a kamera elerte a beallitott poziciot akkor utana visszakapcsolja.

public class PortalTeleportAndCameraMover : MonoBehaviour
{
    [SerializeField] KeyCode interactButton = KeyCode.E;
    [SerializeField] GameObject player;
    [SerializeField] Transform finishPoint;
    [Space]
    [SerializeField] Transform cam;
    [SerializeField] GameObject cameraPos;
    [SerializeField] float cameraMoveSpeed;
    [SerializeField] float cameraRotationSpeed;
    [Space]
    [SerializeField] GameObject interactButtonImage;
    [SerializeField] Image interactButtonFillImage;
    [Space]
    [SerializeField] float chargeTime = 0.7f;
    [SerializeField] float cooldownTime = 1.5f;

    bool isHoldingDown;
    bool interactButtonIsFilled;

    void Start()
    {
        cameraPos.SetActive(false);

        interactButtonImage.SetActive(false);
    }

    void Update()
    {
        HoldButtonPress();
    }


    void FixedUpdate()
    {
        if (cameraPos.activeInHierarchy == true)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, cameraPos.transform.position, cameraMoveSpeed * Time.fixedDeltaTime);
            cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, cameraPos.transform.localRotation, cameraRotationSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (player)
            interactButtonImage.SetActive(true);

        if (player && interactButtonIsFilled == true)
        {
            StartCoroutine("Teleport");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (player)
        {
            interactButtonImage.SetActive(false);
        }
    }

    IEnumerator Teleport()
    {
        interactButtonImage.SetActive(false);
        interactButtonIsFilled = false;
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
    
    void HoldButtonPress()
    {
        if (interactButtonFillImage.isActiveAndEnabled && Input.GetKey(interactButton))
        {
            isHoldingDown = true;

            if (isHoldingDown == true)
            {
                interactButtonFillImage.fillAmount += chargeTime * Time.deltaTime;

                if (interactButtonFillImage.fillAmount == 1f)
                {
                    interactButtonIsFilled = true;
                }
                
                else
                    interactButtonIsFilled = false;
            }
        }
        else
            isHoldingDown = false;

        if (isHoldingDown == false)
        {
            interactButtonFillImage.fillAmount -= cooldownTime * Time.deltaTime;
            
            if (interactButtonFillImage.fillAmount == 0f)
                return;
        }
    }
}
