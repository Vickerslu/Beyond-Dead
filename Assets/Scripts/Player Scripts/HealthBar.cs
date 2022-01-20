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

    // increases the width of the bar. visual prompt to the user that their max health has increased
	public void ExtendBar() {
		RectTransform rt = this.GetComponent<RectTransform>();
		rt.sizeDelta = new Vector2 (rt.rect.width*1.5f, rt.rect.height);
	}

}
