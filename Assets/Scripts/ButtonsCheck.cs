using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonsCheck : MonoBehaviour {

	public GameObject check;
	public List<int> options = new List<int> ();
	GameObject c;
	public int sum;

	public string bt; 
	public AudioSource audioCheck;




	public void Options(string a){
		c = GameObject.Find ("Question");
		Quiz yesVoid = c.GetComponent<Quiz>();


		audioCheck.Play ();
		bt = a;
		Destroy (GameObject.Find ("CheckImage(Clone)"));

		GameObject ch = Instantiate (check,GameObject.Find(a).transform.position,Quaternion.identity) as GameObject;
		ch.transform.position += new Vector3 (0, 0.1f, 0);
		ch.transform.SetParent (GameObject.Find("Canvas").GetComponent<Canvas>().transform);
	}


}


