using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

	public float meta;
	private bool growing;

	public float Stress = 0;


	GameObject barScript;
	private bool declining;

	void Start () {
		growing = false;
	
		declining = false;
		}

	void Update() {
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
	}

	void OnTriggerEnter2D (Collider2D col) {
		
		barScript = GameObject.Find ("Slider");
		stressBar declineScript = barScript.GetComponent<stressBar>(); 

		if (col.gameObject.name == "studyButton" || col.gameObject.name == "workButton") {
			growing = true;
			declineScript.Decline ();
		}
		if (col.gameObject.name == "funButton" || col.gameObject.name == "sleepButton") {
			declining = true;
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

