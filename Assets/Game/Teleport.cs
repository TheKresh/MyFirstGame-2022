using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ha a Player erintkezik azzal az objettel amire ezt a scriptet rarakom, akkor teleportaljon a B-nek beallitott obj. poziciojahoz

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject player;
    // [SerializeField] Transform a;
    [SerializeField] Transform b;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("Tp");
        }
    }

    IEnumerator Tp()
    {
        player.isStatic = true;
        yield return new WaitForSeconds(0.1f);
        player.transform.position = new Vector3(
            b.transform.position.x,
            b.transform.position.y,
            b.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        player.isStatic = false;
    }
}
