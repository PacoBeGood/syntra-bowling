using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] Transform followTransform;
    [SerializeReference] Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = followTransform.position + offset;
        transform.rotation = Quaternion.Euler(0, followTransform.localEulerAngles.y, 0);
    }
}
