using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class endlessrun : MonoBehaviour {
	public Transform prefab;
	public Transform obstacle;
	public Transform _obstacle;
	public LinkedList<Transform> roads = new LinkedList<Transform>();
	public float posY = 0.0f;
	public int numberOfRoads = 10;
	public bool spone = false;
	public float speed;

	void Start () {
              
        // Init the scene with some road-pieces
        for(int i=0;i < numberOfRoads;i++) {
                Transform road = Instantiate(prefab) as Transform;
                road.Translate(0, posY, i * 9);
                roads.AddLast(road);
        }
	}
	

// Update is called once per frame
void Update () 
	{
		speed = -8f * Time.deltaTime;
        Transform firstRoad = roads.First.Value;
        Transform lastRoad = roads.Last.Value;
       
        // Create a new road if the first one is not
        // in sight anymore and destroy the first one
        if(firstRoad.localPosition.z < -20f) 
		{
                roads.Remove(firstRoad);
                Destroy(firstRoad.gameObject);
               
                Transform newRoad = Instantiate(prefab, new Vector3(0, posY ,
					lastRoad.localPosition.z + 9),
					Quaternion.identity) as Transform;
                roads.AddLast(newRoad);
                       
        }
               
        // Move the available roads along the z-axis
        foreach(Transform road in roads) {
                road.Translate(0,0, speed);      
        }

		
		
		
		//spone obstacle
		if(!spone){
		_obstacle = Instantiate(obstacle, new Vector3(0,1,50),Quaternion.identity) as Transform;
		spone = true;
		}
		_obstacle.Translate(0,0,speed);

	}

	
}