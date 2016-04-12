﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttons : MonoBehaviour {

	public GameObject buttonFun;
	public GameObject buttonSleep;

	//private bool colGoal;
	//public float meta;

	private Vector2 Oldpos; 
	private bool isMoving;


	void Start () {
		Oldpos = this.transform.position;
		isMoving = false;
		//colGoal = false;
	}

	void Update () {
		/*if (colGoal == true) {
			meta += 0.1f;
		}

		if (meta >= 100) {
			Debug.Log("Ganhou miseravi");
		}*/

        
        
	}
		
	void OnMouseDrag() {
		if (!isMoving) {
			Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			gameObject.transform.position = position;
		}
	}

	void OnTriggerEnter2D(Collider2D colisor) {

		//barScript = GameObject.Find ("Slider");
		//stressBar declineScript = barScript.GetComponent<stressBar>(); 

		if (colisor.gameObject.tag == "blackHole") {
			isMoving = true;
			//colGoal = true;
			this.gameObject.GetComponent<RectTransform> ().anchoredPosition = 
			new Vector2 (colisor.GetComponent<RectTransform> ().anchoredPosition.x, colisor.GetComponent<RectTransform> ().anchoredPosition.y);
			StartCoroutine (time());
		} 
	}

	void OnTriggerExit2D(Collider2D colisor) {
		if (colisor.gameObject.tag == "blackHole") {
			isMoving = false;
			//colGoal = false;
		}
	}

	IEnumerator time() {
       // meta = PlayerPrefs.GetFloat("meta");
		yield return new WaitForSeconds(5f);
		transform.position = Vector2.Lerp(Oldpos, transform.position, Time.deltaTime);

        //PlayerPrefs.SetFloat("meta", meta);
    }

}
