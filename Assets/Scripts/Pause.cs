﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject Menu;
	private bool setActive;

	public AudioSource audioPause;

	GameObject stopMusic;


	void Start() {
		Menu.SetActive (false);
		setActive = false;
	}

	public void OnMouseDown(){
		stopMusic = GameObject.Find ("Audios");
		AudioGame p = stopMusic.GetComponent<AudioGame>();


		audioPause.Play ();
		if (Time.timeScale == 1)
		{
			StopAll ();
			setActive = true;
			p.Stop ("Pause");
		}
		else
		{
			Time.timeScale = 1;
			setActive = false;
			p.StartMusic ();
		}

		if (setActive == true) {
			Menu.SetActive (true);
		} else {
			Menu.SetActive (false);

		}

	}


	public void GoMenu(){
		SceneManager.LoadScene ("Menu");
		Time.timeScale = 1;

	}

	public void StopAll(){
		Time.timeScale = 0;

	}


}
