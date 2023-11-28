using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("END");
            GameManager.instance.updatePlayerInventory();
            if (gameObject.name == "End") GameManager.instance.GoToScene("LevelSelect");
           
           if (gameObject.name == "RealEnd") GameManager.instance.GoToScene("WIN");
            

        }
    }
}
