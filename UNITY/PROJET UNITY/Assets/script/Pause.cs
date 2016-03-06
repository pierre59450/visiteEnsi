using UnityEngine;
using System.Collections;


public class Pause  : MonoBehaviour {

	public bool Pauses = false;
	public Texture ButtonPlay;
	public Texture ButtonQuit;
	public Texture ButtonPause;
	public Texture Accept;
	public Texture Refus;
	
	void start()
	{
		Cursor.visible = false;
	}
	
	void OnGUI()
	{

		if( Input.GetKeyDown (KeyCode.Escape) || Input.GetButton("start") )
		{
			Pauses = true;
		}
		if(Pauses)
		{
			Cursor.visible = true;
			(gameObject.GetComponent("CharacterMotor") as MonoBehaviour).enabled=false;
			(gameObject.GetComponent("MouseLookByPV") as MonoBehaviour).enabled=false;
			
			GUI.Box(new Rect(Screen.width / 8, Screen.height / 8, 6*Screen.width/8,6*Screen.height/8), ButtonPause );
			
			
			GUI.Label(new Rect( Screen.width / 2 - Screen.width/8 -Accept.width/4 ,7 * Screen.height/8 ,Accept.width/2, Accept.height/2),Accept);
			GUI.Label(new Rect( Screen.width / 2 + Screen.width/8 -Refus.width/4 ,7 * Screen.height/8 ,Refus.width/2, Refus.height/2),Refus);
			if(Input.GetKeyDown(KeyCode.Return)||Input.GetButton("A")||GUI.Button(new Rect(Screen.width / 2 - Screen.width/4 ,5 * Screen.height/8,Screen.width/4, Screen.height/6), ButtonPlay))
			{
				(gameObject.GetComponent("CharacterMotor") as MonoBehaviour).enabled=true;
				(gameObject.GetComponent("MouseLookByPV") as MonoBehaviour).enabled=true;
				Cursor.visible = false;
				Pauses = false;
			}
			else if(Input.GetKeyDown(KeyCode.A) || Input.GetButton("B")||GUI.Button(new Rect(Screen.width / 2 ,5 * Screen.height/8,Screen.width/4, Screen.height/6), ButtonQuit))
			{
				Application.LoadLevel("menuPierre");
			}
			
			
			/*if(GUI.Button(new Rect(1 * Screen.width / 8 + ButtonPlay.width / 2 , 3 * Screen.height / 8,ButtonPlay.width,ButtonPlay.height),ButtonPlay))
			{
				(gameObject.GetComponent("CharacterMotor") as MonoBehaviour).enabled=true;
				(gameObject.GetComponent("MouseLookByPV") as MonoBehaviour).enabled=true;
				Pauses = false;
			}
			
			if(GUI.Button(new Rect(5 * Screen.width / 8 , 3 * Screen.height / 8,ButtonQuit.width,ButtonQuit.height),ButtonQuit))
			{
				Application.LoadLevel("menuPierre");
			}*/
		}
	}
}