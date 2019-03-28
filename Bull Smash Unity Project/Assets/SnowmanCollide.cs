using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Snowman hit!");
            Destroy(GetComponent<Rigidbody>());
            foreach(Transform child in transform)
            {
                child.gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
