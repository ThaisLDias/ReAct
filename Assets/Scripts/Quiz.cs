using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;


public class Quiz : MonoBehaviour {

	public Text questions;
	public List<string> quizQuestions = new List<string> ();
	int click = 0;
	private Vector3 spawnPosition;

	GameObject c;
	int first;
	int second;
	int third;

	public GameObject ccheck;
	public GameObject canvas;


	public GameObject popQuestion;
	public bool next;
	GameObject btnCheck;
	Color b; 


	void Start () {
		spawnPosition = new Vector3 (-236,271,0);
		popQuestion.SetActive (false);
		next = false;
		btnCheck = GameObject.Find ("Options");

	}


	void Update() {
		questions.text = quizQuestions [click].ToString ();
	}


	public void changeQuestions() {
		popQuestion.SetActive (true);

		b = GameObject.Find ("CheckImage(Clone)").GetComponent<Image> ().color; 
		b.a = 0.2f;
		GameObject.Find ("CheckImage(Clone)").GetComponent<Image> ().color = b;
	}

	public void yes(){
		c = GameObject.Find ("Q1");
		ButtonsCheck clickScript = c.GetComponent<ButtonsCheck>();

		switch (btnCheck.GetComponent<ButtonsCheck> ().bt) {
		case "Q1":
			btnCheck.GetComponent<ButtonsCheck> ().sum += 4;
				break;
		case "Q2":
			btnCheck.GetComponent<ButtonsCheck> ().sum += 2;
				break;
		case "Q3":
			btnCheck.GetComponent<ButtonsCheck> ().sum += 0;
				break;
		}

		popQuestion.SetActive (false);
		if (click < 9) {
			click += 1;
		}
		next = true;
		Destroy (GameObject.Find ("CheckImage(Clone)"));

		if (click == 9) {
			if (btnCheck.GetComponent<ButtonsCheck> ().sum >= 0 && btnCheck.GetComponent<ButtonsCheck> ().sum <= 4) {
				SceneManager.LoadScene ("Option4");
			}
			if (btnCheck.GetComponent<ButtonsCheck> ().sum < 4
				&&  btnCheck.GetComponent<ButtonsCheck> ().sum <= 7 ) {
				SceneManager.LoadScene ("Option1");
			}
			if (btnCheck.GetComponent<ButtonsCheck> ().sum < 8
				&&  btnCheck.GetComponent<ButtonsCheck> ().sum <= 11 ) {
				SceneManager.LoadScene ("Option3");
			}
			if (btnCheck.GetComponent<ButtonsCheck> ().sum >= 12) {
				SceneManager.LoadScene ("Option2");
			}
		}

	}

	public void no(){
		popQuestion.SetActive (false);

		b.a = 1;
		GameObject.Find ("CheckImage(Clone)").GetComponent<Image> ().color = b;
	}




}
