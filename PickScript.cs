using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickScript : MonoBehaviour
{
    public GameObject Rock;
    public RockScript RockSc;
    public MovementScript movement;
    private int randMin = 1;
    private int randMax = 5;
    // Start is called before the first frame update
    void Start()
    {
        RockSc = GameObject.FindGameObjectWithTag("Rock").GetComponent<RockScript>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
       
            if (movement.equip == 2)
            {
                randMax = 5;
                randMin = 1;
            }
            else if (movement.equip == 4)
            {
                randMax =3;
                randMin = 10;
            }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RockSc = collision.gameObject.GetComponent<RockScript>();
        if (collision.gameObject.layer == 8)
        {
            RockSc.Health -= Random.Range(randMin, randMax);
            RockSc.Shakey();

        }

    }
}
