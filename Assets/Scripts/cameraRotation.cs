using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Slowly rotates camera.
/// </summary>
public class cameraRotation : MonoBehaviour
{
    public Camera Camera;
    public float rotation=0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), rotation);        
    }
}
