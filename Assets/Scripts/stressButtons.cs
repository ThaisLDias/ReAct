using UnityEngine;
using System.Collections;

public class stressButtons : MonoBehaviour {

	public GameObject buttonWork;
	public GameObject buttonStudy;
	public float Stress = 0;
	public bool isColliding;

	GameObject barScript;

	void Start () {
        
		isColliding = false;
	}
	
	void Update () {

		if (isColliding == true) {
			Stress += 0.1f;
		}
			
		if (Stress >= 100) {
			Debug.Log("Perdeu miseravi");
		} 
	
	}


	void OnTriggerEnter2D(Collider2D colisor) {

		barScript = GameObject.Find ("Slider");
		stressBar declineScript = barScript.GetComponent<stressBar>(); 

		if (colisor.gameObject.tag == "blackHole") {
			isColliding = true;
			declineScript.Decline ();
		} 
	}

	void OnTriggerExit2D(Collider2D colisor) {
		if (colisor.gameObject.tag == "blackHole") {
			isColliding = false;
		}
	}
}
