using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour
{
    //mic vars
    public string mic = "assigned at runtime";
    //audio analysing vars
    private float[] samples;
    private int FRAME_SIZE = 1024; //gets sound level for the last 21ms (1024/48000)
    private float sampleRate; //how many samples to take each sec
    public float dbValue;
    private AudioSource audio;
    public float refValue = 0.0001f; //default: 0.1f, adjust if we need different 0db reference, 0.0001f return 0 most time
    private PlayerMove p;

    private void Awake()
    {
        p = GetComponent<PlayerMove>();
    }

    public void Start()
    {        
        mic = null;
       

        //foreach(string device in Microphone.devices)
        //{
        //    if(mic== null)
        //    {
        //        mic = device;
        //    }

        //}
        samples = new float[FRAME_SIZE];
        sampleRate = AudioSettings.outputSampleRate;
        audio = GetComponent<AudioSource>();

        UpdateMicrophone();
    }

    private void Update()
    {
        if (mic != null)
        {
            
            AnalyzeAudio();
        }
    }

    public void UpdateMicrophone()
    {
        

        audio.Stop();
        //start recording audio from mic
        audio.clip = Microphone.Start(mic, true, 10, (int)sampleRate);
        audio.loop = true;

        if (Microphone.IsRecording(mic)) //avoids infinite loop
        {
            while(!(Microphone.GetPosition(mic) > 0))
            {                
                //start recording
                audio.Play();
                print("started recording");
            }
        }
        else
        {
            //mic doesnt work for some reason
            print("mic don't work");
        }

    }

    void AnalyzeAudio()
    {
        //find RMS - sum all squared sample values, calculate average and get it's squared root
        //convert RMS to dB using log operation

        //get sound data and store amplitudes in the samples array
        audio.GetOutputData(samples, 0);

        float sum = 0;

        for (int i = 0; i < FRAME_SIZE; i++)
        {
            sum += samples[i] * samples[i];
        }

        float rmsValue = Mathf.Sqrt(sum / FRAME_SIZE);
        dbValue = 20 * Mathf.Log10(rmsValue / refValue);
       // dbValue = Mathf.Clamp(dbValue, -40, 4);

    }

    //private void OnDrawGizmos()
    //{
    //    //Gizmos.color = (dbValue >= -10) ? Color.red : Color.yellow;
    //    //Gizmos.DrawSphere(transform.position, 5f);
    //}

    public void ChangeMic(string device)
    {
        mic = device;
        UpdateMicrophone();
    }
}
