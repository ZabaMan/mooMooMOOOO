using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleRiseAndSpray : MonoBehaviour
{
    [SerializeField] private Animator whaleAnimations;
    [SerializeField] private float startDelay, timeTillFirstSpray, timeBetweenSprays, timeOfSprayLength, timeBetweenRises;
    [SerializeField] private int numberOfSpraysPerRise;
    private int spraysDone = 0;
    [SerializeField] private ParticleSystem[] particleEffects;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Rise", startDelay);
    }

    private void Rise()
    {
        whaleAnimations.SetTrigger("RiseWhale");
        Invoke("Spray", timeTillFirstSpray);
    }

    private void Spray()
    {
        whaleAnimations.SetBool("SprayWater", true);
        Invoke("LowerSpray", timeOfSprayLength);
    }

    private void LowerSpray()
    {
        whaleAnimations.SetBool("SprayWater", false);
        spraysDone++;
        if (spraysDone != numberOfSpraysPerRise)
        {
            Invoke("Spray", timeBetweenSprays);
        }
        else
        {
            Invoke("Lower", timeTillFirstSpray);
        }
    }

    private void Lower()
    {
        whaleAnimations.SetTrigger("LowerWhale");
        Invoke("Rise", timeBetweenRises);
    }
}
