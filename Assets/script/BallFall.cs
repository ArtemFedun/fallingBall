using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFall : MonoBehaviour
{
    [SerializeField] private GameObject Level;
    public float bounce, fallingSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - fallingSpeed, rb.velocity.z);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground")) {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, bounce, rb.velocity.z);
        }
    }
}
