using UnityEngine;
using System.Collections;

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
		}

	}

	public void ClosePanel(){
		panel.SetActive (false);
		setActive = false;
	}
}
