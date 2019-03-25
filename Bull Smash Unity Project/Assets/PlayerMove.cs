﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private Vector3 startPos;
    public int playerNum;
    public float anglesPerSec;
    public float db;
    public float minDb;
    public float forceMultiplier;
    private Rigidbody rb;
    public float boostCD= 1f;
    public float boostCDRemaining;
    public bool canBoost;

    public GameObject soundCircle;
    private Vector3 startCircleScale;
    // Start is called before the first frame update
    void Start()
    {
        startCircleScale = soundCircle.transform.localScale;
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        db = GetComponent<AudioAnalyzer>().dbValue;
        db = Mathf.Clamp(db, 0, 100f);
       
        Rotate();
        soundCircle.transform.localScale = 
            Vector3.Lerp(soundCircle.transform.localScale, startCircleScale, 5f * Time.deltaTime);
        

        if (db > minDb)
        {
            Boost();
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = startPos;
        }
    }

    void Rotate()
    {
        //if player 0
        //get keycode from controller input
        float rotSpeed = anglesPerSec * Time.deltaTime;
        Vector3 rotation = new Vector3(0, rotSpeed, 0);
        if (playerNum == 1)
        {
            if (Input.GetKey(ControllerScript.instance.circleButton))
            {
               
                transform.Rotate(-rotation, Space.World);
            }
            if (Input.GetKey(ControllerScript.instance.squareButton))
            {
                
                transform.Rotate(rotation, Space.World);
            }
        } else if(playerNum == 0)
        {
            float inputHor = (-Input.GetAxisRaw("D-Pad Horizontal"));

            transform.Rotate(rotation * inputHor, Space.World);
            

            
        }
        //float rotX = Input.GetAxis("Horizontal"+playerNum);
          
        //Vector3 rotation = new Vector3(0,rotSpeed, 0);
        
        
    }

    void Boost()
    {
        Vector3 newScale = new Vector3(0.5f* db, 0.5f * db, 0.5f * db);
        soundCircle.transform.localScale = Vector3.Lerp(soundCircle.transform.localScale, newScale,10f *Time.deltaTime);
        rb.AddForce(transform.forward * db * forceMultiplier);        
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,Mathf.Clamp(rb.velocity.z, 0,7f));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "death")
        {

            GameManager.the.PlayerFell(playerNum);
            //} else if(other.tag == "death" && GameManager.the.players[playerNum].lives <= 0)
            //{

            //    GameManager.the.PlayerDead(playerNum);
            //}
        }
    }
}
