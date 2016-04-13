using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class miniGoals : MonoBehaviour {

	string[] littleGoals = new string[] {"Go to Work", "Study", "Clean my room", "Go to school", "Sleep"};
	public Text miniG; 
	string lg;


	void Start () {
		for (int i = 0; i < 4; i++) {
			lg = littleGoals [Random.Range (0, littleGoals.Length)];
			Debug.Log (lg);
		}
	}
	

	public void OnGUI() {
		miniG = gameObject.GetComponent<Text>();
		miniG.text = lg;
	} 
}
