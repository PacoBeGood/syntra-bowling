using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 startPos;
    Rigidbody rb;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LaneEnd") Reset();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Lane" && rb.velocity.z < 0.5f) rb.AddForce(Vector3.forward);
    }
    public void Reset()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        ScoreManager.instance.CheckReset();
    }
}
