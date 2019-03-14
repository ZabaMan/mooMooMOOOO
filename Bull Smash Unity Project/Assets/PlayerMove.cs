using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float anglesPerSec;
    public float db;
    public float minDb;
    public float speed;
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
        boostCDRemaining -= Time.deltaTime;
        Rotate();
        soundCircle.transform.localScale = new Vector3(0.5f*db,0.5f* db,0.5f * db);
        if (boostCDRemaining <= 0)
        {
            boostCDRemaining = 0;
            canBoost = true;           
            
        }

        if (canBoost && db > minDb)
        {
            Boost();
            boostCDRemaining = boostCD;
            canBoost = false;
        }
    }

    void Rotate()
    {
        float rotSpeed = anglesPerSec * Time.deltaTime;
        Vector3 rotation = new Vector3(0, 1 * rotSpeed, 0);
        transform.Rotate(rotation, Space.World);
    }

    void Boost()
    {
       rb.AddForce(transform.forward * db * speed * Time.deltaTime,ForceMode.Impulse);
              
    }
}
