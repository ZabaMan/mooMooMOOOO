using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTracker : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public string name;
        public List<Transform> spawnPoints;
        public List<GameObject> toSetActive;
        public Color backgroundColour;
    }

    public static LevelTracker instance = null;
    public List<Level> levels;
    public int currentLevel = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        for(int i=0; i < levels.Count; i++)
        {
            if (i > 0)
            {
                foreach (GameObject obj in levels[i].toSetActive)
                {
                    obj.SetActive(false);
                }
            }
            
        }
    }

    public void NextLevel()
    {
        //set last levels objects inactive
        foreach (GameObject obj in levels[currentLevel].toSetActive)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        //update current level
        currentLevel += 1;
        //set the current level objects active
        foreach(GameObject obj in levels[currentLevel].toSetActive)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }        
        //set player spawn points
        for(int i=0; i< GameManager.the.players.Count; i++)
        {
            GameManager.the.players[i].playerObject.transform.position = 
                levels[currentLevel].spawnPoints[i].position;
            //set players active
            //GameManager.the.players[i].playerObject.SetActive(true);
            GameManager.the.players[i].playerObject.GetComponent<PlayerMove>().enabled=true;

        }
        //lerp camera
        FollowWaypoints.instance.LerpNextWaypoint();
        //change bg colour
        Camera.main.backgroundColor = levels[currentLevel].backgroundColour;
        
    }
}
