using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private GameObject Car;
    [SerializeField] private Vector3 CameraOffset;
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Car.transform.position + CameraOffset;   
    }
}
