using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScript : MonoBehaviour
{
    public MovementScript movement;
    public Text healthText;
    public Image HealthBar;
    float lerpspeed;
    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float healthLocal = movement.Health;
        healthText.text = "Health: " + Mathf.Lerp(healthLocal, movement.Health, lerpspeed) + "/" + movement.maxHealth;
        Healthbarfiller();
        ColorChanger();
        lerpspeed = 3f * Time.deltaTime;
    }
    
    void Healthbarfiller()
    {
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, movement.Health/ movement.maxHealth, lerpspeed);
       
    }
    void ColorChanger()
    {
        Color healthcolor = Color.Lerp(Color.red, Color.green, movement.Health / movement.maxHealth);
        HealthBar.color = healthcolor;
    }
}
