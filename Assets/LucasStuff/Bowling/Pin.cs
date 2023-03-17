using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    bool isHit = false;
    Vector3 startPos, startRot;
    Rigidbody rb;

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.localEulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    public void HitCollider()
    {
        isHit = true;
        ScoreManager.instance.AddScore(this);
    }

    public bool CheckHit() { return isHit; }

    public void ResetPin()
    {
        transform.position = startPos;
        transform.localEulerAngles = startRot;
        isHit = false;
    }
    public Rigidbody GetRigidBody() { return rb; }
}