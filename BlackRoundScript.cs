using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRoundScript : MonoBehaviour
{
    public SpriteRenderer SP;

    private void Start()
    {
        SP.color = Color.black;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("frfr");
        if (collision.gameObject.CompareTag("Player"))
        {
            SP.color = Color.clear;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("fr");
        if (collision.gameObject.CompareTag("Player"))
        {
            SP.color = Color.black;
        }
    }



}
