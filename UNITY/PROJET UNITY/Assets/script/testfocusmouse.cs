using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class testfocusmouse : MonoBehaviour {
    public bool jouer = false;           //affiche le menu après appuye sur jouer
	public bool minijeux = false;        //affiche le menu après appuye sur minijeux
	public bool principal = true;		 //affiche le menu Principale
	public bool KeyDown = false;		 //indique qu'une touche à été présser
	public bool KeyReturn = false;
	public bool ButtonDown = false;      //indique si un bouton de la mannete a été presser
	public string stage = "batA";        //charge la visite
	public string hover="coucou";        //dit sur quel bouton on est
	public int i = 0;                    //position du bouton
	public int Lasti = 0;                //permet de jouer un son des qu'on change de bouton quelque soit le moyen
	public int posx = 0;                 //position de l'affichage des touche
	public float LastAxe = 0;            //permet de ne pas aller trop loin lors du déplacement avec pad dans le menu
	public Texture Titre;
	public Texture Touche;
	public Texture ButtonJouer;
	public Texture ButtonDemo;
	public Texture ButtonQuit;
	public Texture ButtonMiniJeux;
	public Texture ButtonVisite;
	public AudioClip moveButtonSound;
	public AudioClip accepteSound;
	public AudioClip quitSound;
	
	
	
    void OnGUI() {
		
		GUI.Label(new Rect((Screen.width/2) - (Titre.width / 2),(Screen.height/4) , Titre.width, Titre.height),Titre  );
		
		/************************* Gestion des GUI buttons à la souris normale ********************************/
		if(principal)
		{
			if(GUI.Button(new Rect(Screen.width / 50 ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonJouer,"jouer")))
			{
				GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
				principal = false;
				jouer = true;
			}
			if(GUI.Button(new Rect(Screen.width / 2 - Screen.width/8  ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonDemo,"demo")))
			{
				//Application.LoadLevel("demo"); //lance la démo du jeux
				GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
				Debug.Log("chargement de la demo");
			}
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonQuit,"quit")))
			{
				GetComponent<AudioSource>().PlayOneShot(quitSound, 0.7F);
				Application.Quit();
			}
        }
		
		else if(jouer)
		{
			if(GUI.Button(new Rect(Screen.width / 50 ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonVisite,"visite")))
			{
				GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
				Application.LoadLevel(stage); // lance la visite
			}
			if(GUI.Button(new Rect(Screen.width / 2 - Screen.width/8  ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonMiniJeux,"minijeux")))
			{
				GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
				jouer = false;
				minijeux = true;

			}
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonQuit,"annule")))
			{
				GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
				jouer = false;
				principal = true;
			}
		}
		else if ( minijeux) // listing des minijeux
		{
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonQuit,"annule")))
			{
				GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
				jouer = true;
				minijeux = false;
			}
		}
		/**********************************Gestion des GUI buttons au clavier********************************************/
		/**********************************Les bouttons sont numéroté de gauche à droite*********************************/
		
		/*
		apuuyer sur une touche dur 2 frame dans mon cas mais si elle dur plus faire comme avec le pas lastkey!= inputkey;		
		*/
		if (principal&&!KeyDown)
		{
		
			switch(i)
			{
				case 0:
					posx = Screen.width / 50 + Screen.width/8 - Touche.width/8;
					break;
				case -2:
				case 1:
					posx = Screen.width / 2 - Touche.width/8 ;
					break;
				case -1:
				case 2 :
					posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8;
					break;
			}
			if(((Input.GetKeyDown(KeyCode.LeftArrow))||(Input.GetKeyDown(KeyCode.Q)))&& KeyDown !=(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.Q))) 
			{
				i = (i - 1 )% 3;
			}	
			if(((Input.GetKeyDown(KeyCode.RightArrow))||(Input.GetKeyDown(KeyCode.D)))&& KeyDown !=(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.Q))) 
			{
				i =(i + 1 )% 3;
			}

			
			if(Input.GetKeyDown(KeyCode.Return)&& KeyReturn!=Input.GetKeyDown(KeyCode.Return)) // switch case sur i pour avoir la pos et donc le button
			{
				KeyDown = true;
				switch(i)
				{

					case 0:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						principal = false;
						jouer = true;
						break;
					case -2:					
					case 1:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						//Application.LoadLevel("demo"); //lance la démo du jeux
						Debug.Log("chargement de la demo");
						break;
					case -1:
					case 2 :
						GetComponent<AudioSource>().PlayOneShot(quitSound, 0.7F);
						Application.Quit();
						break;
				}

			}
		}
		else if(jouer&&!KeyDown)
		{
			switch(i)
			{
				case 0:
					posx = Screen.width / 50 + Screen.width/8 - Touche.width/8;
					break;
				case -2:
				case 1:
					posx = Screen.width / 2 - Touche.width/8 ;
					break;
				case -1:
				case 2 :
					posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8;
					break;
			}
			if(((Input.GetKeyDown(KeyCode.LeftArrow))||(Input.GetKeyDown(KeyCode.Q)))&& KeyDown !=(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.Q))) 
			{
				i = (i - 1 )%3;
			}	
			if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) )&& KeyDown !=(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.Q)))
			{
				i = (i + 1 )%3;
			}
			
			if(Input.GetKeyDown(KeyCode.Return)&& KeyReturn!=Input.GetKeyDown(KeyCode.Return)) // switch case sur i pour avoir la pos et donc le button
			{
				KeyDown = true;
				switch(i)
				{

					case 0:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						Application.LoadLevel(stage);
						break;
					case -2:					
					case 1:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8;
						i = 0;
						jouer = false;
						minijeux = true;
						
						break;
					case -1:
					case 2 :
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						jouer = false;
						principal = true;
						break;
				}
				
			}
		}
		else if ( minijeux&&!KeyDown) // listing des minijeux
		{
			switch(i)
			{
				case 0:
					posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8;
					break;
				/************ ajouter des cas celon le nb de jeux ***********/
			}
		
			if(((Input.GetKeyDown(KeyCode.LeftArrow))||(Input.GetKeyDown(KeyCode.Q)))&& KeyDown !=(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.Q))) 
			{
				i = 0;//(i - 1 )%3;
			}	
			if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) )&& KeyDown !=(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.Q)))
			{
				i = 0;//(i + 1 )%3;
			}
			
			if(Input.GetKeyDown(KeyCode.Return)&& KeyReturn!=Input.GetKeyDown(KeyCode.Return)) // switch case sur i pour avoir la pos et donc le button
			{

				switch(i)
				{

					case 0:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						minijeux = false;
						jouer = true;
						break;
				/************ ajouter des cas celon le nb de jeux ***********/
				}

			}
		}
		
		KeyReturn = Input.GetKeyDown(KeyCode.Return);

		/**********************************Gestion des GUI buttons au PAD************************************************/
		/**********************************Les bouttons sont numéroté de gauche à droite*********************************/
		if (principal)
		{

			switch(i)
			{
				case 0:
					posx = Screen.width / 50 + Screen.width/8 - Touche.width/8;
					break;
				case -2:
				case 1:
					posx = Screen.width / 2 - Touche.width/8 ;
					break;
				case -1:
				case 2 :
					posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8;
					break;
			}
			if(Input.GetAxis("GDmenu")<0 && Input.GetAxis("GDmenu") != LastAxe) 
			{
				i = (i - 1 )% 3;
			}	
			if(Input.GetAxis("GDmenu")>0 && Input.GetAxis("GDmenu") != LastAxe) 
			{
				i = (i + 1 )% 3;
				
			}
			
			if(Input.GetButton("A") && Input.GetButton("A") != ButtonDown) // switch case sur i pour avoir la pos et donc le button
			{
				switch(i)
				{

					case 0:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						principal = false;
						jouer = true;
						break;
					case -2:					
					case 1:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						//Application.LoadLevel("demo"); //lance la démo du jeux
						Debug.Log("chargement de la demo");
						break;
					case -1:
					case 2 :
						GetComponent<AudioSource>().PlayOneShot(quitSound, 0.7F);
						Application.Quit();
						break;
				}
			}
		}
		else if(jouer)
		{
			switch(i)
			{
				case 0:
					posx = Screen.width / 50 + Screen.width/8 - Touche.width/8;
					break;
				case -2:
				case 1:
					posx = Screen.width / 2 - Touche.width/8 ;
					break;
				case -1:
				case 2 :
					posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8;
					break;
			}
			if(Input.GetAxis("GDmenu")<0 && Input.GetAxis("GDmenu") != LastAxe) 
			{
				i = (i - 1 )% 3;
			}	
			if(Input.GetAxis("GDmenu")>0 && Input.GetAxis("GDmenu") != LastAxe) 
			{
				i = (i + 1 )% 3;
			}
			
			if(Input.GetButton("A") && Input.GetButton("A") != ButtonDown) // switch case sur i pour avoir la pos et donc le button
			{
				switch(i)
				{

					case 0:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						Application.LoadLevel(stage);
						break;
					case -2:					
					case 1:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8;
						i = 0;
						jouer = false;
						minijeux = true;
						
						break;
					case -1:
					case 2 :
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						jouer = false;
						principal = true;
						break;
				}
			}
		}
		else if ( minijeux&&!KeyDown) // listing des minijeux
		{
			switch(i)
			{
				case 0:
					posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8;
					break;
				/************ ajouter des cas celon le nb de jeux ***********/
			}
		
			if(Input.GetAxis("GDmenu")<0 && Input.GetAxis("GDmenu") != LastAxe) 
			{
				i = 0;//(i - 1 )% 3;
			}	
			if(Input.GetAxis("GDmenu")>0 && Input.GetAxis("GDmenu") != LastAxe) 
			{
				i = 0;//(i + 1 )% 3;
			}
			
			if(Input.GetButton("A") && Input.GetButton("A") != ButtonDown) // switch case sur i pour avoir la pos et donc le button
			{
				switch(i)
				{

					case 0:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						minijeux = false;
						jouer = true;
						break;
				/************ ajouter des cas celon le nb de jeux ***********/
				}
			}
		}
		KeyDown = Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.Q);
		LastAxe = Input.GetAxis("GDmenu");
		ButtonDown = Input.GetButton("A");
		hover = GUI.tooltip;
		if(hover == "jouer" || hover == "visite"){posx = Screen.width / 50 + Screen.width/8 - Touche.width/8; i = 0;}
		if(hover == "demo" || hover == "minijeux"){posx = Screen.width / 2 - Touche.width/8 ; i = 1;}
		if(hover == "annule"|| hover == "quit"){posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8; i = 2;}
		
		GUI.Label(new Rect(posx, 7 * Screen.height/8 , Touche.width/4, Touche.height/4),Touche  );
		//GUI.Label(new Rect(10,10,Screen.width/8,Screen.height/8),""+System.Convert.ToString(i));
	}
	
	void Update () 
	{
		if(i != Lasti)
		{
				GetComponent<AudioSource>().PlayOneShot(moveButtonSound, 0.7F);
				//Debug.Log("tooltip :"+hover);
		}
		Lasti = i;
	}
}