using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class Enemyplace : Agent {
	
	public GameObject Airplane;

	// Use this for initialization
	void Start () {
		
	}
	
	public void OnCollisionStay(Collision other){
		if(other.gameObject.tag == "Airplane")
		{
			Debug.Log("Collision");
			AddReward(1.0f);
		}
	}
	
	public void OnCollisionExit(Collision other){
		if(other.gameObject.tag == "Airplane")
		{
			Debug.Log("Out");
			AddReward(-0.5f);
		}
	}
}
