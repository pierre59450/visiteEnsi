using UnityEngine;
using System.Collections;



public class deplacerCible : MonoBehaviour {

	public Vector3 target;
	public float sensitivity;
	public bool Tire = false;
	public GameObject Eleve;
	
	void start()
	{
		target = new Vector3(0,5,-1);
	}
	
	void Update()
	{
		if(GetComponent<Renderer>().enabled)
		{
			target.x = target.x + 0.5F*Input.GetAxis("Cible X");
			target.y = target.y + 0.5F*Input.GetAxis("Cible Y");
			target.z = transform.position.z;
		}
		transform.position = target;
		
	}
	
	void OnTriggerEnter(Collider eleves) 
	{
		Tire =true;
		Eleve = eleves.gameObject;
	}
	
	void OnTriggerExit(Collider eleves)
	{
		Tire = false;
		Eleve = null;
	}
}