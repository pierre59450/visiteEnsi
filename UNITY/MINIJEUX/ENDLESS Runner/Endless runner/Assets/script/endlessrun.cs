using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class endlessrun : MonoBehaviour {

	public Transform road_prefab;
	public Transform obstacle_prefab;
	public Transform bonus_prefab;
	public LinkedList<Transform> roads = new LinkedList<Transform>();
	public LinkedList<Transform> obstacles = new LinkedList<Transform>();
	public LinkedList<Transform> bonus = new LinkedList<Transform> ();

	public float posY = 0.0f;
	public int numberOfRoads = 10;
	public float speed;
	
	public float time_obstacle = -5;
	public float repeate_obstacle = 0.5F;
	public float time_bonus =0;
	public float repeate_bonus = 1.3F;
	public float random;
	public int posX = 0;
	
	public float progression = 0;

	void Start () 
	{
              
        // Init the scene with some road-pieces
        for(int i=0;i < numberOfRoads;i++) 
		{
                Transform road = Instantiate(road_prefab) as Transform;
                road.Translate(0, posY, i * 10);
			//road.parent = road;
                roads.AddLast(road);
        }
		Transform obstacle = Instantiate (obstacle_prefab, new Vector3 (0, 1, 35), Quaternion.identity) as Transform;
		obstacles.AddLast (obstacle);
		Transform bonu = Instantiate (bonus_prefab) as Transform;
		bonus.AddLast (bonu);
	}
	

// Update is called once per frame
	void Update () 
		{
		progression = progression + Time.deltaTime * 0.01f;
		speed = -8f * Time.deltaTime - progression;
			
			
		Transform firstRoad = roads.First.Value;
		Transform lastRoad = roads.Last.Value;
			
		   
		   
		/******* Dynamic road ************/
		// Create a new road if the first one is not
		// in sight anymore and destroy the first one
		if (firstRoad.localPosition.z < -15f) 
		{
			roads.Remove (firstRoad);
			Destroy (firstRoad.gameObject);
				   
			Transform newRoad = Instantiate (road_prefab, new Vector3 (0, posY,
					lastRoad.localPosition.z + 10),
					Quaternion.identity) as Transform;
			roads.AddLast (newRoad);
			   
		}
				   
		// Move the available roads along the z-axis
		foreach (Transform road in roads) 
		{
			road.Translate (0, 0, speed);      
		}
			
			
		/******** Obstacles spawn ***********/
		if (time_obstacle > repeate_obstacle) 
		{
			if (Random.value * 100 > 30) 
			{
				if ((random = Random.value * 100) < 33) 
				{
					posX = -1;
				}
				else if (random < 66)
				{
					posX = 0;
				} 
				else 
				{
					posX = 1;
				}
					
				Transform newObstacle = Instantiate (obstacle_prefab, new Vector3 (posX, 0.75f, 35), Quaternion.identity) as Transform;
				obstacles.AddLast (newObstacle);
			}
			time_obstacle = 0;
		} 
		else 
		{
			time_obstacle = time_obstacle + Time.deltaTime;
		}
		/*** Gestion dynamic des obstacles ***/

		if (obstacles.First.Value.localPosition.z < -15f) 
		{
			if (obstacles.First.Value != obstacles.Last.Value) 
			{
				Debug.Log("obstacle détruit");
				Transform FirstObstacle = obstacles.First.Value;
				obstacles.RemoveFirst();
				Destroy(FirstObstacle.gameObject);
			}
		}
		
		foreach (Transform obstacle in obstacles) 
		{
			obstacle.Translate (0, 0, speed);
		}
		
			/**********  Bonus  *******/

			if (time_bonus > repeate_bonus) 
			{
				if(Random.value * 100 > 25)
				{
					if((random = Random.value * 100) < 33)
					{
						posX = -1;
					}
					else if(random < 66)
					{
						posX = 0;
					}
					else
					{
						posX = 1;
					}

					Transform newBonus = Instantiate(bonus_prefab, new Vector3(posX,1,35), Quaternion.identity) as Transform;
					bonus.AddLast(newBonus);
				}
				time_bonus = 0;
			}
			else
			{
					time_bonus += Time.deltaTime;
			}
			/*** Gestion dynamic des obstacles ***/
			if(bonus.First.Value.localPosition.z < -15f)
			{
				if(bonus.First.Value != bonus.Last.Value)
				{
					Transform firstBonus = bonus.First.Value;
					bonus.RemoveFirst();
					Destroy(firstBonus.gameObject);
				}
			}
			foreach(Transform bonu in bonus)
			{
				bonu.Translate(0,0,speed);
			}



		}
		

}