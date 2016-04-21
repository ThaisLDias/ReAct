using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonsCheck : MonoBehaviour {

	public GameObject check;




	public List<int> optionOne = new List<int> ();
	public List<int> optionTwo = new List<int> ();
	public List<int> optionTree = new List<int> ();

	public Button b1;
	public Button b2;
	public Button b3;

	GameObject c;




	public void Options(){
		check.transform.position = this.transform.position;

		c = GameObject.Find ("Question");
		Quiz yesVoid = c.GetComponent<Quiz>();

		if (b1 && yesVoid.next == true) {
			optionOne.Add (1);
		}

		if (b2) {
			optionTwo.Add (1);
		}

		if (b3) {
			optionTree.Add (1);
		}



	}


}


