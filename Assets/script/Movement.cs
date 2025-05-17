using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotationSetting;
    public float rotationY;

    private float rotationSpeed;

    private void Start()
    {
        rotationSpeed = rotationSetting;
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            float mouseX = Input.GetAxis("Mouse X");    
            rotationY += mouseX * rotationSpeed;  
            transform.rotation = Quaternion.Euler(0, -rotationY, 0);  
        }
    }

    public void MenuPause(bool pause)
    {
        if (pause)
        {
            rotationSpeed = 0f;
        }
        else
        {
            rotationSpeed = rotationSetting;
        }
    }
}
