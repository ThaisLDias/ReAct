using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BlackHole : MonoBehaviour {

	public float meta;
	public bool growing;

	
	

	public float Stress = 0;
	
	GameObject barScript;
	GameObject objetive;
	private bool declining;
	int h;
    


	void Start () 
	{
		growing = false;	
		declining = false;
        
	}

	void Update() {

		h = FindObjectOfType<clockTime> ().hours;

		if (growing == true && meta < 100) {
			meta += 0.1f;
			Stress += 0.1f;
		}
		if (declining == true && Stress > 0) {
			Stress -= 0.1f;
		}
		if (Stress >= 100) {
			Debug.Log("Perdeu miseravi");
		} 
		if (meta >= 100) {
			Debug.Log("Ganhou miseravi");
		}
		Debug.Log ("meta: " + meta.ToString ());
		


	}

	void OnTriggerEnter2D (Collider2D col) {
		
		barScript = GameObject.Find ("Slider");
		stressBar declineScript = barScript.GetComponent<stressBar> (); 

		objetive = GameObject.Find ("Text");
		miniGoals objetivo = objetive.GetComponent<miniGoals> ();

		if (col.gameObject.name == "studyButton") {
			growing = true;
			declineScript.Decline ();
		}
		if (col.gameObject.name == "workButton") {
			if (col.GetComponent<buttons> ().started) {
				growing = true;
				declineScript.Decline ();
			}		
		}

		if (col.gameObject.name == "funButton")
			declining = true;

		if (col.gameObject.name == "sleepButton")
			declining = true;

		for(int i = 0; i< objetivo.gs.Count;i++)
		{
			objetivo.lg = "";
			if (col.gameObject.GetComponent<buttons> ().textGoal == objetivo.littleGoals [objetivo.gs [i]]) {
				
				Debug.Log ("Entrou no if na tentativa nº: " + (i).ToString ());

				objetivo.lg.Replace (objetivo.littleGoals [objetivo.gs [i]], "Done");
				objetivo.littleGoals.Remove (objetivo.littleGoals [objetivo.gs [i]]);
				objetivo.gs.Remove (objetivo.gs [i]);
				 
			} else
				Debug.Log ("A tentativa nº " + (i).ToString () + " não entrou no if");


		}
	}


	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.name == "studyButton" || col.gameObject.name == "workButton") {
			growing = false;
		}
		if (col.gameObject.name == "funButton" || col.gameObject.name == "sleepButton") {
			declining = false;
		}
	}
}