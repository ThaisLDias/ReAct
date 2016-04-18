using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class miniGoals : MonoBehaviour {

	string[] littleGoals = new string[] {"Go to Work"+"<br>", "Study" +"<br>", "Clean my room" + "<br>", "Go to school" + "<br>", "Sleep" + "<br>"};
	public Text miniG; 
	string lg;
	GameObject timeGoals;
	
	void Start () {
		for (int i = 0; i < 3; i++) {
			lg += littleGoals [Random.Range (0, littleGoals.Length)];
		}
	}

	void Update() {
		timeGoals = GameObject.Find ("time");
		clockTime timeL = timeGoals.GetComponent<clockTime>();
	} 

	public void OnGUI() {
		miniG = gameObject.GetComponent<Text>();
		miniG.text = lg.Replace("<br>", "\n");
	} 
}
