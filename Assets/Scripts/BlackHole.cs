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


	}


	void OnTriggerExit2D(Collider2D col) {

		objetive = GameObject.Find ("Text");
		miniGoals objetivo = objetive.GetComponent<miniGoals> ();

		if (col.gameObject.name == "studyButton" || col.gameObject.name == "workButton") {
			growing = false;
			bS = false;
			bW = false;

			Debug.Log (objetivo.lg);
			Debug.Log(objetivo.lg.Replace(col.gameObject.GetComponent<buttons> ().textGoal,""));
			RefreshPaper (objetive,objetivo,col);
		}
		if (col.gameObject.name == "funButton" || col.gameObject.name == "sleepButton") {
			declining = false;
			Debug.Log (objetivo.lg);
			Debug.Log(objetivo.lg.Replace(col.gameObject.GetComponent<buttons> ().textGoal,""));
			GameObject.Find("Text").GetComponent<Text>().text = 
									objetivo.lg.Replace(col.gameObject.GetComponent<buttons> ().textGoal, "");

			RefreshPaper (objetive,objetivo,col);

		}
	}
	void RefreshPaper(GameObject a , miniGoals b, Collider2D col)
	{
		


		/*for(int i = 0; i< b.gs.Count;i++)
		{
			b.lg = "";
			if (col.gameObject.GetComponent<buttons> ().textGoal == b.littleGoals [b.gs [i]]) {
				
				b.lg.Replace (b.littleGoals [b.gs [i]], "Done");
				Debug.Log ("Deu replace para:" + b.lg);
				b.littleGoals.Remove (b.littleGoals [b.gs [i]]);
				b.gs.Remove (b.gs [i]);
				for (int t = 0; t < b.gs.Count; t++) {
					b.lg += b.littleGoals [b.gs [t]];
				}

				//Debug.Log(b.lg -= col.gameObject.GetComponent<buttons> ().textGoal);

			} else
				Debug.Log ("A tentativa nº " + (i).ToString () + " não entrou no if");
*/

	
	}
}