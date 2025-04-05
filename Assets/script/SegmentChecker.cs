using UnityEngine;

public class SegmentChecker : MonoBehaviour
{
    [SerializeField] private GameObject panelWon;
    [SerializeField] private GameObject panelLost;


    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.gameObject.tag == "Kill"){
            gameObject.SetActive(false);
        } else if (other.gameObject.tag == "Finish"){
            Movement column = GameObject.FindObjectOfType<Movement>();
            column.MenuPause(true);
            panelWon.SetActive(true);
        } else if (other.gameObject.tag == "Glass"){
            collision.gameObject.SetActive(false);
        }
    }
}
