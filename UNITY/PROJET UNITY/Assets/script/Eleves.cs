using UnityEngine;
using System.Collections;



public class Eleves : MonoBehaviour {

	public int etat = 0;
	public double time = 0;
	public double repeate = 0.5F;

	

	void Update()
	{
		if(time>repeate)
		{
			if(Random.value * 100 > 95)//proba a changé selon difficulté
			{
				etat = 1;
			}
			if (etat == 1)
			{
				transform.rotation = Quaternion.Euler(0,180,0);
				//renderer.material.color = new Color(255,0,0);
			}
			if (etat == 0)
			{
				transform.rotation = Quaternion.Euler(0,0,0);
				//renderer.material.color = new Color(1,1,1);
			}
			time = 0;
		}
		else
		{
			time = time + Time.deltaTime;
		}
	}
	



}