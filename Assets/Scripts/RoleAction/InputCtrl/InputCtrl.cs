﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCtrl : MonoBehaviour {

	private RoleMovment m_RoleMovment;
	private Role m_Role;
	public bool _g = false;
	Rigidbody2D rb2D ;
	private RoleMovment m_RM;
	private bool isRun = false;
	Animator m_anima;


	void Awake () {
		m_RoleMovment = gameObject.GetComponent<RoleMovment>();
		rb2D = gameObject.GetComponent<Rigidbody2D>();
		m_RM = gameObject.GetComponent<RoleMovment>();
		m_anima = GetComponent<Animator>();
		m_Role = GetComponent<Role>();

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GlobalManager.instance.m_Player != transform)
		{
			return;
		}
		CameraMove.Instance.changeTarget(GlobalManager.instance.m_Player);
		m_RoleMovment.OnJump(Input.GetButtonDown("Jump"));
		
		// if (GlobalManager.instance.isG)
		// {
		// 	rb2D.gravityScale = -3;
			
		// }else
		// 	rb2D.gravityScale = 3;
			
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			m_RM.runSpeed = 80;
			isRun = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			m_RM.runSpeed = 10;
			
			isRun = false;
			m_anima.Play("Player_Idle");
		}
	
	if (isRun) 
	{
		m_RoleMovment.OnMove( Input.GetAxisRaw("Horizontal"),"IsAttack");
		m_RoleMovment.OnAttack(true);
	}else
	{
		m_RoleMovment.OnMove( Input.GetAxisRaw("Horizontal"),"Speed");
		m_RoleMovment.OnAttack(false);
	
		// m_anima.Play("Player_Idle");
	}
	
	if (Input.GetKeyDown(KeyCode.C))
		{
			
			m_Role.soulAtk();
		}
	
	if (Input.GetKeyDown(KeyCode.Space))
		{
			
		GlobalManager.instance.GameStart();
		}
	}
}
