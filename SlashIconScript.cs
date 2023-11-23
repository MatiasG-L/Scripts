using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SlashIconScript : MonoBehaviour
{
    public Image Icon;
    private MovementScript movement;
    public float lerpspeed;
    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
        Icon.fillAmount = 0;
        lerpspeed = 0.1f * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        Icon.fillAmount = Mathf.Lerp(Icon.fillAmount, 1, lerpspeed);
        ColorChanger();
    }
    void ColorChanger()
    {
        Color IconColor = Color.Lerp(Color.black, Color.white, Icon.fillAmount);
        Icon.color = IconColor;
    }
}
