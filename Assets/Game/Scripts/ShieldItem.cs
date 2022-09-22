using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    [SerializeField] KeyCode pickUpButton = KeyCode.E;
    [Space]
    [SerializeField] GameObject player;
    [SerializeField] GameObject shieldTextInControls;
    [SerializeField] GameObject PopUpMessage;
    [SerializeField] GameObject interactButtonImage;

    void Start()
    {
        interactButtonImage.SetActive(false);
    }

    void OnTriggerStay(Collider col)
    {
        if (player)
            interactButtonImage.SetActive(true);

        if(player && Input.GetKey(pickUpButton))
        {
            shieldTextInControls.SetActive(true);

            if (PopUpMessage != null)
                PopUpMessage.SetActive(true);

            interactButtonImage.SetActive(false);
            
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (player)
            interactButtonImage.SetActive(false);
    }
}
