using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// In each frame sets cube emision according to its corresponding value in tonality vector.
/// </summary>
public class cubeColor : MonoBehaviour
{
    Material m_Material;
    Color startingColor;
    float intensity = 0.001f;

    public int Number;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        var t = m_Material.color;
        startingColor = t;
    }

    // Update is called once per frame
    void Update()
    {
        intensity = harmonyCubes.Intensity[Number]*3;
        m_Material.SetColor(Shader.PropertyToID("_EmissionColor"), startingColor * intensity);
    }
}
