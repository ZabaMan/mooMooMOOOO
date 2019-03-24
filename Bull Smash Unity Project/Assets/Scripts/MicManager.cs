using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicManager : MonoBehaviour
{

    private Dropdown dropdown;
    private List<string> deviceOptions = new List<string> {"None Selected"};
    
    private InputField input;
   
    public GameObject player;
    

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        input = GetComponentInChildren<InputField>();
        
       
        //add devices to dropdown list
         //populate devices list
         foreach(string device in Microphone.devices)
        {
            deviceOptions.Add(device);
        }

        //clear otions       
            dropdown.ClearOptions();      
        // add dropdown options   
            dropdown.AddOptions(deviceOptions);


        //add a listener
        //on value change, assign dropdown device to corresponding player

        dropdown.onValueChanged.AddListener(delegate
         {
             MicDropdownChangeHandler(dropdown);
         });

        //set default input field value        
       

        input.onEndEdit.AddListener(delegate
        {
            InputChangeHandler(input);
        });
     }
    


    private void Update()
    {       

    }

    private void MicDropdownChangeHandler(Dropdown change)
    {
        
        if (change.captionText.text != "None Selected")
        {
            player.GetComponent<AudioAnalyzer>().ChangeMic(change.captionText.text);
            
        }
    }

    private void InputChangeHandler(InputField change)
    {
        player.GetComponent<PlayerMove>().minDb = float.Parse(change.text);
    }

    public void GetPlayerData(GameObject playerObj)
    {
        player = playerObj;
        input.text = player.GetComponent<PlayerMove>().minDb.ToString();
    }
}
