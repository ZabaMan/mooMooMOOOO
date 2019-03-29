using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public bool resetGame;
    public bool ready1;
    public bool ready2;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(ready1 && ready2)
        {
            if (!resetGame)
            {
                foreach (StartPad s in transform.GetComponentsInChildren<StartPad>())
                {
                    s.gameObject.SetActive(false);
                }
                anim.SetBool("fall", true);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
