using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class AirplaneAgents : Agent {
	
	public GameObject Airplane;
	
	public GameObject Enemyplace;
	
	public GameObject Game;
	
	float Ax;
	
	float Ay;
	
	float Az;
	
	float Ex;
	
	float Ez;
	
	//int EnemyMove = 1;
	
	float Distance2;
	
	int Move;
	
	public Arrivalplace Ap;


	public override void InitializeAgent()
	{
		Ap = Enemyplace.GetComponent<Arrivalplace>();
	}


    public override void CollectObservations()
    {
		AddVectorObs(Ax);
		AddVectorObs(Ay);
		AddVectorObs(Az);
		AddVectorObs(Ex);
		AddVectorObs(Ez);
    }
    
    public void MoveAgent(float[] act)
    {
    	Move = Mathf.FloorToInt(act[0]);
    	
    	if(Move == 1)
    	{
    		transform.Translate(-0.05f, 0, 0);
    	}
    	
    	if(Move == 2)
    	{
    		transform.Translate(0.05f, 0, 0);
    	}
    	
    	if(Move == 3)
    	{
    		transform.Translate(0, 0, 0.05f);
    	}
    	
    	if(Move == 4)
    	{
    		transform.Translate(0, 0, -0.05f);
    	}
    	
    	if(Move == 5)
    	{
    		transform.Translate(0, 0.05f, 0);
    	}
    	
    	if(Move == 6)
    	{
    		transform.Translate(0, -0.05f, 0);
    	}
    	
    }
    
   // public void EnemyMoveAgent(float[] act2)
   // {
    
    	//if(Enemyplace.transform.position.z > -2.0)
    	//{
    		//EnemyMove = 2;
    	//}else if(Enemyplace.transform.position.z < -4.5)
    		//{
    			//EnemyMove = 1;
    		//}
    	
    	//if(EnemyMove == 1)
    //	{
    		//Enemyplace.transform.Translate(0, 0, 0.01f);
    	//}
    	
    	//if(EnemyMove == 2)
    	//{
    		//Enemyplace.transform.Translate(0, 0, -0.01f);
    	//}
    	
   // }

    public override void AgentAction(float[] vectorAction, string textAction)
	{
		MoveAgent(vectorAction);
		
		//EnemyMoveAgent(vectorAction);
		
		hit();
		
		Ax = transform.position.x;
		
		Ay = transform.position.y;
		
		Az = transform.position.z;
		
		Ex = Enemyplace.transform.position.x;
		
		Ez = Enemyplace.transform.position.z;
		
		if(-2.0 < Ax || Ax < -4.6)
		{
			AddReward(-1.0f);
			Done();
		}
		
		if(-4.0 > Az || Az > -1)
		{
			AddReward(-1.0f);
			Done();
		}
		
		if(0.5 > Ay || Ay > 1.6)
		{
			AddReward(-1.0f);
			gameObject.transform.parent = Game.transform;
			Done();
		}
    }
    
    	
    public void hit()
    {
    	if(Ap.attatch == 2)
    	{
    		AddReward(0.01f);
    		if(Move == 0)
    		{
    			AddReward(1.0f);
    		}else if(Move == 1 || Move == 2 || Move ==3 || Move ==4 || Move == 5 || Move == 6)
    		{
    			AddReward(0.01f);
    		}
    	}
    }
    
  //  public void OnTriggerStay(Collider other)
   // {
    	//if(other.gameObject.tag == "Player")
		//{
		//	float Distance = Vector3.Distance(Enemyplace.transform.position, transform.position);
			
			//if(Distance < 1)
			//{
				//AddReward(0.01f);
		//	}else if(Distance >= 1)
			//{
			//	AddReward((1 / Distance) * 0.1f);
		//	}
		//}
	//}
	
	//public void Raycast()
	//{
		//Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));
		
		//RaycastHit hit;
		
		//int distance = 10;
		
		//Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);
		
		//if(Physics.Raycast(ray, out hit, distance))
		//{
			//if(hit.collider.tag == "Player")
			//{
				//Distance2 = Vector3.Distance(hit.transform.position, transform.position);
				//if(Distance2 < 0.45f)
				//{
					//gameObject.transform.parent = Enemyplace.transform;
					//Debug.Log(Distance2);
					//AddReward(0.9f);
					//if(Move == 0)
					//{
						//AddReward(1.0f);
					//}	
				//}else{
					//gameObject.transform.parent = Game.transform;
				//}
			//}
		//}
		
	//}
	
	//public void OnTriggerExit(Collider other)
	//{
		//if(other.gameObject.tag == "Player")
		//{
			//AddReward(-0.1f);
		//}
	//}

    public override void AgentReset()
    {
		transform.position = new Vector3(-3.0f, 1.2f, -3.0f);
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    public override void AgentOnDone()
    {

    }
}
