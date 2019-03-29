using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusStick : MonoBehaviour
{

    [SerializeField] float destroyAfterContact = 1;
    private bool timeToReleaseCows;
    private bool releasedCows;
    private List<GameObject> playersStuck = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if (!timeToReleaseCows)
            {
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<PlayerMove>().enabled = false;
                playersStuck.Add(collision.gameObject);
            }
            if (!releasedCows)
            {
                timeToReleaseCows = true;
                releasedCows = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            collision.gameObject.GetComponent<PlayerMove>().enabled = true;
        }
    }

    private void Update()
    {
        if (timeToReleaseCows)
        {
            destroyAfterContact -= Time.deltaTime;
            if (destroyAfterContact <= 0)
            {
                foreach (GameObject cow in playersStuck)
                {
                    cow.GetComponent<PlayerMove>().enabled = true;
                }
                Destroy(gameObject);
            }
        }
    }


}


