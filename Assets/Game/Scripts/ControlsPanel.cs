using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPanel : MonoBehaviour
{
    [SerializeField] KeyCode controlsKey = KeyCode.C;
    [SerializeField] GameObject controlsCanvas;
    [SerializeField] GameObject forControlsText;


    void Update()
    {
        if(Input.GetKeyDown(controlsKey))
        {
            if (forControlsText != null)
                forControlsText.SetActive(false);

            if (controlsCanvas != null)
                controlsCanvas.SetActive(true);
        }

        if (Input.GetKeyUp(controlsKey))
        {
            if (controlsCanvas != null)
                controlsCanvas.SetActive(false);
         
            if (forControlsText != null)
                forControlsText.SetActive(true);
        }
    }
}
