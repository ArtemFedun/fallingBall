using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFall : MonoBehaviour
{
    [SerializeField] private GameObject Level;
    public float bounce, fallingSpeed, maxSpeed, getScore;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate(){
        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - fallingSpeed, rb.velocity.z);
        }
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Ground")) {
            getScore = 0;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, bounce, rb.velocity.z);
        }
    }
}
