using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMessages : MonoBehaviour
{
    [SerializeField] KeyCode oKButton = KeyCode.Return;
    [SerializeField] KeyCode closeButton = KeyCode.Escape;
    [SerializeField] GameObject popUpMessage;

    void Update()
    {
        if ((popUpMessage.activeInHierarchy && Input.GetKey(oKButton)) || (popUpMessage.activeInHierarchy && Input.GetKey(closeButton)))
            popUpMessage.SetActive(false);
    }
}