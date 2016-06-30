using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stressString : MonoBehaviour {

	GameObject btScript; 
	public Text stressText;

	public void OnGUI() {
		btScript = GameObject.Find ("BlackHole");
		BlackHole blackScript = btScript.GetComponent<BlackHole>(); 


		stressText = gameObject.GetComponent<Text>();
		stressText.text = (blackScript.Stress).ToString ("F0") + "%";
	} 
}
