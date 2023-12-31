using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    public double Health = 100;
    public Rigidbody2D RB;
    public float strong = 16, delay = 0.15f;
    private GameObject Player;
    public float AttackSpeed = 0.4f;
    // Start is called before the first frame update
    public UnityEvent OnBegin, OnEnd;
    public Animator ANM;
    public float timer = 0;
    public float timerA = 0;
    public float speed;
    public float damageBuff = 1;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (gameObject.name == "Rocker") AttackSpeed = 0.9f;
    }

    private IEnumerator Reset()
    {

        yield return new WaitForSeconds(delay);
        RB.velocity = Vector3.zero;
        OnEnd?.Invoke();
    }
    public void KnockbackAnm()
    {
        ANM.SetBool("knockback", false);
    }
    public void Knockback(GameObject sender, bool issuper)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        ANM.SetBool("knockback", true);
        Invoke(nameof(KnockbackAnm), 0.5f);
        if (issuper)
        {
            RB.AddForce(direction * strong *10f, ForceMode2D.Impulse);
        }
        else
        {
            RB.AddForce(direction * strong, ForceMode2D.Impulse);
        }
        
        StartCoroutine(Reset());
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Health <= 0)
        {
            MovementScript.instance.Health += 5;
            Destroy(gameObject);
        }
        if (Player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x), transform.localScale.y);
            
        }
        if (Player.transform.position.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        }

        if (ANM.GetBool("knockback"))
        {
            ANM.SetBool("attack", false);
            ANM.SetBool("canwalk", false);
        }

        if (Vector3.Distance(transform.position, Player.transform.position) < 3.5 && !ANM.GetBool("knockback"))
        {
            ANM.SetBool("attack", true);
            ANM.SetBool("canwalk", false);
            timer += Time.deltaTime;
            timerA += Time.deltaTime;
            if (timerA >= 1f)
            {
                if (gameObject.name == "Rocker") Destroy(gameObject);
            }
            if (timer >= AttackSpeed)
            {
                
                Player.GetComponent<MovementScript>().Health -= Random.Range(5, 10)* damageBuff;
                timer = 0;
                
                
            }        
        }
        else if (Vector3.Distance(transform.position, Player.transform.position) < 20 && !ANM.GetBool("knockback"))
        {
            ANM.SetBool("attack", false);
            ANM.SetBool("canwalk", true);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            if (!ANM.GetBool("knockback"))
            {
                ANM.SetBool("attack", false);
                ANM.SetBool("canwalk", false);
            }
        }

    }


}
