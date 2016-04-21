using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clockTime : MonoBehaviour {

	public int hours;
	public int minutes;
	public Text text;
	public float count = 0; 

	void Start () {
		hours = 6;
	} 

	void FixedUpdate() 
		{
		count++; 	
		if (count == 10) {
			minutes++; 
			count = 0;

		} 

		if (minutes == 60) {
			hours += 1;
			minutes = 0;
		} 
		
		if (hours == 24) {
			hours = 0; 
		} 
	}
		
	public void OnGUI() {
		string niceTime = string.Format("{0:00}:{1:00}", hours, minutes);
				text = gameObject.GetComponent<Text>();
				text.text = niceTime;
		} 
}
