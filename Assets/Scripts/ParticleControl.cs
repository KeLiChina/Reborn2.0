using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour {
    public float value = 0f;
    public ParticleSystem playerSoulFire;
	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
        ParticleSystem.EmissionModule emission = playerSoulFire.emission;
        emission.rate = new ParticleSystem.MinMaxCurve(value);
    }

    public void ChangeFire(float value)
    {
        ParticleSystem.EmissionModule emission = playerSoulFire.emission;
        emission.rate = new ParticleSystem.MinMaxCurve(value);

    }
}
