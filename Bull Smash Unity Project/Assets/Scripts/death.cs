using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {
    public int playerNumber;
    private bool dead = false;
    public Transform respawn;
    private Rigidbody rb;
    public float respawnTime;
    private Quaternion respawnRotation;
	
	void Start () {
        rb = GetComponent<Rigidbody>();

        respawnRotation = transform.rotation;
	}

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "death" && !dead)
        //{
            
        //    //UIupdate();
        //    if (GameManager.the.PlayerFell(playerNumber))
        //    {
        //        dead = true;
        //        GetComponent<moveScript>().groundMe();
        //        Invoke("respawnAtTransform", respawnTime);
        //    }

        //}
    }

    void respawnAtTransform()
    {
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = respawn.position;
        transform.rotation = respawnRotation;
        dead = false;
    }

    void UIupdate()
    {
       // UI.text = string.Format("{0}", score);
    }

    

    // Update is called once per frame
    void Update () {
		
	}
}
