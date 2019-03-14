using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour {
    float xAxis;
    public int turnSpeed = 5;
    public int thrust = 5;
    Rigidbody rb;
    public bool Player1;
    public bool Player2;
    public bool Player3;

    private bool grounded = true;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

    }

	
	// Update is called once per frame
	void Update () {
        if (Player1)
        {
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
        else if (Player2)
        {
            xAxis = Input.GetAxisRaw("Horizontal2");

            transform.Rotate(Vector3.up * (xAxis * turnSpeed));


            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
                GetComponent<Animation>().Play("headRAM");
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                GetComponent<Animation>().Play("headUP");
            }
        }

        else if (Player3)
        {
            xAxis = Input.GetAxisRaw("Horizontal3");

            transform.Rotate(Vector3.up * (xAxis * turnSpeed));


            if (Input.GetAxisRaw("Fire1") > 0 && grounded)
            {
                rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
                GetComponent<Animation>().Play("headRAM");
            }
            /*else if (Input.GetAxisRaw("Fire1") != -1)
            {
                GetComponent<Animation>().Play("headUP");
            }*/
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
