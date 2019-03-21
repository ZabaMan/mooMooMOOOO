using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour {
    float xAxis;
    public int turnSpeed = 5;
    public int thrust = 5;
    Rigidbody rb;
    public int playerNumber;


    private bool grounded = true;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

    }

	
	// Update is called once per frame
	void Update () {
            xAxis = Input.GetAxisRaw("Horizontal");

            transform.Rotate(Vector3.up * (xAxis * turnSpeed));


            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
                GetComponent<Animation>().Play("headRAM");
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                GetComponent<Animation>().Play("headUP");
            }
    }
       

    
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ground")
            grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "ground")
            grounded = false;
    }*/

    public void groundMe()
    {
        if (grounded)
        {
            grounded = false;
        }
        else
        {
            grounded = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}
