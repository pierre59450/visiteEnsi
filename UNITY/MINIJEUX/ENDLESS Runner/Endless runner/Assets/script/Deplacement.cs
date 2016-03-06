using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Deplacement : MonoBehaviour {
	
	public int i = 0;
	public bool KeyDown = false;
	public float LastAxe = 0;
	
	/**** *******/
	void Update()
	{
		/****  clavier  ****/
		if(((Input.GetKeyDown(KeyCode.LeftArrow))||(Input.GetKeyDown(KeyCode.Q)))
			&& KeyDown !=(Input.GetKeyDown(KeyCode.RightArrow)
				||Input.GetKeyDown(KeyCode.D) 
				||Input.GetKeyDown(KeyCode.LeftArrow)
				||Input.GetKeyDown(KeyCode.Q))
			&& i>=0) 
		{
			i = i - 1;
			Debug.Log("gauche");
		}	
		if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D))
			&& KeyDown !=(Input.GetKeyDown(KeyCode.RightArrow)
				||Input.GetKeyDown(KeyCode.D) 
				||Input.GetKeyDown(KeyCode.LeftArrow)
				||Input.GetKeyDown(KeyCode.Q))
			&& i<=0)
		{
			i = i + 1;
			Debug.Log("droite");
		}
		KeyDown = Input.GetKeyDown(KeyCode.RightArrow)
			||Input.GetKeyDown(KeyCode.D) 
			||Input.GetKeyDown(KeyCode.LeftArrow)
			||Input.GetKeyDown(KeyCode.Q);
		
		/**** pad ****/
		if(Input.GetAxis("GDmenu")<0 && Input.GetAxis("GDmenu") != LastAxe && i>=0) 
		{
			i = i - 1;
		}	
		if(Input.GetAxis("GDmenu")>0 && Input.GetAxis("GDmenu") != LastAxe && i<=0) 
		{
			i = i + 1;
		}
		LastAxe = Input.GetAxis("GDmenu");
		
		
		
		
		
		
		
		/****  mise a jour de la position  ****/
		transform.position = new Vector3(i,1.5F,0);
	}
	
}