using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject shieldTextInControls;
    [SerializeField] GameObject PopUpMessage;

    void OnTriggerEnter(Collider col)
    {
        if(player)
        {
            shieldTextInControls.SetActive(true);

            if (PopUpMessage != null)
                PopUpMessage.SetActive(true);

            Destroy(gameObject);
        }
    }
}
