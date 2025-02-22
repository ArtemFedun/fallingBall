using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotationSpeed;
    float rotY = 0;
    
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            float mouseX = Input.mousePosition.x;    
            float rotationY = (mouseX * -rotationSpeed) + rotY;  

            // if (Input.GetMouseButtonUp(0)){
            //     rotY = rotationY;
            // }
      
            transform.rotation = Quaternion.Euler(0, rotationY, 0);  
        }
        
    }
}
