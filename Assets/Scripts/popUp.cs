using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class popUp : MonoBehaviour {
	
	public GameObject panel; 
	GameObject stressP;
	private bool setActive;


	 

	void Start(){

		panel.SetActive (false);
		setActive = false;

	}

	void Update(){

		stressP = GameObject.Find ("BlackHole");
		BlackHole stressUpboo = stressP.GetComponent<BlackHole>(); 



		if (setActive == true && stressUpboo.growing == true) {
			panel.SetActive (true);
			Debug.Log ("Teste");
		}
			 


		OpenPanel ();
	}
		
	void OpenPanel(){
		stressP = GameObject.Find ("BlackHole");
		BlackHole stressUp = stressP.GetComponent<BlackHole>(); 

		if (stressUp.Stress >= 20 && stressUp.Stress <= 21) {
			setActive = true;
			StartCoroutine (BalloonTime());
		}

	}



	IEnumerator BalloonTime() {
		yield return new WaitForSeconds (5f);
		panel.SetActive (false);
		setActive = false;
	}
}
