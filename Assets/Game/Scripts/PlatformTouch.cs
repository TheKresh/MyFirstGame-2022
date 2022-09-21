using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Az a problema, hogy magaval viszi a mozgo platform a playert, de ha mozogni akarok akkor szetnyujtja a playert

public class PlatformTouch : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
