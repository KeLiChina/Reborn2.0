using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoTrap : MonoBehaviour {
    public Animator left;
    public Animator right;

    void OnTriggerEnter2D(Collider2D obj)
    {


        left.SetTrigger("Start");
        right.SetTrigger("Start");

    }
}
