using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyImpact : MonoBehaviour
{
    [SerializeField] AudioClip hitSound;
    AudioSource audio;
    Rigidbody rigidbody;
    void Start()
    {
        if (!TryGetComponent(out AudioSource getAudio))
        {
            Debug.Log("There is no AudioSource on this object!");
        }
        if (!TryGetComponent(out Rigidbody getRigidbody))
        {
            Debug.Log("There is no Rigidbody on this object!");
        }
        audio = getAudio;
        rigidbody = getRigidbody;
    }
    private void OnCollisionEnter(Collision collision)
    {
        audio.PlayOneShot(hitSound, rigidbody.velocity.magnitude);
    }


}
