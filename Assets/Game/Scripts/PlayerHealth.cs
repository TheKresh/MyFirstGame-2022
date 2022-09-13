using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// A Player aktualis eletero pontjainak megjelenitese es ha elfogy akkor hozza be a GameOver screent

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 5;
    public int health = 5;
    [Space]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TMP_Text uiHPText;

    void Start()
    {
        if (uiHPText != null)
            uiHPText.text = $"HP: {health}";
    }

    void OnTriggerEnter(Collider col)
    {
        Damager damager = col.gameObject.GetComponentInChildren<Damager>();
        Healer healer = col.gameObject.GetComponentInChildren<Healer>();

        if (damager != null && health > 0)
        {
            health = health - damager.damage;
            health = Mathf.Clamp(health, 0, maxHealth);
        }

        if (col.gameObject.tag == "Heal" && health < maxHealth)
            health = health + healer.heal;

        if (uiHPText != null)
            uiHPText.text = $"HP: {health}";

        if (health == 0)
        {
            if (gameOverScreen != null)
                gameOverScreen.SetActive(true);
        }
    }
}
