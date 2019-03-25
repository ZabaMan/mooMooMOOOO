using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(BoxCollider))]
public abstract class Breakable : MonoBehaviour
{
    public GameObject obj;
    public BoxCollider collider;
    public Animator anim;

    private void Awake()
    {
        
    }
    public void Start()
    {
        collider = obj.GetComponent<BoxCollider>();
        anim = obj.GetComponent<Animator>();
    }

    public virtual IEnumerator Break(float t)
    {
        yield return null;
    }
}
