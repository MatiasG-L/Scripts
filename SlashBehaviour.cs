using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBehaviour : MonoBehaviour
{
    public GameObject Player;
    private SpriteRenderer rend;
    private double timerS = 0;
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        rend = GetComponent<SpriteRenderer>();
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<MovementScript>().canJab)
        {
            speed = 1.5f;
        }
        else
        {
            speed = 1f;
        }

        transform.Translate(Quaternion.Euler(0, 0, transform.rotation.z) * new Vector3(10, 0, 0) * speed * Time.deltaTime);

        timerS += Time.deltaTime;
        if (timerS >= 0.3)
        {
            Destroy(gameObject);
            timerS = 0;
        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            speed = 0;
            collision.gameObject.GetComponent<EnemyAI>().Health -= 10;
            collision.gameObject.GetComponent<EnemyAI>().PlayFeedback(Player.gameObject);

            if (Player.GetComponent<MovementScript>().canJab) Destroy(gameObject);
            
        }
    }
        
    public void OnCollisionEnter2D(Collision2D collision)
    {
      
    }

}
