using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationY;
    
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            float mouseX = Input.GetAxis("Mouse X");    
            rotationY += mouseX * rotationSpeed;  
            transform.rotation = Quaternion.Euler(0, -rotationY, 0);  
        }
    }
}
