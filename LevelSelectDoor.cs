using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectDoor : MonoBehaviour
{
    public string levelDestination = "null";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GoToScene(levelDestination);
        }
    }
}
