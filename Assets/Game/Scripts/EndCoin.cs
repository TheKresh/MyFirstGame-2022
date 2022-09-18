using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCoin : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject uICanvas;
    [SerializeField] GameObject endScreen;
    
    void OnTriggerEnter(Collider col)
    {
        if(player)
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
