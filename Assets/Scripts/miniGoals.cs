using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class miniGoals : MonoBehaviour {

	public List<string> littleGoals = new List<string> ();
	public List<GameObject> btns = new List<GameObject>();
	public Text miniG; 
	public string lg;
	public List<int> gs = new List<int>() ;
	GameObject timeGoals;
	
	void Start () {
		miniG = this.gameObject.GetComponent<Text>();
		for (int i = 0; i < 3; i++) {

			int rdm = Random.Range (0, littleGoals.Count);

			if (i == 0)
				gs.Add (rdm);
			else if (rdm != gs [i - 1])
				gs.Add (rdm);
			else 
				i-= 1;

			lg += littleGoals [gs [i]];
			Debug.Log (this.gameObject.name);
		}
	}


	void Update() {
		timeGoals = GameObject.Find ("time");
		clockTime timeL = timeGoals.GetComponent<clockTime>();
		miniG.text = lg.Replace("<br>", "\n");
	}
	 

	public void OnGUI() {


	} 
}
