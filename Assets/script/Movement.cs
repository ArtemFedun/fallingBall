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
            // при кліку запам'ятовуємо позицію курсора
            // поки клік утримується, камера рухається відносно позиції курсора

            float mouseX = Input.mousePosition.x;    
            float rotationY = (mouseX * -rotationSpeed) + rotY;  
      
            transform.rotation = Quaternion.Euler(0, rotationY, 0);  
        }
        
    }
}
