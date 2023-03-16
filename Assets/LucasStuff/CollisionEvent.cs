using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent doEvent;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip sound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Trash") return;
        doEvent.Invoke();
        source.PlayOneShot(sound);
        GameManager.instance.AddScore();
    }
}
