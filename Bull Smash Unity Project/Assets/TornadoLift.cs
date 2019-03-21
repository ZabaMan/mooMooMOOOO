using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoLift : MonoBehaviour
{
    [SerializeField] private float liftSpeed;
    [SerializeField] private float pullSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform topOfTornado;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            
            other.attachedRigidbody.AddForce(Vector3.up * liftSpeed);
            //other.attachedRigidbody.AddTorque(Vector3.up * rotateSpeed, ForceMode.VelocityChange);
            other.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            Vector3 centreOfTornado = new Vector3(topOfTornado.position.x, other.transform.position.y, topOfTornado.position.z);
            other.transform.position = Vector3.MoveTowards(other.transform.position, centreOfTornado, pullSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.velocity = other.attachedRigidbody.velocity/2;
        }
    }
}
