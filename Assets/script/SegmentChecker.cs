using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kill"){
            gameObject.SetActive(false);
        } else if (other.gameObject.tag == "Finish"){
            Movement rotatingObject = GameObject.FindObjectOfType<Movement>();
            rotatingObject.rotationSpeed = 0f;
        } else if (other.gameObject.tag == "Glass"){
            // TRIGGER TO GLASS
        }
    }
}
