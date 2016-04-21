using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {

	public Animation  anim;


	void Start () {
	
	}

	void Update () {
		StartCoroutine (AnimTime ());
	
	}



	IEnumerator AnimTime() {
		yield return new WaitForSeconds (5f);

	}
}
