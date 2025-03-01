using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlNO : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")){
            transform.parent.gameObject.SetActive(false);
        }
    }
}