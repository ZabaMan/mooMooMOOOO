using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public float speed;
    public GameObject waypointHolder;
    public List<Transform> waypoints;
    
    private int currentIndex;
    public int nextIndex;
    public bool lerp;
    // Start is called before the first frame update
    void Start()
    {
        nextIndex = 1;
       
        for(int i = 0; i < waypointHolder.transform.childCount; i++)
        {
            waypoints.Add(waypointHolder.transform.GetChild(i));
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) LerpNextWaypoint();

        if (lerp)
        {
            LerpToNext();
        }
            
        
    }

    public void LerpNextWaypoint()
    {
        lerp = true;
    }

    public void LerpToNext()
    {
        nextIndex = nextIndex % waypoints.Count;
        //nextIndex = currentIndex + 1;
        Vector3 toTarget = waypoints[nextIndex].position - transform.position;
        float dist = toTarget.magnitude;
        
        transform.position = Vector3.Lerp(transform.position, waypoints[nextIndex].position, speed*Time.deltaTime);

        if(dist < 0.05f)
        {
            transform.position = waypoints[nextIndex].position;
            nextIndex += 1;
           lerp = false;
        }

    }
}
