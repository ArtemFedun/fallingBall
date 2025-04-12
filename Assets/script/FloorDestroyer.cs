using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")){
            BallFall score = GameObject.FindObjectOfType<BallFall>();
            score.getScore = 1;
            transform.gameObject.SetActive(false);
        }
    }
}