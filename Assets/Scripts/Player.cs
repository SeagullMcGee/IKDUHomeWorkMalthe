using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float SidewaysForce = 200f;
    public Transform GroundCheckTransform;
    public Rigidbody rb;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    
    
    // Start is called before the first frame update
    void Start()
    {
        


   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
       if (Physics.OverlapSphere(GroundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }
      
        if (jumpKeyWasPressed)
        {
            rb.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        {
            rb.velocity = new Vector3(horizontalInput, rb.velocity.y, 0);
        }
    }

   

}

