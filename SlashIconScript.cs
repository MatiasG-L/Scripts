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
        lerpspeed = movement.supSlashCooldown;

    }

    // Update is called once per frame
    void Update()
    {
        lerpspeed = movement.supSlashCooldown;
        Icon.fillAmount = Mathf.MoveTowards(Icon.fillAmount, 1, Time.deltaTime / lerpspeed);
        
        if (Icon.fillAmount < 1)
        {
            Icon.color = Color.gray * 0.8f;
        }
        else
        {
            Icon.color = Color.white;
        }
    }

    }
