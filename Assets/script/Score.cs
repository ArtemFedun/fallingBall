using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    float score = 0;
    float scoreAdd = 2;
    float streak = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pass")){
            score = score + scoreAdd;
            scoreAdd = scoreAdd * streak;
            streak++;
            Debug.Log(score);
        }
        if(other.CompareTag("Ground") || other.CompareTag("Glass") || other.CompareTag("Kill")){
            streak = 0;
            scoreAdd = 2;
        }
    }
}