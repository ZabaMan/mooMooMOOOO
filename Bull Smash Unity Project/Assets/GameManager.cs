using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager the = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    [SerializeField] private GameObject playerCow;
    public List<Player> players;
    private int playersActive;
    [SerializeField] private List<Transform> respawns;

    [SerializeField] private int livesPerRound;
    [SerializeField] private int playerAliveCount;
    private int currentRound = 0; // 1 is farm, etc, 4 is end/winner
    [SerializeField] private Transform[] cameraPositions; // 0 = farm

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

    }

    private void Start()// add player mic objects?
    {
        for (int i = 0; i < players.Count; i++)
        {

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("1") && !players[0].spawned)
        { 
        players[0].playerObject = Instantiate(playerCow, respawns[0].position, respawns[0].rotation) as GameObject;
        players[0].spawned = true;
        players[0].playerObject.GetComponent<Renderer>().material = players[0].colour;
        playersActive += 1;
        }
    }

    public bool PlayerFell(int playerNumber)
    {
        foreach(Player player in players)
        {
            if (player.number == playerNumber)
            {
                player.lives -= 1;
                if (player.lives == 0)
                {
                    PlayerDead(playerNumber);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void PlayerDead(int playerNumber)
    {
        foreach (Player player in players)
        {
            if (player.number == playerNumber)
            {
                player.alive = false;
                playerAliveCount -= 1;
                if (playerAliveCount == 1)
                {
                    // Player remaining won!
                }
                else if (playerAliveCount == 0)
                {
                    // Next map
                    
                }
            }

        }

    }
}
