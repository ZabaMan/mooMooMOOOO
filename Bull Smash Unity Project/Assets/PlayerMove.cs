﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float anglesPerSec;
    public float db;
    public float minDb;
    public float forceMultiplier;
    private Rigidbody rb;
    public float boostCD= 1f;
    public float boostCDRemaining;
    public bool canBoost;

    public GameObject soundCircle;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        db = GetComponent<AudioAnalyzer>().dbValue;
        db = Mathf.Clamp(db, 0, 100f);
       
        Rotate();
        soundCircle.transform.localScale = new Vector3(0.5f*db,0.5f* db,0.5f * db);
        

        if (db > minDb)
        {
            Boost();
            
        }
    }

    void Rotate()
    {
        float rotX = Input.GetAxis("Horizontal");
            float rotSpeed = anglesPerSec * Time.deltaTime;
            Vector3 rotation = new Vector3(0, rotX * rotSpeed, 0);
            transform.Rotate(rotation, Space.World);
        
    }

    void Boost()
    {
       rb.AddForce(transform.forward * db * forceMultiplier);        
        rb.velocity = Vector3.ClampMagnitude(rb.velocity,5);
        print(rb.velocity.magnitude);
    }
}
