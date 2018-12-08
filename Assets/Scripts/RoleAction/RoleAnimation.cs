using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimatorState
{
    NULL = -1,
    Idle = 0,
    Move = 1,
    Attack = 2,
    Death = 3,
    SIZE
}
public class RoleAnimation : MonoBehaviour
{

    public Animator m_Animator;
    public string m_Attack = "Attack";
    public string m_Idle = "Idle";
    public string m_Move = "Move";
    public string m_Death = "Death";
    [HideInInspector]
    public AnimatorState m_AnimatorState;

    void Start()
    {
        Idle();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_AnimatorState);
    }
    public void Idle()
    {
        if (m_AnimatorState == AnimatorState.Idle || m_AnimatorState == AnimatorState.Attack)
        {
          
            return;
        }
      
        m_AnimatorState = AnimatorState.Idle;
        m_Animator.Play(m_Idle);
     
    }
    public void Attack()
    {
        if (m_AnimatorState == AnimatorState.Attack)
        {
            return;
        }
        m_AnimatorState = AnimatorState.Attack;

        m_Animator.Play(m_Attack);
        StartCoroutine(IE_PlayAttackAnimation());
    }
    public void Move()
    {
        if (m_AnimatorState == AnimatorState.Attack || m_AnimatorState == AnimatorState.Move)
        { 
          
            return;
        }
        m_AnimatorState = AnimatorState.Move;
        m_Animator.Play(m_Move);
   
    }
    public void Death()
    {
        if (m_AnimatorState == AnimatorState.Death)
        {
            return;
        }
        m_AnimatorState = AnimatorState.Death;
        m_Animator.Play(m_Death);
    }
    IEnumerator IE_PlayAttackAnimation()
    {
        // if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        // {
        //     m_AnimatorState = AnimatorState.Idle;
        //     m_Animator.Play(m_Idle);
        // }
        // yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(0.6f);
        if (m_AnimatorState != AnimatorState.Death)
        {
            m_AnimatorState = AnimatorState.Idle;
            m_Animator.Play(m_Idle);
        }
    }
}
