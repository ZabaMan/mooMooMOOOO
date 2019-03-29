using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddForceTest : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical")>=1)
        {
            rb.AddForce(transform.forward * 100);
        }

        Vector3 rotation = new Vector3(0, Input.GetAxisRaw("Horizontal")*5, 0);
        transform.Rotate(rotation);
    }
}
