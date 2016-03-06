using UnityEngine;
using System.Collections;

public class OuverturePorteTrigo : MonoBehaviour {

	public bool affiche = false;
//public Texture ;
	public bool anime = false;
	public bool open = false;
	public float elapsedTime = 0;
	public float Delay = 8;
	public GameObject porte1;
	
		
    void Update()
	{
			if (anime==true && open == false)
			{
					
				if(elapsedTime< Delay) 
				{

					elapsedTime += Time.deltaTime*5;
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
					transform.Rotate(Vector3.up , 1);
					elapsedTime += Time.deltaTime*5;
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
		affiche = true;
	}
	
	void OnTriggerExit(Collider other) 
	{
		affiche=false;
    }

    void OnGUI() {

		if(affiche == true){
			//GUI.Label(new Rect((Screen.width/2)-50 , (Screen.height / 2) + (Screen.height / 4) , 100, 100),  textureToDisplay);//x,y = coin haut gauche d'image puis larger et longuer
			if (Input.GetKeyDown (KeyCode.E)||Input.GetButton("A"))
			{			
				anime=true;
			}
		}
    }
}