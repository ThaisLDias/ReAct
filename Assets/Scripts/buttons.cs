using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttons : MonoBehaviour {

	public GameObject buttonFun;
	public GameObject buttonSleep;

	private Vector2 Oldpos;  
	private bool isMoving;

	void Start () {
		Oldpos = this.transform.position;
		isMoving = false;
	}
		
	void OnMouseDrag() {
		if (!isMoving) {
			Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			gameObject.transform.position = position;
		}
	}

	void OnTriggerEnter2D(Collider2D colisor) {

		if (colisor.gameObject.tag == "blackHole") {
			isMoving = true;
			this.gameObject.GetComponent<RectTransform> ().anchoredPosition = 
			new Vector2 (colisor.GetComponent<RectTransform> ().anchoredPosition.x, colisor.GetComponent<RectTransform> ().anchoredPosition.y);
			StartCoroutine (time());
		} 
			
	}

	void OnTriggerExit2D(Collider2D colisor) {
		if (colisor.gameObject.tag == "blackHole") {
			isMoving = false;
		}
	}

	IEnumerator time() {
		yield return new WaitForSeconds(5f);
		transform.position = Vector2.Lerp(Oldpos, transform.position, Time.deltaTime);
    }

}
