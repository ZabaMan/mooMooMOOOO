using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager the = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    [SerializeField] private GameObject playerCow;
    public List<Player> players;
    [SerializeField] private List<Transform> respawns;
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (the == null)

            //if not, set instance to this
            the = this;

        //If instance already exists and it's not this:
        else if (the != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    private void Start()// remove cow spawn
    {
        for(int i = 0; i < players.Count; i++)
        {
            players[i].playerObject = Instantiate(playerCow, respawns[i].position, respawns[i].rotation) as GameObject;
            players[i].playerObject.GetComponent<Renderer>().material = players[i].colour;
        }
    }
}
