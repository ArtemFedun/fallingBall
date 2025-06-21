using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelWon;
    [SerializeField] private GameObject panelLost;

    private void Awake()
    {
        panelWon = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).gameObject;
        panelLost = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject;
        panelWon.SetActive(false);
        panelLost.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
