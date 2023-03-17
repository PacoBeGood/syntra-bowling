using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollider : MonoBehaviour
{
    [SerializeField] Pin pinScript;
    private void OnTriggerEnter(Collider other)
    {
        // If it touches the scoreTrigger, manage pin-List and add score.
        if (other.tag == "Goal" && !pinScript.CheckHit())
        {
            pinScript.HitCollider();
        }
    }
}
