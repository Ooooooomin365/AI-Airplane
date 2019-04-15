using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrivalplace : MonoBehaviour {

	public GameObject Airplane;
	
	public GameObject Game;
	
	public int attatch = 1; 

	public void OnCollisionStay(Collision other)
	{
		if(other.gameObject.tag == "Airplane")
		{
			Debug.Log("Collision");
			attatch = 2;
		}
	}
	
	public void OnCollisionExit(Collision other)
	{
		if(other.gameObject.tag =="Airplane")
		{
			Debug.Log("out");
			attatch = 1;
		}
	}
}
