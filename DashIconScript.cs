using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DashIconScript : MonoBehaviour
{
    public Image Icon;
    public MovementScript movement;
    float lerpspeed;
    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
        Icon.fillAmount = 0;
        lerpspeed = movement.dashCooldown;

    }

    // Update is called once per frame
    void Update()
    {
        lerpspeed = movement.dashCooldown;
        Icon.fillAmount = Mathf.MoveTowards(Icon.fillAmount, 1, Time.deltaTime/ lerpspeed);
        ColorChanger();
    }
    void ColorChanger()
    {
        Color IconColor = Color.Lerp(Color.black, Color.white, Icon.fillAmount);
        Icon.color = IconColor;
    }
}
