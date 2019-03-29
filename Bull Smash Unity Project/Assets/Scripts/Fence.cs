using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fence : Breakable
{
    public float breakAfter = 0;
    public float explosionForce;

    private void Awake()
    {
        base.obj = this.gameObject;
        
        
    }

    public override IEnumerator Break(float t)
    {
        yield return new WaitForSeconds(t);
        //disable parent collider
        base.collider.enabled = false;
        //add colliders and rbs to all children        
        foreach(Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.AddComponent<BoxCollider>();
            if(child.GetComponent<Rigidbody>() == null)
            {
                child.gameObject.AddComponent<Rigidbody>();
            }
           
            child.GetComponent<Rigidbody>().mass = 0.5f;
            child.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 100f);
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(Break(breakAfter));
        }
    }
}
