using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class BlackHole : MonoBehaviour {

	public float meta;
	public bool growing;

	public bool bW;
	public bool bS;
	public bool bD;
	public bool bSp;


	private Vector2 checkPosition;
	private float radius;

	public float Stress = 0;

	GameObject barScript;
	miniGoals objetivo;
	private bool declining;
	public int h;
	public string list;

	public AudioSource En;
	public AudioSource Ou;

	void Start () 
	{
		growing = false;	
		declining = false;
		bW = false;
		bS = false;
		bD = false;
		bSp = false;
		checkPosition = new Vector2 (11,21);
		radius = 500;
		Music.ToggleMusic();
		objetivo = GameObject.Find ("Text").GetComponent<miniGoals> ();
	}

	void Update() {
		h = FindObjectOfType<clockTime> ().hours;

		if (growing == true && meta < 100 && bS == true) {
			meta += 0.082f;
			Stress += 0.175f;
		}

		if (growing == true && meta < 100 && bW == true) {
			meta += 0.018f;
			Stress += 0.035f;
		}

		if (declining == true && Stress > 0 && bD == true) {
			Stress -= 0.025f;
		}

		if (declining == true && Stress > 0 && bSp == true) {
			Stress -= 0.025f;
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

		if (col.gameObject.name == "studyButton") {
			growing = true;
			declineScript.Decline ();
			bS = true;
			En.Play ();
		}
		if (col.gameObject.name == "workButton") {
			if (col.GetComponent<buttons> ().started == true) {
				growing = true;
				declineScript.Decline ();
				bW = true;
				En.Play ();
			}		
		}

		if (col.gameObject.name == "funButton") {
			declining = true;
			bD = true;
			En.Play ();
		}
		if (col.gameObject.name == "sleepButton") {
			declining = true;
			bSp = true;
			En.Play ();
		}

	}


	void OnTriggerExit2D(Collider2D col) {

		list = objetivo.Lg;
		list = list.Replace (col.gameObject.GetComponent<buttons> ().textGoal, "");
		objetivo.Lg = list;

		if (col.gameObject.name == "studyButton" || col.gameObject.name == "workButton") {
			growing = false;
			bS = false;
			bW = false;
			Ou.Play ();
		}
		if (col.gameObject.name == "funButton" || col.gameObject.name == "sleepButton") {
			declining = false;
			bD = false;
			bSp = false;
			Ou.Play ();
		}
	}

}