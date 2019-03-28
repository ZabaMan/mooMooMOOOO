using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusStick : MonoBehaviour
{

    [SerializeField] float destroyAfterContact = 1;
    private bool timeToReleaseCows;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            if (!timeToReleaseCows)
            {
                collision.gameObject.GetComponent<PlayerMove>().enabled = false;
            }
            Invoke("ReleaseCows", destroyAfterContact);

            if (timeToReleaseCows)
            {
                collision.gameObject.GetComponent<PlayerMove>().enabled = true;
                Destroy(gameObject);
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

    private void ReleaseCows()
    {
        timeToReleaseCows = true;
        Destroy(gameObject, destroyAfterContact+ 0.1f);
    }


}


