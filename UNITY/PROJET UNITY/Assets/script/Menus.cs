using UnityEngine;
using System.Collections;


public class Menus  : MonoBehaviour {

	public bool jouer = false;
	public bool minijeux = false;
	public bool principal = true;
	public string stage = "batA";
	public Texture Titre;
	public Texture ButtonJouer;
	public Texture ButtonDemo;
	public Texture ButtonQuit;
	public Texture ButtonMiniJeux;
	public Texture ButtonVisite;
	
	
	
    void OnGUI() {
		GUI.Label(new Rect((Screen.width/2) - (Titre.width / 2),(Screen.height/4) , Titre.width, Titre.height),Titre  );
		
		if(principal)
		{
			if(GUI.Button(new Rect(Screen.width / 50 ,3 * Screen.height/4,Screen.width/4, Screen.height/6), ButtonJouer))
			{
				principal = false;
				jouer = true;
			}
			if(GUI.Button(new Rect(Screen.width / 2 - Screen.width/8  ,3 * Screen.height/4,Screen.width/4, Screen.height/6), ButtonDemo))
			{
				//Application.LoadLevel("demo"); //lance la démo du jeux
				Debug.Log("chargement de la demo");
			}
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), ButtonQuit))
			{
				Application.Quit();
			}
        }
		
		else if(jouer)
		{
			if(GUI.Button(new Rect(Screen.width / 50 ,3 * Screen.height/4,Screen.width/4, Screen.height/6), ButtonVisite))
			{
				Application.LoadLevel(stage); // lance la visite
			}
			if(GUI.Button(new Rect(Screen.width / 2 - Screen.width/8  ,3 * Screen.height/4,Screen.width/4, Screen.height/6), ButtonMiniJeux))
			{
				jouer = false;
				minijeux = true;

			}
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), ButtonQuit))
			{
				jouer = false;
				principal = true;
			}
		}
		else if ( minijeux) // listing des minijeux
		{
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), ButtonQuit))
			{
				jouer = true;
				minijeux = false;
			}
		
		
		}		
    }
}