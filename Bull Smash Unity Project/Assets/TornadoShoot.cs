using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoShoot : MonoBehaviour
{
    [SerializeField] private float shootSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(other.transform.forward * shootSpeed, ForceMode.Impulse);
            other.attachedRigidbody.AddForce(other.transform.up * shootSpeed, ForceMode.Impulse);
            other.attachedRigidbody.velocity = other.attachedRigidbody.velocity * 2;
        }
    }

    
}
