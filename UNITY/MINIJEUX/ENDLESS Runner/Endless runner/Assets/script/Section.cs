
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
public class Section : GameObject
{
	public Transform road;
	public List<Transform> obstacles = new LinkedList<Transform>();
	public List<Transform> bonus = new LinkedList<Transform> ();

	public Transform road_prefab;
	public Transform obstacle_prefab;
	public Transform bonus_prefab;

	public Section (Matrice mat)
	{
		road = Instantiate(road_prefab) as Transform;
		road.parent = this;

		for (int i = 0; i < mat.length; i++) 
		{
			for(int j = 0; j < mat.large; j++)
			{
				if(mat.tab[i][j] == 1)
				{
					Transform obstacle = Instantiate(obstacle_prefab, new Vector3(2,3,4),Quaternion.identity);
					obstacle.parent = this;
					obstacles.Add(obstacle);
				}
				if(mat.tab[i][j] == 2)
				{
					Transform bonu = Instantiate(bonus_prefab, new Vector3(2,3,4),Quaternion.identity);
					bonu.parent = this;
					bonus.Add(bonu);
				}
			}
		}
	}
}

*/


/* créer une setion composer d'une route, de plusieur obstacles et bonus
 * 
 * la déplacer puis la détruire
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */