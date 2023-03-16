using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    bool isHit = false;

    public void OnTriggerEnter(Collider other)
    {
        // If it touches the scoreTrigger, manage pin-List and add score.
        if (other.tag == "Goal" && !isHit)
        {
            isHit = true;
            ScoreManager.instance.AddScore(this);
        }
    }

    public bool CheckHit() { return isHit; }
}