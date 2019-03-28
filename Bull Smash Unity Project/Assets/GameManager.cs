using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager the = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public int scoreIncrementWin = 3;
    public int scoreIncrementLose = 1;

    [SerializeField] private GameObject playerCow;
    public List<Player> players;
    private int playersActive;
    [SerializeField] private List<Transform> respawns;

    [SerializeField] private int livesPerRound;
    [SerializeField] private int playerAliveCount;
    private int currentRound = 0; // 1 is farm, etc, 4 is end/winner
    [SerializeField] private Transform[] cameraPositions; // 0 = farm
    [SerializeField] private List<MicManager> micManagers;
    public Text winnerText;

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
                int pnum = players[i].number + 1;
                players[i].name = "Player " + pnum; ;
                players[i].spawned = true;
                MeshRenderer beltRend = players[i].playerObject.transform.Find("Belt").gameObject.GetComponent<MeshRenderer>();
                beltRend.material.color = players[i].colour.color;                
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
                player.playerObject.transform.rotation = respawns[playerNumber].rotation;
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
                player.playerObject.transform.position= LevelTracker.instance.levels[(LevelTracker.instance.currentLevel)+1].spawnPoints[player.number].position;
                player.playerObject.transform.rotation = LevelTracker.instance.levels[(LevelTracker.instance.currentLevel) + 1].spawnPoints[player.number].rotation;
                player.playerObject.GetComponent<Rigidbody>().isKinematic = true;
                playerAliveCount -= 1;
                if (playerAliveCount ==1 && LevelTracker.instance.currentLevel>0)
                {
                    //player remaining won!
                    print(playerNumber);
                    //get winner index
                    int winnerIndex = (playerNumber+1) % players.Count;
                    int winnerNumber = winnerIndex + 1;
                    //add scores
                    players[winnerIndex].score += scoreIncrementWin;
                    players[playerNumber].score += scoreIncrementLose;
                    winnerText.text = "Player " +winnerNumber + " wins";
                }
                else if (playerAliveCount == 0)
                {
                    //next map
                    //update all players points
                    //spawn at new positions
                    //lerp camera
                    //reset player alive count
                    playerAliveCount = players.Count;
                    //start timer countdown
                    StartCoroutine(LevelTracker.instance.NextLevel(1f));
                    
                }


            }

        }
    }
}
