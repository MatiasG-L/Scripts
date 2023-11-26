using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBehaviour : MonoBehaviour
{
    public GameObject Player;
    public MovementScript PlayerData;
    public bool isSuper;
    private double timerS = 0;
    private float speed = 1;
    private double atkBuff = 1;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        PlayerData = Player.GetComponent<MovementScript>();
        atkBuff = PlayerData.atkBuff;
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
            double damageDealt;
            damageDealt = Random.Range(4, 8) * atkBuff * PlayerData.atkBuff;
            if (isSuper) damageDealt *= 2;
            collision.gameObject.GetComponent<EnemyAI>().Health -= damageDealt;
            collision.gameObject.GetComponent<EnemyAI>().Knockback(Player.gameObject, isSuper);
            Debug.Log("Dealt: "+damageDealt+" Damadge");
            if (Player.GetComponent<MovementScript>().canJab) Destroy(gameObject);
            
        }
    }
        
    public void OnCollisionEnter2D(Collision2D collision)
    {
      
    }

}
