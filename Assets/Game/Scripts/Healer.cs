using UnityEngine;

// Ezzel a scripttel beallithato az adott gyogyito targy erteke

public class Healer : MonoBehaviour
{
    public int heal = 1;

    void OnTriggerEnter(Collider col)
    {
        PlayerHealth hp = col.gameObject.GetComponent<PlayerHealth>();

        if (col.gameObject.tag == "Damagable" && hp.health < hp.maxHealth)
            Destroy(gameObject);
    }
}
