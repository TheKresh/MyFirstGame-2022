using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// A Player aktualis eletero pontjainak megjelenitese es ha elfogy akkor hozza be a GameOver screent

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;
    [Space]
    [SerializeField] Renderer coreColor;
    [SerializeField] Light coreLight;
    [Space]
    [SerializeField] GameObject gameOverScreen;
    // [SerializeField] TMP_Text uiHPText;

    float speed = 1;

    void Start()
    {
        /* if (uiHPText != null)
            uiHPText.text = $"HP: {health}";*/

        if (coreColor != null)
            coreColor = gameObject.GetComponent<Renderer>();

        if (coreLight != null)
            coreLight = gameObject.GetComponent<Light>();
    }

    void Update()
    {
        ColorChangeFromHP();
    }

    private void ColorChangeFromHP()
    {
        Color blinkColorStart = new Color32(255, 0, 0, 255);
        Color blinkColorEnd = new Color32(0, 0, 0, 255);

        if (health == maxHealth)
        {
            coreColor.material.color = new Color32(0, 255, 90, 255);
            coreLight.color = new Color32(0, 255, 90, 255);
        }

        if (health < maxHealth && health > 3)
        {
            coreColor.material.color = new Color32(255, 255, 0, 255);
            coreLight.color = new Color32(255, 255, 0, 255);
        }

        if (health < 4 && health > 2)
        {
            coreColor.material.color = new Color32(255, 150, 0, 255);
            coreLight.color = new Color32(255, 150, 0, 255);
        }

        if (health < 3 && health > 1)
        {
            coreColor.material.color = new Color32(255, 0, 0, 255);
            coreLight.color = new Color32(255, 0, 0, 255);
        }

        if (health == 1)
        {
            coreColor.material.color = Color32.Lerp(blinkColorStart, blinkColorEnd, Mathf.PingPong(Time.time * speed, 1));
            coreLight.color = Color32.Lerp(blinkColorStart, blinkColorEnd, Mathf.PingPong(Time.time * speed, 1));
        }
        if (health == 0)
        {
            coreColor.material.color = new Color32(0, 0, 0, 255);
            coreLight.enabled = false;
        }
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

        /* if (uiHPText != null)
            uiHPText.text = $"HP: {health}"; */

        if (health == 0)
        {
            if (gameOverScreen != null)
                gameOverScreen.SetActive(true);
        }
    }
}
