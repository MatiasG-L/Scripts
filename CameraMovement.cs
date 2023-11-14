using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    private Vector3 PlayerOffset;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += Camera.main.nearClipPlane;
        PlayerOffset = new Vector3(0, 0, 10);
        transform.position = Vector3.Lerp(mousePosition, (Player.transform.position - PlayerOffset), 0.8f );
        


    }
    


}
