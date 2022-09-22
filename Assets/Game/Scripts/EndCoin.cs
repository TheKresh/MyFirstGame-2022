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
    [SerializeField] GameObject interactButtonImage;

    void Start()
    {
        interactButtonImage.SetActive(false);
    }

    void OnTriggerStay(Collider col)
    {
        if (player)
            interactButtonImage.SetActive(true);

        if (player && Input.GetKey(pickUpButton))
        {
            player.gameObject.SetActive(false);

            if (uICanvas != null)
                uICanvas.SetActive(false);

            if (endScreen != null)
                endScreen.SetActive(true);

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
