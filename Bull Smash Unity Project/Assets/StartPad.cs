using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPad : MonoBehaviour
{
    [Range(0, 1)]
     public int index;
    public StartGame sg;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
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
}
