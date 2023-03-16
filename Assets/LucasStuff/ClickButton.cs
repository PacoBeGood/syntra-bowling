using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    private bool isFirstAnim = true;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        //Debug.Log("MOUSE");
        if (isFirstAnim) { anim.Play("press"); isFirstAnim = false; }
        else { anim.Play("unpress"); isFirstAnim = true; }
    }
}
