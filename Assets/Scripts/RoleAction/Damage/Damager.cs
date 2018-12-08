using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DAMAGER_TYPE
{
	NULL = -1,
    NORMAL = 0,
    SOUL = 1,
    SIZE
}
public class Damager : MonoBehaviour {

	public DAMAGER_TYPE m_DamagerType = DAMAGER_TYPE.NULL;// 1 灵魂 2 普通攻击
	private Role m_Role;
	private BoxCollider2D m_BoxCollider2D;
	public GameObject soul;
	void Start () {
		m_Role = transform.GetComponentInParent<Role>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D obj)
	{
		Role objRole = obj.transform.GetComponentInParent<Role>();
		if (objRole == null || objRole.m_RoleType != m_Role.m_RoleType)
		{
			if (m_DamagerType == DAMAGER_TYPE.SOUL) 
			{
				if (obj.tag == "plane")
				{
					GameObject sou = Instantiate(soul,transform.position,transform.rotation);
					

				}
			}
			else if (m_DamagerType == DAMAGER_TYPE.NORMAL)
			{
				if (obj.tag == "forward")
				{
					objRole.GetHurt(m_Role.transform);
				}
					else if (obj.tag == "back")
				{
					objRole.LogicDie();
				}
			}
			
		}
	}

	private void DestroySelf()
	{
		Destroy(gameObject);
	}
}
