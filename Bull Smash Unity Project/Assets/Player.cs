using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
   //[HideInInspector]
    public int score;
  // [HideInInspector]
    public bool alive = true;
   //[HideInInspector]
    public int lives = 1; // Gets set to 3 after first death
  // [HideInInspector]
    public int number;
   public Material colour;
   //[HideInInspector]
    public GameObject playerObject;
   //[HideInInspector]
    public bool spawned;

}
