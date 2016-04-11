using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clockTime : MonoBehaviour {

	public int minutes;
	public int seconds;
	public Text text;
	float count = 0; 

	void Start () {
		minutes = 6;
	} 

	void FixedUpdate() 
		{
		count++; 	
		if (count == 5) {
			seconds++; 
			count = 0;
		} 

		if (seconds == 60) {
			minutes += 1;
			seconds = 0;
		} 
		
		if (minutes == 24) {
			minutes = 0; 
		} 
	}
		
	public void OnGUI() {
		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
				text = gameObject.GetComponent<Text>();
				text.text = niceTime;
		} 
}
