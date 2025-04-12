using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    float scoreF = 0;
    float PIPS = 12f;
    void Update()
    {
        BallFall score = GameObject.FindObjectOfType<BallFall>();
        if(score.getScore == 1){
            scoreF = PIPS * Time.deltaTime; 
        }
    }
}
