using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BlackHole : MonoBehaviour {

	public float meta;
	public bool growing;

	public bool bW;
	public bool bS;
	public bool bD;
	public bool bSp;

	
	

	public float Stress = 0;
	
	GameObject barScript;
	GameObject objetive;
	private bool declining;
	int h;
    


	void Start () 
	{
		growing = false;	
		declining = false;
		bW = false;
		bS = false;
		bD = false;
		bSp = false;
        
	}

	void Update() {

		h = FindObjectOfType<clockTime> ().hours;

		if (growing == true && meta < 100 && bS == true) {
			meta += 0.09f;
			Stress += 0.180f;
		}

		if (growing == true && meta < 100 && bW == true) {
			meta += 0.045f;
			Stress += 0.09f;
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



	}

	void OnTriggerEnter2D (Collider2D col) {
		
		barScript = GameObject.Find ("Slider");
		stressBar declineScript = barScript.GetComponent<stressBar> (); 

		objetive = GameObject.Find ("Text");
		miniGoals objetivo = objetive.GetComponent<miniGoals> ();

		if (col.gameObject.name == "studyButton") {
			growing = true;
			declineScript.Decline ();
			bS = true;
		}
		if (col.gameObject.name == "workButton") {
			if (col.GetComponent<buttons> ().started == true) {
				growing = true;
				declineScript.Decline ();
				bW = true;
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
			bS = false;
			bW = false;
		}
		if (col.gameObject.name == "funButton" || col.gameObject.name == "sleepButton") {
			declining = false;
		}
	}
}