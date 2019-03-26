using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private List<MicManager> micManagers;

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
        if (!players[0].spawned)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].playerObject = Instantiate(playerCow, 
                    LevelTracker.instance.levels[LevelTracker.instance.currentLevel].spawnPoints[i].position,
                    LevelTracker.instance.levels[LevelTracker.instance.currentLevel].spawnPoints[i].rotation) as GameObject;
                players[i].number = i;
                players[i].spawned = true;
                players[i].playerObject.GetComponent<Renderer>().material = players[i].colour;
                players[i].playerObject.GetComponent<PlayerMove>().playerNum = players[i].number;
                micManagers[i].GetPlayerData(players[i].playerObject);
                playersActive += 1;
                playerAliveCount += 1;
            }
        }
    }

    public void PlayerFell(int playerNumber)
    {
        foreach (Player player in players)
        {
            if (player.number == playerNumber)
            {
                player.lives -= 1;
                //respawn timer
                player.playerObject.transform.position = respawns[playerNumber].position;
                if (player.lives <= 0)
                {
                    
                    PlayerDead(playerNumber);
                    
                }

            }
        }


    }

    public void PlayerDead(int playerNumber)
    {
        foreach (Player player in players)
        {
            if (player.number == playerNumber)
            {
                player.alive = false;
                player.playerObject.GetComponent<PlayerMove>().enabled=false;
                //player.playerObject.SetActive(false);
                playerAliveCount -= 1;
                if (playerAliveCount ==1)
                {
                    //player remaining won!
                    print("won");
                }
                else if (playerAliveCount == 0)
                {
                    //next map
                    //update all players points
                    //spawn at new positions
                    //lerp camera
                    //start timer countdown
                    LevelTracker.instance.NextLevel();
                    //reset player alive count
                    playerAliveCount = players.Count;
                }


            }

        }
    }
}
