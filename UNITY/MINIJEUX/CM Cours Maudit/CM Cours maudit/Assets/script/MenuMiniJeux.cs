using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MenuMiniJeux : MonoBehaviour {


	public bool principal = true;		 
	public bool regles = false;		 


	public bool KeyDown = false;		 //indique qu'une touche à été présser
	public bool KeyReturn = false;
	public bool ButtonDown = false;      //indique si un bouton de la mannete a été presser

	public string jeu = "jeu_prof";        
	public string visite = "batA";       
	public string hover="coucou";        //dit sur quel bouton on est
	public int i = 0;                    //position du bouton
	public int Lasti = 0;                //permet de jouer un son des qu'on change de bouton quelque soit le moyen
	public int posx = 0;                 //position de l'affichage des touche
	public float LastAxe = 0;            //permet de ne pas aller trop loin lors du déplacement avec pad dans le menu
	
	
	public Texture Titre;
	public Texture Touche;
	public Texture Rules;
	public Texture ButtonJouer;
	public Texture ButtonRegles;
	public Texture ButtonQuit;
	
	

	public AudioClip moveButtonSound;
	public AudioClip accepteSound;
	public AudioClip quitSound;
	
	void start()
	{
		Cursor.visible = true;
	}
	
	
    void OnGUI() {
		
		GUI.Label(new Rect((Screen.width/2) - (Titre.width / 2),(Screen.height/4) , Titre.width, Titre.height),Titre  );
		
		/************************* Gestion des GUI buttons à la souris normale ********************************/
		if(principal)
		{
			if(GUI.Button(new Rect(Screen.width / 50 ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonJouer,"jouer")))
			{
				GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
				Application.LoadLevel(jeu); // lance le jeu
			}
			if(GUI.Button(new Rect(Screen.width / 2 - Screen.width/8  ,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonRegles,"regles")))
			{
				GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
				regles = !regles;
			}
			if(GUI.Button(new Rect(Screen.width - Screen.width / 50 - Screen.width/4,3 * Screen.height/4,Screen.width/4, Screen.height/6), new GUIContent(ButtonQuit,"quit")))
			{
				GetComponent<AudioSource>().PlayOneShot(quitSound, 0.7F);
				Application.LoadLevel(visite); 
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
						Application.LoadLevel(jeu); // lance le jeu
						break;
					case -2:					
					case 1:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						regles = !regles;
						break;
					case -1:
					case 2 :
						GetComponent<AudioSource>().PlayOneShot(quitSound, 0.7F);
						Application.LoadLevel(visite); 
						break;
				}

			}
		}
		KeyDown = Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.Q);
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
						Application.LoadLevel(jeu); // lance le jeu
						break;
					case -2:					
					case 1:
						GetComponent<AudioSource>().PlayOneShot(accepteSound, 0.7F);
						regles = !regles;
						break;
					case -1:
					case 2 :
						GetComponent<AudioSource>().PlayOneShot(quitSound, 0.7F);
						Application.LoadLevel(visite); 
						break;
				}
			}
		}
		if(regles)
		{
			GUI.Label(new Rect( Screen.width / 2 - Rules.width / 2 , Screen.height / 2  - Rules.height / 2, Rules.width,Rules.height),  Rules);//x,y = coin haut gauche d'image puis larger et longuer
		}
		
		LastAxe = Input.GetAxis("GDmenu");
		ButtonDown = Input.GetButton("A");
		hover = GUI.tooltip;
		if(hover == "jouer"){posx = Screen.width / 50 + Screen.width/8 - Touche.width/8; i = 0;}
		if(hover == "regles"){posx = Screen.width / 2 - Touche.width/8 ; i = 1;}
		if(hover == "quit"){posx = Screen.width - Screen.width / 50 - Screen.width/8 - Touche.width/8; i = 2;}
		
		GUI.Label(new Rect(posx, 7 * Screen.height/8 , Touche.width/4, Touche.height/4),Touche  );
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