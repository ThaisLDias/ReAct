using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PassQuestions : MonoBehaviour {

	GameObject btScript; 
	public Text passText;


	public void OnGUI() {
		btScript = GameObject.Find ("Question");
		Quiz quizScript = btScript.GetComponent<Quiz>(); 


		passText = gameObject.GetComponent<Text>();
		passText.text = (quizScript.questionPass).ToString () + "/9";
	} 
}
