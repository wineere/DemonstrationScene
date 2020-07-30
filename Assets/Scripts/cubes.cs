using UnityEngine;
using System.Collections;


/// <summary>
/// Creates cubes to visualize song spectrum.
/// Uses buffer to achieve more smooth movement of cube heights
/// </summary>
public class cubes : MonoBehaviour
{
    public GameObject Cube1;
    GameObject[] _sampleCubes = new GameObject[128];
    public float _maxScale;
    public float forward = 250;

    public float Height = 0;
    public float currentHeight;

    static float[] buffer = new float[128];
    static float[] lastValue = new float[128];

    float bufferStart = 0.05f;
    float bufferMultiplier = 1.5f;

    // Use this for initialization
    void Start()
    {
        Debug.Log("I am alive!");
        for (int i = 0; i < 128; i++)
        {
            GameObject instance = (GameObject)Instantiate(Cube1);
            instance.transform.position = this.transform.position;
            instance.transform.parent = this.transform;
            instance.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * 4 * i, 0);
            instance.transform.position = Vector3.forward * forward;
            _sampleCubes[i] = instance;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 128; i++)
        {
            if (_sampleCubes != null)
            {
                Height = spectrumComputation.samples[i] * _maxScale;
                currentHeight = lastValue[i];
                if (Height>currentHeight)
                {
                    buffer[i] = bufferStart;
                }
                else
                {
                    Height = currentHeight - buffer[i];
                    buffer[i] *= bufferMultiplier;
                }
                _sampleCubes[i].transform.localScale = new Vector3(10, Height + 2, 10);
                lastValue[i] = Height;
                //_sampleCubes[i].transform.localScale = new Vector3(10, 10, 10);
            }
        }

    }
}
