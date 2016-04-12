using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stressBar : MonoBehaviour {
	
	public Slider stressB;
	GameObject otherS;

	void Update () {
		transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*10f, 0, 0);
		Decline ();
	}
		
	public void Decline()  {
		otherS = GameObject.Find ("BlackHole");
		BlackHole buttonScript = otherS.GetComponent<BlackHole>(); 
		stressB.value = buttonScript.Stress;
	}
}
