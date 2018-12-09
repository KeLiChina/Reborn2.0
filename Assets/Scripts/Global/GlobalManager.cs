using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour {

   	public static GlobalManager instance { get; set; }
	public Transform m_Player;

	 private List<Role> EnemyRoles =
        new List<Role>(); 
		

	protected void Awake()
    {
        if (GlobalManager.instance == null)
        {
            GlobalManager.instance = this;
        }
        else if (GlobalManager.instance != this)
        {
            Destroy(gameObject);
        }
    }
	 private IEnumerator IE_WaiteAndLoadScene(float t, int sceneID)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(sceneID);
    }
	void Update()
	{
	
	}
	public void AddEnemy(Role role)
	{
		EnemyRoles.Add(role);
	}
	public void RemoveEnemy(Role role)
	{
		EnemyRoles.Remove(role);
	}
	public void SetPlayer(Transform ts)
	{
		m_Player = ts;
	}
	public void GameOver ()
	{
		
	}
	public void GameStart ()
	{
		 StartCoroutine(IE_WaiteAndLoadScene(2f, 0));
	}

	public void SetSoul (GameObject soul)
	{
		for (int i = 0; i < EnemyRoles.Count;i++)
		{
			if (Vector3.Distance(EnemyRoles[i].transform.position,soul.transform.position) < 5)
			{
				EnemyRoles[i].EnemyMove(soul.transform);
			}
		}
	}

	public void RemoveSoul (GameObject soul)
	{
		for (int i = 0; i < EnemyRoles.Count;i++)
		{
			Debug.Log("====Dont not look At sou====");
		}
	}
	

}
 	
