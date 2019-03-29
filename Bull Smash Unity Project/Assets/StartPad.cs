using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPad : MonoBehaviour
{
    
    [Range(0, 1)]
     public int index;
    public StartGame sg;
    MeshRenderer mr;
    Material originalMat;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        originalMat = mr.material;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
                //change mat
                mr.material = other.transform.Find("Belt").GetComponent<MeshRenderer>().material;
                if (index == 0)
                {
                    sg.ready1 = true;
                }
                else
                {
                    sg.ready2 = true;
                }
            

            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //change mat
            mr.material = originalMat;
            if (index == 0)
            {
                sg.ready1 = false;
            }
            else
            {
                sg.ready2 = false;
            }
        }
    }
}
