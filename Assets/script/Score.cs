using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    float score = 0;
    float scoreAdd = 2;
    float streak = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pass")){
            streak++;
            score = scoreAdd;
            scoreAdd = scoreAdd * streak;
            Debug.Log(score);
        } else if(other.CompareTag("Ground") || other.CompareTag("Glass") || other.CompareTag("Kill")){
            streak = 1;
            scoreAdd = 12;
        }
    }
}