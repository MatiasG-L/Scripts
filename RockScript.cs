using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public float Health = 100f;
    public GameObject StoneDrop;
    public Animator Animation;
    public GameObject IronDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0 && gameObject.tag == "Rock")
        {
            Instantiate(StoneDrop, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        if (Health <= 0 && gameObject.tag == "iron")
        {
            Instantiate(IronDrop, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
    public void Shakey()
    {

        Animation.SetTrigger("Hit");

    }
}
