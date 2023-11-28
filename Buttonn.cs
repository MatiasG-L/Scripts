using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonn : MonoBehaviour
{
    public Canvas canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!canvas.gameObject.active)
            {
                canvas.gameObject.SetActive(true);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }
    public void mainMenu()
    {
        canvas.gameObject.SetActive(false);
    }

}
