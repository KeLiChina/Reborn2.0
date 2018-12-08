﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour {

	private float m_HP = 100;
	public int  m_RoleType = 1; //1 shield 2, thief
	
	private float moveSpeed = 20f;

	private float crash = 70;

	private float m_AddForce = 700;

	private float m_JumpForce = 700;

	private float bulletCost = 40;
	private bool protect = false;
	private Rigidbody2D m_Rigidbody2D;
	public Transform m_AtkForward;
	private float m_protateTime = 0.6f;
	void Awake () {
		
	}
	
	void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Init()
	{
		if (m_RoleType == 1)
		{
			m_HP = 100f;
			bulletCost = 40f;
			m_AddForce = 700;
			m_protateTime = 0.6f;
			moveSpeed = 20f;
			crash = 70;
			

		}
		else if (m_RoleType ==2)
		{

			m_HP = 100f;
			bulletCost = 40f;
			m_AddForce = 700;
			m_protateTime = 0.6f;
			moveSpeed = 20f;
			crash = 70;
		}
		else if (m_RoleType ==3)
		{

			m_HP = 100f;
			bulletCost = 40f;
			m_AddForce = 700;
			m_protateTime = 0.6f;
			moveSpeed = 20f;
			crash = 70;
		}
		else if (m_RoleType == 4)
		{

			m_HP = 100f;
			bulletCost = 40f;
			m_AddForce = 700;
			m_protateTime = 0.6f;
			moveSpeed = 20f;
			crash = 70;
		}



	}

	public void ShotBullet()
	{
		if ( m_HP > 0 )
		{
			m_HP -= bulletCost;
		}
		if (m_HP<= 0)
		{
			LogicDie();
			SetMove(false);
		}
	}
	public void GetHurt(Transform ts)
	{
		// play hurt()
		// add force;
		//protect time
		if (protect)
		{
			return;
		}
		float  addForce = m_AddForce;
		if ((ts.position.x - transform.position.x) > 0)
		{
			addForce = -m_AddForce;
		}
	
		m_Rigidbody2D.AddForce(new Vector2(addForce,0f ));
		protect = true;
		 StartCoroutine(IE_PortectTime());
		
	}

	public void LogicDie()
	{
		// play Die()
		protect = true;
		
	}	

	public void normalAtk()
	{
		// play atk()
		protect = true;
		
	}	

	public void Reborn()
	{
		// play hurt()
		// add force;
		//protect time
		protect = true;
		float  addForce = m_AddForce;
		if (!GetIsForWardRight())
		{
			addForce = -m_AddForce;
		}
		if (!protect)
		{
			m_Rigidbody2D.AddForce(new Vector2(addForce,0f ));
			protect = true;
			StartCoroutine(IE_PortectTime());
		}
	}

	IEnumerator IE_PortectTime()
    {
        // if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        // {
        //     m_AnimatorState = AnimatorState.Idle;
        //     m_Animator.Play(m_Idle);
        // }
        // yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(m_protateTime);
		protect = false;
    }
	IEnumerator IE_Destroy()
    {
        // if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        // {
        //     m_AnimatorState = AnimatorState.Idle;
        //     m_Animator.Play(m_Idle);
        // }
        // yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(1f);
		Destroy(gameObject);
    }
	public bool GetIsForWardRight()
	{
		return (transform.position.x - m_AtkForward.position.x) > 0;
	}
	public void SetMove(bool start)
	{
		if (start)
		{

		}
		else
		{

		}
	}
}