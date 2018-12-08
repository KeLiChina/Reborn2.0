using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour {

	private Transform  m_TF;
	private bool isDown = true;
	void Awake () {
		m_TF = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalManager.instance.GetG() == true && isDown)
		{
			m_TF.transform.Rotate(0,0,180);
			isDown= false;
			Debug.Log("Enter========1111");
		}
		if(GlobalManager.instance.GetG() == false && isDown == false){
			m_TF.transform.Rotate(0,0,0);
			isDown = true;
			Debug.Log("Enter========2222");
		}

	}
}
