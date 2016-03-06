using UnityEngine;
using System.Collections;

public class LoadMiniJeu : MonoBehaviour {

	public bool affiche = false;
	public string stage = "batA";
    public Texture Interaction;
	public Texture Confirme;
	public Texture Oui;
	public Texture Non;
	public Texture Accept;
	public Texture Refus;
	public Texture NomJeux;
	public bool rule = false;
	public bool load = false;
	public Collider Player;


 
	void OnTriggerEnter(Collider other) 
	{
		affiche = true;
		Player = other;
	}
	
	void OnTriggerExit(Collider other) 
	{
		affiche = false;
		rule = false;
		Player = other;
	}

    void OnGUI() {

		if(affiche == true){
			GUI.Label(new Rect((Screen.width/2)-50 , (Screen.height / 2) + (Screen.height / 4) , 100, 100),  Interaction);//x,y = coin haut gauche d'image puis larger et longuer
			if (Input.GetKeyDown(KeyCode.E) || Input.GetButton("X"))
			{			
				rule = true;
			}
		}
		if (rule == true)
		{
			Cursor.visible = true;
			(Player.gameObject.GetComponent("CharacterMotor") as MonoBehaviour).enabled=false;//déclanche warning
			(Player.gameObject.GetComponent("MouseLookByPV") as MonoBehaviour).enabled=false;
			(Player.gameObject.GetComponent("Pause") as MonoBehaviour).enabled=false;
			
			affiche = false;
			
			GUI.Box(new Rect( Screen.width /8 , Screen.height / 8  , Screen.width *6/8 ,Screen.height*6 / 8), Confirme);//x,y = coin haut gauche d'image puis larger et longuer
			GUI.Label(new Rect( Screen.width/2 - NomJeux.width/2,Screen.height/2 - NomJeux.height/2 ,NomJeux.width,NomJeux.height), NomJeux);
			GUI.Label(new Rect( Screen.width / 2 - Screen.width/8 -Accept.width/4 ,7 * Screen.height/8 ,Accept.width/2, Accept.height/2),Accept);
			GUI.Label(new Rect( Screen.width / 2 + Screen.width/8 -Refus.width/4 ,7 * Screen.height/8 ,Refus.width/2, Refus.height/2),Refus);
			if(Input.GetKeyDown(KeyCode.Return)||Input.GetButton("A")||GUI.Button(new Rect(Screen.width / 2 - Screen.width/4 ,5 * Screen.height/8,Screen.width/4, Screen.height/6), Oui))
			{
				Application.LoadLevel(stage);
			}
			else if(Input.GetKeyDown(KeyCode.A) || Input.GetButton("B")||GUI.Button(new Rect(Screen.width / 2 ,5 * Screen.height/8,Screen.width/4, Screen.height/6), Non))
			{
				affiche = true;
				rule = false;
				(Player.gameObject.GetComponent("CharacterMotor") as MonoBehaviour).enabled=true;
				(Player.gameObject.GetComponent("MouseLookByPV") as MonoBehaviour).enabled=true;
				(Player.gameObject.GetComponent("Pause") as MonoBehaviour).enabled=true;
				Cursor.visible = false;

			}
		}
    }
}