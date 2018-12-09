using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoTrap : MonoBehaviour {
    public Animator left;
    public Animator right;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (GlobalManager.instance.m_Player == obj.transform)
        {
            //  left.SetTrigger("bone_left");
            // right.SetTrigger("bone_Right");
            left.Play("bone_left");
            right.Play("bone_right");
            
            var role = obj.GetComponent<Role>();
            role.LogicDie();
        }


       


    }
}
