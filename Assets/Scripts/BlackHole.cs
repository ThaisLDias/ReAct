using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BlackHole : MonoBehaviour {

	public float meta;
	public bool growing;

	public List<Events> events = new List<Events> ();
	public Events eventWork = new Events("Go to Work", 1, 13, 18);
	public Events eventSchool = new Events("Go to School", 2, 7, 12);
	public Events eventSleep = new Events("Sleep", 3, 0, 0);
	public Events eventHelp = new Events("Help in home", 4, 0, 0);
	public Events eventStudy = new Events("Study", 5, 0, 0);


	public float Stress = 0;
	
	GameObject barScript;
	private bool declining;
	int h;

	GameObject timeScript;


	void Start () 
	{
		growing = false;	
		declining = false;
		events.Add(eventWork);
		events.Add(eventSchool);
		events.Add(eventSleep);
		events.Add(eventHelp);
		events.Add(eventStudy);

	}

	void Update() {
		timeScript = GameObject.Find ("time");
		clockTime countScript = timeScript.GetComponent<clockTime>();


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

		for (int i = 0; i < events.Count; i++) {
			if (countScript.count >= events [i].startTime && countScript.count <= events [i].endTime) {
				events [i].started = true;
			}
		}

	


	}

	void OnTriggerEnter2D (Collider2D col) {
		
		barScript = GameObject.Find ("Slider");
		stressBar declineScript = barScript.GetComponent<stressBar>(); 

		if (col.gameObject.name == "studyButton" || col.gameObject.name == "workButton") {
			if(col.gameObject.name == "workButton"){
				if(h >=13 && h<18){
					growing = true;
					declineScript.Decline ();
				}
			}

			if(col.gameObject.name == "studyButton"){
				if(h >=13 && h<18){
					growing = false;
					declineScript.Decline ();
					}
				}
		}


		if (col.gameObject.name == "funButton" || col.gameObject.name == "sleepButton") {
			if(col.gameObject.name == "sleepButton"){
				if (h >=13 && h<18){}
				else {
					declining = true;
				}
			}
			else {
			declining = true;
			}
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