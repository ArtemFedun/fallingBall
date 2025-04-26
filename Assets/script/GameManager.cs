using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelWon;
    [SerializeField] private GameObject panelLost;

    private void Start()
    {
        panelWon.SetActive(false);
        panelLost.SetActive(false);
    }
}
