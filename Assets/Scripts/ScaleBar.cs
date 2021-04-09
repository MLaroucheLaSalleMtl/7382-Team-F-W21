using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScaleBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(true);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponent<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
   
    void Update()
    {
        
    }
}
