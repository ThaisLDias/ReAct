using UnityEngine;
using System.Collections;

public class AnimScript : MonoBehaviour {

	Animator anim;
	bool startAnimation;

	void Start(){
		anim = GetComponent<Animator>();
		StartCoroutine (AnimTime());
	}


	IEnumerator AnimTime() {
		anim.SetBool ("Start", false);
		yield return new WaitForSeconds (2f);
		anim.SetBool ("Start", true);
		yield return new WaitForSeconds (2f);
		StartCoroutine (AnimTime ());
	}
}
