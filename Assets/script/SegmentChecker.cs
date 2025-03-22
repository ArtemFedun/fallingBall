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
            // TRIGGER TO FINISH
        } else if (other.gameObject.tag == "Glass"){
            // TRIGGER TO GLASS
        }
    }
}
