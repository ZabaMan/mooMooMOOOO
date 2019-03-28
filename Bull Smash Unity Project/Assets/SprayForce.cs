using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayForce : MonoBehaviour
{

    [SerializeField] private float upwardsForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && this.enabled)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * upwardsForce, ForceMode.Impulse);
            //collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(upwardsForce, collision.gameObject.transform.position, 2);
        }
    }

    private void Start()
    {
        int x;
    }
}
