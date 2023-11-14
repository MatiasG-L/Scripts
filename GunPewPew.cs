using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPewPew : MonoBehaviour
{
    public Camera cam;
    public GameObject Player;
    public Transform target;
    public DistanceJoint2D DisJoint;

    private Vector3 mouseToWorld;
    private Vector3 zAxis;
    private Quaternion _lookRotation;
    private Vector3 _direction;
    private Vector3 Target;
    private Vector3 self;
    
    // Start is called before the first frame update
    void Start()
    {
        zAxis = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        mouseToWorld = cam.ViewportToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        if (Player.transform.position.x > transform.position.x )
        {
            transform.localScale = new Vector3(transform.localScale.x, System.Math.Abs(transform.localScale.y));
        }
        if (Player.transform.position.x < transform.position.x && transform.localScale.y >0)
        {
           transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y * -1);
        }




        transform.position = Vector3.Slerp(Player.transform.position, mouseToWorld, 0.5f * Time.deltaTime);
        float angle = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1000 * Time.deltaTime);
    }
}
