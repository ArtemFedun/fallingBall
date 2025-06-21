using UnityEngine;

public class SegmentChecker : MonoBehaviour
{
    [SerializeField] private GameObject panelWon;
    [SerializeField] private GameObject panelLost;
    private ScoreHandler score;

    private void Start()
    {
        score = gameObject.GetComponent<ScoreHandler>();
        panelWon = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).gameObject;
        panelLost = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        score.ResetStreak();

        switch (other.tag)
        {
            case "Ground":            
                break;
            case "Finish":
                Movement column = GameObject.FindObjectOfType<Movement>();
                column.MenuPause(true);
                panelWon.SetActive(true);
                break;
            case "Kill":
                gameObject.SetActive(false);
                panelLost.SetActive(true);
                break;
            case "Glass":
                collision.gameObject.SetActive(false);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            score.AddScore();
        }
    }
}
