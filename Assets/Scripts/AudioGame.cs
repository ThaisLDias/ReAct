using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
public class AudioGame : MonoBehaviour {

	public AudioSource audioSource1;
	public AudioSource audioSource2;
	public AudioSource audioSource3;
	public AudioSource audioSource4;
	public AudioSource audioSource5;
	int a;
	int b;
	public List<GameObject> audios = new List<GameObject> ();

	GameObject stress;

	void Start()
	{
		audios.AddRange(GameObject.FindGameObjectsWithTag ("audio"));
		b = 0;
	}


	void Update(){
		StartMusic ();
	}

	public void StartMusic(){
		stress = GameObject.Find ("BlackHole");
		BlackHole Script = stress.GetComponent<BlackHole>();

		if(Script.Stress >= 0 && Script.Stress < 20){
			a = 1;
		}
		if(Script.Stress >= 20 && Script.Stress < 40){
			a = 2;
		}
		if(Script.Stress >= 40 && Script.Stress < 60){
			a = 3;
		}
		if(Script.Stress >= 60 && Script.Stress < 80){
			a = 4;
		}
		if(Script.Stress >= 80 && Script.Stress < 100){
			a = 5;
		}

		if (a != b) {
			switch (a) {
			case 1: 
				Stop ("Stop");
				audioSource1.Play ();
				break;
			case 2: 
				Stop ("Stop");
				audioSource2.Play ();
				break;
			case 3:
				Stop ("Stop");
				audioSource3.Play ();
				break;
			case 4: 
				Stop ("Stop");
				audioSource4.Play ();
				break;
			case 5: 
				Stop ("Stop");
				audioSource5.Play ();
				break;
			}
		}

		b = a;
	}

	public void Stop(string c){
		for (int i = 0; i < audios.Count; i++) {
			if (c == "Pause")
				audios [i].GetComponent<AudioSource> ().Pause();
			if(c == "Stop")
				audios [i].GetComponent<AudioSource> ().Stop ();

		}
	}





}
