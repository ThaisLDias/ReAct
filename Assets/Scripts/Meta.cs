using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Meta : MonoBehaviour {

	GameObject btScript; 
	public Text goalText;



	public void OnGUI() {
		btScript = GameObject.Find ("workButton");
		buttons buttonScript = btScript.GetComponent<buttons>(); 

		goalText = gameObject.GetComponent<Text>();
		goalText.text = (buttonScript.meta + "%").ToString();
	} 
}
