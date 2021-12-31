using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

	//sets the max health of the player to the slider
	public void SetMaxHealth(float health)
	{
		slider.maxValue = health;
		slider.value = health;
	}

	//sets the current health of the player to the slider
    public void SetHealth(float health)
	{
		slider.value = health;
	}

} 