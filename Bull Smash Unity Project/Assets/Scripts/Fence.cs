using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fence : Breakable
{
    public float breakAfter = 0;
 

    private void Awake()
    {
        base.obj = this.gameObject;
        
        
    }

    public override IEnumerator Break(float t)
    {
        yield return new WaitForSeconds(t);
        base.anim.SetBool("break", true);
        base.collider.enabled = false;

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(Break(breakAfter));
        }
    }
}
