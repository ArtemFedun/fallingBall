using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentChecker : MonoBehaviour
{

    [SerializeField] private GameObject panelWon;
    [SerializeField] private GameObject panelLost;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kill"){
            gameObject.SetActive(false);
        } else if (other.gameObject.tag == "Finish"){
            Movement column = GameObject.FindObjectOfType<Movement>();
            column.MenuPause(true);
            panelWon.SetActive(true);
        } else if (other.gameObject.tag == "Glass"){
            // TRIGGER TO GLASS
        }
    }
}
