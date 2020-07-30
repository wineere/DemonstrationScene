using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


/// <summary>
/// Makes light pulses on beat times.
/// </summary>
public class light : MonoBehaviour
{    
    public Light Light;
    public AudioSource audioSource;

    
    float[] TimeBeats;
    public int beatNumber=0;

    // Start is called before the first frame update
    void Start()
    {        
         Light t = (Light)Light;
        t.intensity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(beatNumber>=featuresBeats.BeatTimes.Length)
        {
            return;
        }
        if (featuresBeats.BeatTimes[beatNumber] <= audioSource.time)
        {
            beatNumber++;
            Light t = (Light)Light;            
            
            t.intensity = 16;
        }
        else
        {
            Light.intensity /= 1.1f;            
        }
    }
}
