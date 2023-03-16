using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    public void Set(float value)
    {
        transform.eulerAngles = new Vector3(0, value * 360, 0);
    }
}
