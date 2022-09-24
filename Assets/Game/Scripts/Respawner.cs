using System.Collections;
using UnityEngine;

// vegul ugy dontottem hogy nem hasznalom, helyette restart scriptet csinaltam

// Akarhol is legyek akarmelyik mappon, ha lenyomtam az adott beallitott gombot, (egyelore meg csak) egy beallitott pontra visszateleportal

public class Respawner : MonoBehaviour
{
    [SerializeField] KeyCode respawnButton;
    [SerializeField] Transform respawnPoint;
    [Space]
    [SerializeField] Transform cam;
    [SerializeField] GameObject cameraPos;
    [SerializeField] float cameraMoveSpeed;

    void Start()
    {
        cameraPos.SetActive(false);
    }


    void FixedUpdate()
    {
        if (cameraPos.activeInHierarchy == true)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, cameraPos.transform.position, cameraMoveSpeed * Time.fixedDeltaTime);
        }
    }

    void Update()
    {
        if (Input.GetKey(respawnButton))
            StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        gameObject.isStatic = true; 
        yield return new WaitForSeconds(0.1f);
        cameraPos.SetActive(true);
        yield return new WaitUntil(camPositionReached);
        cameraPos.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = new Vector3(
            respawnPoint.transform.position.x,
            respawnPoint.transform.position.y,
            respawnPoint.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        gameObject.isStatic = false;
    }

    bool camPositionReached()
    {
        if (cam.transform.position == cameraPos.transform.position)
            return true;
        else
            return false;
    }
}
