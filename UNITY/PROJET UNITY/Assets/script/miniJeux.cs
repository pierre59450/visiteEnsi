using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class miniJeux : MonoBehaviour {

	public GameObject[] eleves = new GameObject[8];
	public GameObject prof;
	public GameObject Cible;
	public bool Anime = false;
	public bool Retourne = false;
	public bool atireT = false;
	public bool atireB = false;
	public bool ButtonDown = false;
	public Slider life;
	public bool GameOver = false;
	public Texture GameOverImg;
	public Texture WinImg;
	public float timer = 55;
	public bool Win = false;
	public bool Fin = false;
	public int Score = 0;
	public Texture ImgScore;
	public Texture ButtonRejouer;
	public Texture ButtonQuit;
	public string rejouer = "jeu_prof";
	public string quitter = "menuMiniJeux";
	public string hover="coucou";
	public bool indicateur = true;
	public bool KeyDown;		 //indique qu'une touche à été présser
	public bool KeyReturn = false;
	public Texture Touche;
	public int Lasti = 0;                //permet de jouer un son des qu'on change de bouton quelque soit le moyen
	public int posx = 0;                 //position de l'affichage des touche
	public float LastAxe = 0;            //permet de ne pas aller trop loin lors du déplacement avec pad dans le menu
	
	 public Font MyFont;
	
	void Start()
	{	
		Cursor.visible = false;
		eleves[1] = Instantiate(eleves[1], new Vector3(-0.13F, 5, 1), Quaternion.identity) as GameObject;
		eleves[2] = Instantiate(eleves[2], new Vector3(5.53F, 5, 1), Quaternion.identity) as GameObject;
		eleves[3] = Instantiate(eleves[3], new Vector3(-5.71F, 5, 1), Quaternion.identity) as GameObject;
		eleves[4] = Instantiate(eleves[4], new Vector3(-0.26F, 8, 7), Quaternion.identity) as GameObject;
		eleves[5] = Instantiate(eleves[5], new Vector3(-4.2F, 8, 7), Quaternion.identity) as GameObject;
		eleves[6] = Instantiate(eleves[6], new Vector3(-8.7F, 8, 7), Quaternion.identity) as GameObject;
		eleves[0] = Instantiate(eleves[0], new Vector3(4.17F, 8, 7), Quaternion.identity) as GameObject;
		eleves[7] = Instantiate(eleves[7], new Vector3(8.5F, 8, 7), Quaternion.identity) as GameObject;
		
		prof = Instantiate(prof, new Vector3(11.07F, 1.31F, -5), Quaternion.identity) as GameObject;
		Cible = Instantiate(Cible, new Vector3(0, 5, -1), Quaternion.identity) as GameObject;
		Cible.GetComponent<Renderer>().enabled = false;
		life.value = 100F;

	}
	
	void Update()
	{
		if(!GameOver && !Win)
		{
			timer = timer - Time.deltaTime;
				
		
			if( Input.GetKeyDown(KeyCode.Space) || Input.GetButton("A") && Input.GetButton("A") != ButtonDown )
			{
				Anime = true;
				Retourne = !Retourne;
			}
			if(Anime)
			{
				RetourneProf();
			}
			ButtonDown = Input.GetButton("A");
			for(int i=0;i<8;i++)
			{
				Eleves script = eleves[i].GetComponent<Eleves>();
				if(script.etat!=0)
				{
					life.value = life.value - 0.25F * Time.deltaTime;
				}
			}
			if(Retourne)
			{
				life.value = life.value - 1.5F * Time.deltaTime;
			}
			
			/**** pour tirer sur les eleves ***/
			if (Retourne && Input.GetButton("Fire1") && atireT != Input.GetButton("Fire1") )
			{
				deplacerCible ScriptCible = Cible.GetComponent<deplacerCible>();
				if(ScriptCible.Eleve)
				{
					if(ScriptCible.Eleve.GetComponent<Eleves>().etat != 0)
					{
						ScriptCible.Eleve.GetComponent<Eleves>().etat = 0;
						Debug.Log("Good Shot");
					}
					else
					{
						Debug.Log("tu es mauvais");
						life.value = life.value - 1;
					}
				}
			}
			else if (Retourne && Input.GetButton("X") && atireB != Input.GetButton("X") )
			{
				deplacerCible ScriptCible = Cible.GetComponent<deplacerCible>();
				if(ScriptCible.Eleve)
				{
					if(ScriptCible.Eleve.GetComponent<Eleves>().etat != 0)
					{
						ScriptCible.Eleve.GetComponent<Eleves>().etat = 0;
						Debug.Log("Good Shot");

					}
					else
					{
						Debug.Log("tu es mauvais");
						life.value = life.value - 1;
					}
				}
			}
			atireT = Input.GetButton("Fire1");
			atireB = Input.GetButton("X");
			if ( life.value <= 0)
			{
				GameOver = true;
			}
			if(timer <= 0)
			{
				Win = true;
			}
		}		
	}
	
	void RetourneProf()
	{
		if (Retourne)
		{
			if(prof.transform.eulerAngles.y < 180 || prof.transform.eulerAngles.y > 350)
			{
				float rotation = Time.deltaTime * 180;
				prof.transform.Rotate(0,rotation, 0);
			}
			else
			{
				Anime = !Anime;
				Cible.GetComponent<Renderer>().enabled = true;

			}
		}
		else
		{
			if(prof.transform.eulerAngles.y < 350 )
			{
				float rotation = Time.deltaTime * 180;
				prof.transform.Rotate(0, -rotation, 0);
			}
			else
			{
				Anime = !Anime;
				Cible.GetComponent<Renderer>().enabled = false;
			}
		}
	}
	
	void OnGUI()
	{
		GUIStyle FontStyle = new GUIStyle();
		FontStyle.font = MyFont;
		FontStyle.fontSize = 90;
		FontStyle.alignment = TextAnchor.UpperCenter;
		FontStyle.normal.textColor = Color.white;
		if(GameOver)
		{	
			ImgScore = GameOverImg;
			Score = 0;
			Fin = true;
		}
		if (Win)
		{
			ImgScore = WinImg;
			Score = (int)(life.value*100);
			Fin = true;
		}
		
		if(timer >= 10)
		{
			GUI.Label(new Rect(10,10,Screen.width/8,Screen.height/8),""+System.Convert.ToString((int)timer),FontStyle);
		}
		else
		{			
			GUI.Label(new Rect(10,10,Screen.width/8,Screen.height/8),""+System.Convert.ToString(((float)((int)(timer*10)))/10),FontStyle);
		}
		
		
		
		if(Fin)
		{
			Cursor.visible = true;
			Cible.GetComponent<Renderer>().enabled = false;
			GUI.Box(new Rect(Screen.width / 8, Screen.height / 8, 6*Screen.width/8,6*Screen.height/8), ImgScore );
			GUI.Label(new Rect(2 * Screen.width / 8, 3 * Screen.height / 8,4*Screen.width/8,4*Screen.height/8),"Score : "+System.Convert.ToString(Score),FontStyle);
			if(GUI.Button(new Rect(2*Screen.width / 8, 5*Screen.height / 8, Screen.width/4, Screen.height/6), new GUIContent(ButtonRejouer,"rejouer")))
			{
				Application.LoadLevel(rejouer); //
			}
			if(GUI.Button(new Rect(4*Screen.width / 8, 5*Screen.height / 8, Screen.width/4, Screen.height/6), new GUIContent(ButtonQuit,"quit")))
			{
				Application.LoadLevel(quitter); //
			}
			
			if(indicateur)
			{
					posx = 2*Screen.width / 8 +Screen.width/8  - Touche.width/8;
			}
			else
			{
					posx = 4*Screen.width / 8 +Screen.width/8  - Touche.width/8;
			}
			
			if(Input.GetButton("GDmenu") && KeyDown != Input.GetButton("GDmenu"))
			{
				Debug.Log("GDMenu ="+Input.GetButton("GDmenu"));
				indicateur = !indicateur;
			}
			
			if(Input.GetKeyDown(KeyCode.Return)&& KeyReturn!=Input.GetKeyDown(KeyCode.Return)) // switch case sur i pour avoir la pos et donc le button
			{
				if(indicateur)
				{
						Application.LoadLevel(rejouer); //
				}
				else
				{
						Application.LoadLevel(quitter); //
				}

			}
			
			
			if(Input.GetAxis("GDmenu")<0 && Input.GetAxis("GDmenu") != LastAxe) 
			{
				indicateur = !indicateur;
			}	
			if(Input.GetAxis("GDmenu")>0 && Input.GetAxis("GDmenu") != LastAxe) 
			{
				indicateur = !indicateur;
			}
			
			if(Input.GetButton("A") && Input.GetButton("A") != ButtonDown) // switch case sur i pour avoir la pos et donc le button
			{
				if(indicateur)
				{
						Application.LoadLevel(rejouer); //
				}
				else
				{
						Application.LoadLevel(quitter); //
				}
			}
			GUI.Label(new Rect(posx, 6 * Screen.height/8 , Touche.width/4, Touche.height/4),Touche  );

		}
		else if(KeyDown)
		{
			Debug.Log("KeyDown=true");
			KeyDown = false;
		}
		KeyDown = Input.GetButton("GDmenu");
		KeyReturn = Input.GetKeyDown(KeyCode.Return);
		LastAxe = Input.GetAxis("GDmenu");
		ButtonDown = Input.GetButton("A");
		hover = GUI.tooltip;
		if(hover == "rejouer"){posx = 2*Screen.width / 8 +Screen.width/8  - Touche.width/8; indicateur = true;}
		if(hover == "quit"){posx = 4*Screen.width / 8 +Screen.width/8  - Touche.width/8; ; indicateur = false;}
		
	}
}