using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{
    Vector3 startPos;
    Rigidbody rb;
    XRGrabInteractable grab;
    [SerializeField] float minForce = 3f;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LaneEnd") ScoreManager.instance.StartCoroutine("NextRound");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Lane") grab.enabled = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Lane" && rb.velocity.z < 0.5f) rb.AddForce(Vector3.forward * minForce);
    }
    public void Reset()
    {
         transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        grab.enabled = true;
    }
    public XRGrabInteractable GetGrab() { return grab; }
}