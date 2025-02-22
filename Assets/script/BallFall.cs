using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFall : MonoBehaviour
{
    [SerializeField] private GameObject Level;
    public float bounce = 100f;
    

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground")) {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, bounce, rb.velocity.z);
        }
    }
}
