using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class button_mouseOn  : MonoBehaviour {

	public bool jouer = false;
	public bool minijeux = false;
	public bool principal = true;
	public bool play = false;
	public string stage = "test";
	public string lasthover = "";
	public Texture Titre;
	public Texture ButtonJouer;
	public Texture ButtonDemo;
	public Texture ButtonQuit;
	public Texture ButtonMiniJeux;
	public Texture ButtonVisite;
	public string hover="coucou";
	public AudioClip impact;
	
    void OnGUI()
	{
		GUI.Label(new Rect((Screen.width/2) - (Titre.width / 2),(Screen.height/4) , Titre.width, Titre.height),Titre  );
		
		if(principal)
		{
			if(GUI.Button(new Rect(Screen.width / 50 ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonJouer,"jouer")))
			{
				principal = false;
				jouer = true;
			}
			if(GUI.Button(new Rect(Screen.width / 2 - Screen.width/8  ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonDemo,"demo")))
			{
				//Application.LoadLevel("demo"); //lance la démo du jeux
				Debug.Log("chargement de la demo");
			}
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonQuit,"quit")))
			{
				Application.Quit();
			}
        }
		
		else if(jouer)
		{
			if(GUI.Button(new Rect(Screen.width / 50 ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonVisite,"visite")))
			{
				Application.LoadLevel(stage); // lance la visite
			}
			if(GUI.Button(new Rect(Screen.width / 2 - Screen.width/8  ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonMiniJeux,"minijeux")))
			{
				jouer = false;
				minijeux = true;

			}
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonQuit,"annule")))
			{
				jouer = false;
				principal = true;
			}
		}
		else if ( minijeux) // listing des minijeux
		{
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonQuit,"annule")))
			{
				jouer = true;
				minijeux = false;
			}
		
		
		}
		hover = GUI.tooltip;
	}
	void Update () 
	{
		if(hover != "")
		{
			if(hover!=lasthover)
			{
				GetComponent<AudioSource>().PlayOneShot(impact, 0.7F);
				Debug.Log("tooltip :"+hover);
				lasthover = hover;
				play = true;
			}
		}
	}
	

}
