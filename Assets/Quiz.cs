using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Quiz : MonoBehaviour {

	public Text questions;
	public List<string> quizQuestions = new List<string> ();
	private bool add;
	int click = 0;
	private Vector3 spawnPosition;

	GameObject c;

	public GameObject ccheck;
	public GameObject canvas;



	void Start () {
		string[] q = {"I have trouble sleeping", "I have trouble focusing on tasks"};
		quizQuestions.AddRange (q);
		add = false;

		spawnPosition = new Vector3 (-236,271,0);
	}


	void Update() {

	
		questions.text = quizQuestions [click].ToString ();
	}


	public void changeQuestions() {
		c = GameObject.Find ("Q1");
		ButtonsCheck clickScript = c.GetComponent<ButtonsCheck>();

		add = true;
		click += 1;
		if (gameObject != null) {
			Destroy (clickScript.check);
		}
		GameObject spawnCheck = Instantiate (ccheck, spawnPosition, Quaternion.identity) as GameObject;
		spawnCheck.transform.SetParent (canvas.transform);

	}




}
