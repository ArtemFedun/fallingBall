using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")){
            Destroy(Ball);
        }
    }
}
