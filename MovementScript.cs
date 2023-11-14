using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float movementSpeed;
    public Camera cam;
    public GameObject Arm;
    public float Health = 100;
    public float maxHealth = 100;
    public Animator Animation;
    public Animator ArmAnimation;
    public int equip = 0;
    private float isMoving;
    private Vector3 mouseToWorld;
    public GameObject hold;
    private GameObject copy;
    private GameObject Slash;
    private Quaternion armangle;
    public double SlashSpeed = 2;
    public bool canSlash = true;
    public double timer;
    public GameObject InventoryParent;
    public bool canJab;
    public Vector3 toDash;

    public Rigidbody2D RD;
    public double timerP = 0;
    public GameObject SlashObj;
    public GameObject JabObj;
    private double timerS = 0;
    private SlashBehaviour SlashBehaviour;
    private GameObject SwordUse;
    public Vector3 movePlace;
    public bool canDash = true;
    public bool isdash = false;
    public float dashSpeed = 300;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1;
    // Start is called before the first frame update
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.Mouse0) && canSlash && (!InventoryParent.active))
        {
            canSlash = false;
            if(canJab == false)
            {

                GameManager.instance.SlashFX(Arm.transform.position, Arm.transform.rotation, Arm.transform, canJab);              
                ArmAnimation.SetTrigger("Slash");

                

            }
            else
            {
                GameManager.instance.SlashFX(Arm.transform.position, Arm.transform.rotation, Arm.transform, canJab);
                ArmAnimation.SetTrigger("Jab");

            }

            
        }
        if (!canSlash) 
        { 
            timer += Time.deltaTime;
            if (timer >= SlashSpeed)
            {
                canSlash = true;
                timer = 0;
            }

        }
        
        mouseToWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));


   


        if (Input.GetKey(KeyCode.D))
        {
            movePlace += Vector3.right ;
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
    
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            movePlace += Vector3.left;
        }
    
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * movementSpeed * Time.deltaTime;
            movePlace += Vector3.up;
        }
      
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * movementSpeed * Time.deltaTime;
            movePlace += Vector3.down;
        }
      
        

        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            canDash = false;
            isdash = true;
            Vector2 direction = (transform.position - mouseToWorld).normalized * -1;
            RD.AddForce(direction * dashSpeed, ForceMode2D.Impulse);
            Invoke(nameof(Stop), dashDuration);
            isdash = false;
            Debug.Log("RUT");
        }
        if (!canDash)
        {
            timerP += Time.deltaTime;
            if (timerP >= dashCooldown)
            {
                canDash = true;
                timerP = 0;
            }

        }


        if (RD.velocity.x > 10000)
        {
            RD.velocity = new Vector2(10000, RD.velocity.y);
        }
        if (RD.velocity.y > 10000)
        {
            RD.velocity = new Vector2(RD.velocity.x, 10000);
        }
       
        
        if ( mouseToWorld.x > transform.position.x)
        {
            transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x), transform.localScale.y);
            Arm.transform.localScale = new Vector3(System.Math.Abs(Arm.transform.localScale.x), System.Math.Abs(Arm.transform.localScale.y));
        }
        if (mouseToWorld.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y );
            Arm.transform.localScale = new Vector3(Arm.transform.localScale.x * -1, Arm.transform.localScale.y * -1);
        }

        float angle = Mathf.Atan2(mouseToWorld.y - Arm.transform.position.y, mouseToWorld.x - Arm.transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Arm.transform.rotation = Quaternion.RotateTowards(Arm.transform.rotation, targetRotation, 1000 * Time.deltaTime);

        if ((Input.GetKey(KeyCode.S)|| (Input.GetKey(KeyCode.W)|| (Input.GetKey(KeyCode.D)|| (Input.GetKey(KeyCode.A))))))
        {

            Animation.SetBool("Walk", true);

        }
        else
        {

            Animation.SetBool("Walk", false);

        }

    


}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
           
            for (int i = 0; i < 2; i++)
            {
               
                Inventory.instance.AddItem(GameManager.instance.ItemList[1]);
            }
        }

        if (collision.gameObject.layer == 7 && collision.gameObject.tag == "RockDrop")
        {
            Destroy(collision.gameObject);
            for (int i = 0; i < Random.Range(1, 2); i++)
            {
                
                Inventory.instance.AddItem(GameManager.instance.ItemList[0]);
            }
        }
        if (collision.gameObject.layer == 7 && collision.gameObject.tag == "IronDrop")
        {
            Destroy(collision.gameObject);
            for (int i = 0; i < Random.Range(1, 2); i++)
            {
               
                Inventory.instance.AddItem(GameManager.instance.ItemList[5]);
            }
        }
    }

   public void Equip(GameObject sword, bool IsStraight, double slashSpeed, bool jaber)
    {
        SwordUse = sword;
        canJab = jaber;
        canSlash = false;
        SlashSpeed = slashSpeed;
        if (mouseToWorld.x > transform.position.x && IsStraight == false)
        {
            armangle = Quaternion.Euler(0, 0, 45);
        }
        else if(mouseToWorld.x > transform.position.x && IsStraight == true)
        {
            armangle = Quaternion.Euler(0, 0, 0);
        }
        
        if (mouseToWorld.x < transform.position.x && IsStraight == false)
        {
            armangle = Quaternion.Euler(0, 0, -45);
        }
        else if(mouseToWorld.x < transform.position.x && IsStraight == true)
        {
            armangle = Quaternion.Euler(0, 0, 0);
        }
        

        Arm.transform.rotation = Quaternion.Euler(0, 0, 0);
        copy = Instantiate(sword, hold.transform.position, armangle, hold.transform);
       
        
    }
    public void unEquip()
    {

        Destroy(copy);

    }
    private void Stop()
    {
        RD.velocity = Vector2.zero;
    }

}
