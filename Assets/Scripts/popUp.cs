using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class popUp : MonoBehaviour {
	
	public GameObject panel; 
	GameObject stressP;
	private bool setActive;

	GameObject takeTime;
	public Sprite schoolTime;
	public Sprite workTime;
	public Sprite sleepTime;
	public Sprite outTime;
	public Sprite studyTime;
	public Sprite headacheTime;
	private bool setActiveB;

	void Start(){

		panel.SetActive (false);
		setActive = false;
		setActiveB = false;

	}

	void Update(){

		stressP = GameObject.Find ("BlackHole");
		BlackHole stressUpboo = stressP.GetComponent<BlackHole>(); 




		if (setActive == true && stressUpboo.growing == true) {
			panel.SetActive (true);
			Debug.Log ("Teste");
		}

		if (setActiveB == true) {
			panel.SetActive (true);
		}

			 


		OpenPanel ();
	}
		
	void OpenPanel(){
		stressP = GameObject.Find ("BlackHole");
		BlackHole stressUp = stressP.GetComponent<BlackHole>();

		takeTime = GameObject.Find ("time");
		clockTime tm = takeTime.GetComponent<clockTime>(); 

		if (stressUp.Stress >= 50 && stressUp.Stress <= 51) {
			panel.GetComponent<Image> ().sprite = headacheTime;
			setActive = true;
			StartCoroutine (BalloonTime());
		}


		switch (tm.hours) {
		case 7:
			panel.GetComponent<Image> ().sprite = schoolTime;
			setActiveB = true;
			StartCoroutine (BalloonTime ());
			break;
		case 13: 
			panel.GetComponent<Image> ().sprite = workTime;
			setActiveB = true;
			StartCoroutine (BalloonTime ());
			break;
		case 19: 
			panel.GetComponent<Image> ().sprite = outTime;
			setActiveB = true;
			StartCoroutine (BalloonTime ());
			break;
		case 21:
			panel.GetComponent<Image> ().sprite = studyTime;
			setActiveB = true;
			StartCoroutine (BalloonTime ());
			break;
		case 23:
			panel.GetComponent<Image> ().sprite = sleepTime;
			setActiveB = true;
			StartCoroutine (BalloonTime ());
			break;
		}
			
	}



	IEnumerator BalloonTime() {
		yield return new WaitForSeconds (5f);
		panel.SetActive (false);
		setActive = false;
		setActiveB = false;
	}
}
