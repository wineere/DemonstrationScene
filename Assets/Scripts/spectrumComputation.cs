using UnityEngine;
using System.Collections;


/// <summary>
/// Computes spectrum.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class spectrumComputation : MonoBehaviour
{
    AudioSource _audioSource;

    public float ParticularSample = 0;

    public static float[] samples = new float[512];

    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        ParticularSample = samples[25];
    }
}
