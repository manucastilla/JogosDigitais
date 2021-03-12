// https://www.youtube.com/watch?v=BLfNP4Sc_iA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    GameManager gm;

    void Awake()
    {
        gm = GameManager.GetInstance();
    }
    public void SetMaxHealth()
    {
        slider.maxValue = gm.health;
        slider.value = gm.health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}