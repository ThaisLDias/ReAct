using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Black : MonoBehaviour {


	void Start () {
		StartCoroutine (time (3f));

	}
	

	IEnumerator time(float t) {
		yield return new WaitForSeconds(t);
		SceneManager.LoadScene ("Quiz");
	}
}
