using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] KeyCode shieldKey = KeyCode.F;
    [Space]
    [SerializeField] Collider playersCoreCollider;
    [SerializeField] GameObject shieldItem;
    [SerializeField] GameObject shield;

    void Update()
    {
        if (shieldItem != null)
            return;

        else if (shieldItem == null)
        {
            if (Input.GetKeyDown(shieldKey))
            {
                playersCoreCollider.enabled = false;
                shield.gameObject.SetActive(true);
            }

            if (Input.GetKeyUp(shieldKey))
            {
                shield.gameObject.SetActive(false);
                playersCoreCollider.enabled = true;
            }
        }
    }
}
