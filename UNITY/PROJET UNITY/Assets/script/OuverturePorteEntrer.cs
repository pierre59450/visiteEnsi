using UnityEngine;
using System.Collections;

public class OuverturePorteEntrer : MonoBehaviour {

	public bool affiche = false;
    	public Texture OpenClose;
	public bool anime = false;
	public bool open = false;
	public float elapsedTime = 0;
	public float Delay;
	public GameObject porte1;
	public GameObject porte2;
	
		
    	void Update()
	{
			if (anime==true && open == false)
			{
					
				if(elapsedTime< Delay) 
				{
					porte1.transform.Translate(new Vector3(-(Time.deltaTime*0.18F*2 ),0,0) );
					porte2.transform.Translate(new Vector3((Time.deltaTime*0.18F*2),0,0) );
					elapsedTime += Time.deltaTime*2;
				}
				else
				{
					open=true;
					anime=false;
					elapsedTime = 0;
				}
			}
			if (anime==true && open == true)
			{
					
				if(elapsedTime< Delay) 
				{
					porte1.transform.Translate(new Vector3((Time.deltaTime*0.18F*2 ),0,0) );
					porte2.transform.Translate(new Vector3(-(Time.deltaTime*0.18F*2),0,0) );
					elapsedTime += Time.deltaTime*2;
				}
				else
				{
					open=false;
					anime=false;
					elapsedTime = 0;
				}
			}
			
   	}
 
	void OnTriggerEnter(Collider other) 
	{
		if(!open)
		{
			anime= true;
		}
	}
	
	void OnTriggerExit(Collider other) 
	{
		if(open)
		{
			anime= true;
		}
    }
}