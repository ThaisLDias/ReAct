using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

	public float meta;
	private bool metaCol;
	private bool metaDecline;

	void Start () {
		metaCol = false;
		metaDecline = false;
		}

	void Update() {
		if (metaCol == true && meta < 100) {
			meta += 0.1f;
		}

		if (metaDecline == true && meta > 0) {
			meta -= 0.1f;
		}

		if (meta >= 100) {
			Debug.Log("Ganhou miseravi");
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "studyButton" || col.gameObject.name == "workButton") {
			metaCol = true;
		}
		if (col.gameObject.name == "funButton" || col.gameObject.name == "sleepButton") {
			metaDecline = true;
		}

		/*if (col.gameObject.tag == "buttons") {
			transform.position = Vector2.Lerp(Oldpos, transform.position, Time.deltaTime);
		}*/
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.name == "studyButton" || col.gameObject.name == "workButton") {
			metaCol = false;
		}
		if (col.gameObject.name == "FunButton" || col.gameObject.name == "SleepButton") {
			metaDecline = false;
		}
	}
}

