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

    void OnTriggerStay(Collider col)
    {
        if(player && Input.GetKey(pickUpButton))
        {
            shieldTextInControls.SetActive(true);

            if (PopUpMessage != null)
                PopUpMessage.SetActive(true);

            Destroy(gameObject);
        }
    }
}
