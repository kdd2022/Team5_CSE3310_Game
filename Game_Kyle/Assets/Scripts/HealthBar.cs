using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Character mycharacter;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = mycharacter.playerMaxHP;
    }
    public void Update()
    {
        
        slider.value = mycharacter.playerHP;
    }

}
