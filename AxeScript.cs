using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public GameObject tree;
    public TreeScript treeSc;
    public MovementScript movement;
    private int randMin = 1;
    private int randMax = 5;
    // Start is called before the first frame update
    void Start()
    {
        treeSc = GameObject.FindGameObjectWithTag("Tree").GetComponent<TreeScript>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
     if(movement.equip  == 1)
        {
            randMax = 5;
            randMin = 1;
        }
        else if(movement.equip == 3)
        {
            randMax = 10;
            randMin = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        treeSc = collision.gameObject.GetComponent<TreeScript>();
        if (collision.gameObject.layer == 3)
        {
            treeSc.Health -= Random.Range(randMin, randMax);
            treeSc.Shakey();
            
        }

    }
}
