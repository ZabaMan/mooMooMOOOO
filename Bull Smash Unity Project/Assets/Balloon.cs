using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    int nextBaloon=0;
    public List<GameObject> balloons;

    private void Awake()
    {

        for (int i=0;i<transform.childCount;i++)
        {
            balloons.Add(transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PopBalloon();
        }
    }

    public void PopBalloon()
    {
        for(int i=0; i < balloons.Count; i++)
        {
            if (i == nextBaloon % balloons.Count)
            {
                balloons[i].SetActive(false);
                nextBaloon++;
                return;
            }
        }
    }
}
