using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Rotate(Vector3.right * speed);
    }
}
