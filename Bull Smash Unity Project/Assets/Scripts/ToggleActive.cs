using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{

    public KeyCode key;
    public List<GameObject> objToToggle;
    private bool toggle = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key)){
            toggle = !toggle;
            foreach (GameObject obj in objToToggle)
            {                
                obj.SetActive(toggle);
                
            }
        }
    }
}
