using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour {

	public GameObject buttonWork;
	public GameObject buttonStudy;
	public GameObject buttonFun;
	public GameObject buttonSleep;

	private Vector2 velocity = Vector2.zero;
	private Vector2 Oldpos; 


	void Start () {
		Oldpos = this.transform.position;
	}


	void OnMouseDrag() {
			Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			gameObject.transform.position = position;
	}

	void OnTriggerEnter2D(Collider2D colisor) {
		if (colisor.gameObject.tag == "blackHole") {
			this.transform.position = GameObject.Find("BlackHole").transform.position;
			Debug.Log ("Entrou!");
			StartCoroutine (time());
		} 
	}

	IEnumerator time() {
		yield return new WaitForSeconds(5f);
		Debug.Log ("Saiu!");
		transform.position = Vector2.Lerp(Oldpos, transform.position, Time.deltaTime);
        //transform.position = Vector2.SmoothDamp(transform.position, Oldpos, ref velocity, 2f);  
    }
}
