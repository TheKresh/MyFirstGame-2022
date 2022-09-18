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

    float intensity;
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
        Color blinkColorStart = Color.red;
        Color blinkColorEnd = Color.black;

        intensity = 2;

        if (health == maxHealth)
        {
            coreColor.material.SetColor("_EmissionColor", Color.green * intensity);
            coreLight.color = new Color32(0, 255, 90, 255);
        }

        if (health < maxHealth && health > 3)
        {
            coreColor.material.SetColor("_EmissionColor", new Color(1,1,0) * intensity);
            coreLight.color = new Color32(255, 255, 0, 255);
        }

        if (health < 4 && health > 2)
        {
            coreColor.material.SetColor("_EmissionColor", new Color(1, 0.5f, 0) * intensity);
            coreLight.color = new Color32(255, 150, 0, 255);
        }

        if (health < 3 && health > 1)
        {
            coreColor.material.SetColor("_EmissionColor", Color.red * intensity);
            coreLight.color = new Color32(255, 0, 0, 255);
        }

        if (health == 1)
        {
            Color changeBetweenTwoColor = Color32.Lerp(blinkColorStart, blinkColorEnd, Mathf.PingPong(Time.time * speed, 1));
            coreColor.material.SetColor("_EmissionColor", changeBetweenTwoColor * intensity);
            coreLight.color = Color32.Lerp(blinkColorStart, blinkColorEnd, Mathf.PingPong(Time.time * speed, 1));
        }
        if (health == 0)
        {
            coreColor.material.SetColor("_EmissionColor", new Color(0, 0, 0));
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
