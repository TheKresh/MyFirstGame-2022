using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCoin : MonoBehaviour
{
    [SerializeField] KeyCode pickUpButton = KeyCode.E;
    [Space]
    [SerializeField] GameObject player;
    [SerializeField] GameObject uICanvas;
    [SerializeField] GameObject endScreen;
    
    void OnTriggerStay(Collider col)
    {
        if(player && Input.GetKey(pickUpButton))
        {
            player.gameObject.SetActive(false);

            if (uICanvas != null)
                uICanvas.SetActive(false);

            if (endScreen != null)
                endScreen.SetActive(true);

            Destroy(gameObject);
        }
    }
}
