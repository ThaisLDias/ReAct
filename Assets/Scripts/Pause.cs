using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject Menu;
	private bool setActive;

	void Start() {
		Menu.SetActive (false);
		setActive = false;
	}

	public void OnMouseDown(){
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			setActive = true;
			Debug.Log ("Pausado");
		}
		else
		{
			Time.timeScale = 1;
			setActive = false;
		
		
		}

		if (setActive == true) {
			Menu.SetActive (true);
		} else {
			Menu.SetActive (false);
		
		}
	
	}


	public void OutPause(){
		
	}

	public void GoMenu(){
		SceneManager.LoadScene ("Menu");
	}


}
