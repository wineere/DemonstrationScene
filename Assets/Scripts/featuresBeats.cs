using UnityEngine;
using System.Collections;
using NWaves.Signals;

/// <summary>
/// Computes beat times.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class featuresBeats : MonoBehaviour
{
    public static FeaturesExtraction.DynamicBeatTracking beat;
    public static float[] BeatTimes;
    
    public float BeatTime;
    public int channel;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        float[] samples = new float[audioSource.clip.samples * audioSource.clip.channels];
        audioSource.clip.GetData(samples, 0);
        

        if(audioSource.clip.channels==2)
        {
            float[] pannedSamples = new float[(samples.Length) / 2];

            for (int i = 0; i < pannedSamples.Length; i++)
            {
                pannedSamples[i]=(samples[2*i]+samples[2*i+1])/ 2;
            }
            samples = pannedSamples;
        }



        DiscreteSignal x = new DiscreteSignal(audioSource.clip.frequency, samples);

        beat = new FeaturesExtraction.DynamicBeatTracking(x);
        beat.ProcessBeats();
        
        BeatTimes = beat.TimeBeats();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
