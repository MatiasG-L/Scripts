using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlashCooldown : MonoBehaviour
{
    #region singleton
    public static SlashCooldown instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    #endregion
    public Image Icon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double lerpspeed = MovementScript.instance.SlashSpeed;

        transform.localScale = new Vector3(Mathf.MoveTowards(transform.localScale.x, 1, Time.deltaTime / (float)lerpspeed),transform.localScale.y, transform.localScale.x);
        if (transform.localScale.x < 1)
        {
            Icon.color = Color.grey;

        }
        else
        {
            Icon.color = Color.black;
        }

    }
}
