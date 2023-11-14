using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public float Health = 100;
    public GameObject WoodDrop;
    public Animator Tree;
    public GameObject TreeSelf;
    public CapsuleCollider2D CapCol;
    // Start is called before the first frame update
    void Start()
    {

        //   Tree = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Tree = GetComponentInChildren<Animator>();
        if (Health <= 0)
        {
            Instantiate(WoodDrop,transform.position,transform.rotation);
            Destroy(gameObject); 
           
        }
      

    }

    public void Shakey()
    {

        Tree.SetTrigger("Hit");

    }


}
