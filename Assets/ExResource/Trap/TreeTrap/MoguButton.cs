using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguButton : MonoBehaviour {

// private Vector3 down = new Vector3(0,0.)
	public OldTree m_OldTree;
	 void OnTriggerEnter2D(Collider2D obj)
    {
        if (GlobalManager.instance.m_Player == obj.transform)
        {
           
        //   StartCoroutine(IE_MOgu());
			m_OldTree.Shoot();
			Destroy(gameObject);
        }


       


    }
// IEnumerator IE_MOgu()
//     {
  
// 		while(true)
// 		{
//   			yield return new WaitForSeconds(Time.deltaTime);
// 			transform.Translate(Vector3.down*(Time.deltaTime * 80));
			
// 		}
		
//     }
 }
