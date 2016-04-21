using UnityEngine;
using System.Collections;

public class AudioGame : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip[] drums;

	void Start(){
		//audioSource.loop = true;
		audioSource.PlayOneShot (drums[0]);

		if (audioSource.isPlaying) {
			audioSource.loop = true;
			Debug.Log ("QQQ");
		}
	
	}

	void Update(){

	}



}
