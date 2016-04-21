using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



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
	public bool hasJujuba;

	public AudioSource En;
	public AudioSource lose;
	GameObject stopMusic;
	GameObject stopGame;


	void Start () 
	{
		hasJujuba = false;
		growing = false;	
		declining = false;
		bW = false;
		bS = false;
		bD = false;
		bSp = false;
		checkPosition = new Vector2 (11,21);
		radius = 500;
		Music.ToggleMusic();
		objetivo = GameObject.Find ("TextTask").GetComponent<miniGoals> ();
	}

	void Update() {

		stopMusic = GameObject.Find ("Audios");
		AudioGame p = stopMusic.GetComponent<AudioGame>();

		stopGame = GameObject.Find ("PauseButton");
		Pause b = stopGame.GetComponent<Pause>();



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
			p.Stop ("Stop");
			StartCoroutine (time (1f));
			Debug.Log("Perdeu miseravi");
		} 
		if (meta >= 100) {
			SceneManager.LoadScene ("Win");

		}
	}

	void OnTriggerEnter2D (Collider2D col) {

		barScript = GameObject.Find ("Slider");
		stressBar declineScript = barScript.GetComponent<stressBar> (); 

		if(!hasJujuba)
		{
			if (col.gameObject.name == "studyButton") {
				if (objetivo.gs.Contains (3) && !objetivo.gs.Contains (1)) {
					if (h >= col.gameObject.GetComponent<buttons> ().startTime
						&& h <= col.gameObject.GetComponent<buttons> ().endTime) {
						growing = true;
						declineScript.Decline ();
						bS = true;
						En.Play ();
					} 
				} else {
					growing = true;
					declineScript.Decline ();
					bS = true;
					En.Play ();
				}
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
		hasJujuba = true;


	}


	void OnTriggerExit2D(Collider2D col) {
		hasJujuba = false;

		switch (col.gameObject.name) {

			case"studyButton":
				bS = false;
				growing = false;
				break;
			case"workButton":
				bW = false;
				growing = false;
				break;
			case"sleepButton":
				bSp = false;
				declining = false;
				break;
			case"funButton":
				bD = false;
				declining = false;
			break;
		}
		if (col.gameObject.name != "workButton" && col.gameObject.name != "studyButton") {
			list = objetivo.Lg;
			list = list.Replace (col.gameObject.GetComponent<buttons> ().textGoal, "");
			objetivo.Lg = list;
		}
		else if(col.gameObject.name == "studyButton" && objetivo.gs.Contains (1) && !objetivo.gs.Contains(3)){

			list = objetivo.Lg;
			list = list.Replace (col.gameObject.GetComponent<buttons> ().textGoal, "");
			objetivo.Lg = list;
			objetivo.gs.Remove (1);
		}
		else if(col.gameObject.name == "studyButton" && objetivo.gs.Contains (3) && !objetivo.gs.Contains(1)){

			if (h >= col.gameObject.GetComponent<buttons> ().startTime
				&& h <= col.gameObject.GetComponent<buttons> ().endTime) {
				list = objetivo.Lg;
				list = list.Replace (objetivo.littleGoals [3], "");
				objetivo.Lg = list;
				objetivo.gs.Remove (3);
			} else
				Debug.Log ("Não ta na hora" );
		}
		else if(col.gameObject.name == "studyButton" && objetivo.gs.Contains (3) && objetivo.gs.Contains(1)){

			if (h >= col.gameObject.GetComponent<buttons> ().startTime
				&& h <= col.gameObject.GetComponent<buttons> ().endTime) {
				list = objetivo.Lg;
				list = list.Replace (objetivo.littleGoals [3], "");
				objetivo.Lg = list;
				objetivo.gs.Remove (3);
			} else {
				list = objetivo.Lg;
				list = list.Replace (col.gameObject.GetComponent<buttons> ().textGoal, "");
				objetivo.Lg = list;
				objetivo.gs.Remove (1);
			}	
		}
		else {
			if (h >= col.gameObject.GetComponent<buttons> ().startTime
				&& h <= col.gameObject.GetComponent<buttons> ().endTime) {
				list = objetivo.Lg;
				list = list.Replace (col.gameObject.GetComponent<buttons> ().textGoal, "");
				objetivo.Lg = list;

			}
		}
	}

	IEnumerator time(float t) {
		yield return new WaitForSeconds(t);
		SceneManager.LoadScene ("Black");
	}

}