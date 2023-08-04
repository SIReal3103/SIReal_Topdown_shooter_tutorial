using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image bar;

    public void UpdateHealth(int health, int maxHealth)
    {
        healthText.text = health.ToString() + " / " + maxHealth.ToString();
        bar.fillAmount = (float)health / (float)maxHealth;
    }

    public void UpdateBar(int value, int maxValue, string text)
    {
        healthText.text = text;
        bar.fillAmount = (float)value / (float)maxValue;
    }
}
