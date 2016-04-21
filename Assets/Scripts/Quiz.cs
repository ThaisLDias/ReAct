using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Quiz : MonoBehaviour {

	public Text questions;
	public List<string> quizQuestions = new List<string> ();
	int click = 0;
	private Vector3 spawnPosition;

	GameObject c;

	public GameObject ccheck;
	public GameObject canvas;


	public GameObject popQuestion;
	public bool next;



	void Start () {
		spawnPosition = new Vector3 (-236,271,0);
		popQuestion.SetActive (false);
		next = false;
	
	}


	void Update() {
		questions.text = quizQuestions [click].ToString ();
	}
		

	public void changeQuestions() {
		popQuestion.SetActive (true);
	}

	public void yes(){

		c = GameObject.Find ("Q1");
		ButtonsCheck clickScript = c.GetComponent<ButtonsCheck>();

		popQuestion.SetActive (false);
		click += 1;
		next = true;
		Destroy (clickScript.check);
		GameObject spawnCheck = Instantiate (ccheck, spawnPosition, Quaternion.identity) as GameObject;
		spawnCheck.transform.SetParent (canvas.transform,false);
	}

	public void no(){
		popQuestion.SetActive (false);

	}




}
