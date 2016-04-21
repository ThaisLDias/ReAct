using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class miniGoals : MonoBehaviour {

	public List<string> littleGoals = new List<string> ();
	public List<GameObject> btns = new List<GameObject>();
	public Text miniG; 
	private string lg;
	public string Lg
	{
		get{ 
			return lg;
		}	
		set { 
			lg = value;
		}
	}

	public List<int> gs = new List<int>() ;
	GameObject timeGoals;
	int a;

	void Start () {
		miniG = this.gameObject.GetComponent<Text>();
		Debug.Log (this.gameObject.name);
		for (int i = 0; i < 3; i++) {

			int rdm = Random.Range (0, littleGoals.Count);

			if (i == 0) {
				gs.Add (rdm);
				lg += littleGoals [gs [i]];
			}
			else if (littleGoals [rdm] != littleGoals [a] && littleGoals [rdm] != littleGoals [gs [0]]) {
				gs.Add (rdm);
				lg += littleGoals [gs [i]];
			}
			else 
				i-= 1;


			a = rdm;


		}
	}


	void Update() {
		timeGoals = GameObject.Find ("time");
		clockTime timeL = timeGoals.GetComponent<clockTime>();

		miniG.text = lg.Replace("<br>", "\n");
	}
}
