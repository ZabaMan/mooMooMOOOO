using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform rotateAroundTarget;
    [SerializeField] private float rotateSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotateAroundTarget.position, Vector3.up, rotateSpeed);
    }
}
