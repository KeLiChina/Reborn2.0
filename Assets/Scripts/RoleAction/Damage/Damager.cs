using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

	public int m_DamagerType;// 1 灵魂 2 普通攻击
	private Role m_Role;
	private BoxCollider2D m_BoxCollider2D;
	void Start () {
		m_Role = transform.GetComponentInParent<Role>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTrigger2DEnter(Collider2D obj)
	{
		Role objRole = obj.transform.GetComponentInParent<Role>();
		if (objRole.m_RoleType != m_Role.m_RoleType)
		{
			if (obj.tag == "forward")
			{
				objRole.GetHurt(m_Role.transform);
			}
			else if (obj.tag == "back")
			{
					
			}
		}
	}

	private void DestroySelf()
	{
		Destroy(gameObject);
	}
}
