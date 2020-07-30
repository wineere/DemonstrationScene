using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Creates 12x2 cubes in the scene and then computes tonality vector each frame for cubes to get data from.
/// </summary>
public class harmonyCubes : MonoBehaviour
{
    public GameObject Cube1;
    GameObject[] cubes = new GameObject[24];
    public Material material;

    AudioSource audioSource;
    float[] spectrogram = new float[2048];

    public static float[] Intensity { get; private set; }

    Color startingColor;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        for (int i = 0; i < 12; i++)
        {
            GameObject instance = (GameObject)Instantiate(Cube1);
            int xCoord = -147 + i * 25;
            instance.transform.position = new Vector3(xCoord, -25,13);
            instance.transform.parent = this.transform;
            instance.name = "HarmonicCube" + i;
            instance.GetComponent<Renderer>().material = Instantiate(material);
            instance.transform.localScale = new Vector3(20, 20, 20);
            var t = instance.AddComponent<cubeColor>();
            t.Number = i;            
            cubes[i] = instance;
        }

        for (int i = 12; i < 24; i++)
        {
            GameObject instance = (GameObject)Instantiate(Cube1);
            int xCoord = -147 + (i-12) * 25;
            instance.transform.position = new Vector3(xCoord, -25, -13);
            instance.transform.parent = this.transform;
            instance.name = "HarmonicCube" + i;
            instance.transform.localScale = new Vector3(20, 20, 20);
            var t = instance.AddComponent<cubeColor>();
            t.Number = i;
            cubes[i] = instance;
        }
        Cube1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData(spectrogram, 0, FFTWindow.Blackman);
        var sampleRate = AudioSettings.outputSampleRate;
        var chromagram = FeaturesExtraction.LogFrequencySpectrogramAndChromagram.SummedChromagramFromSpectrogram
            (new List<float[]> { spectrogram },sampleRate);

        var tonality = FeaturesExtraction.Tonality.TonalityFromChromagram(chromagram);

       
        var max = tonality.Max();

        for (int i = 0; i < tonality.Length; i++)
        {
            if(tonality[i]==max)
            {
                tonality[i] = 1;
            }
            else
            {
                tonality[i] = 0;
            }
            //tonality[i]/= max;
        }

        Intensity = tonality;
    }
}
