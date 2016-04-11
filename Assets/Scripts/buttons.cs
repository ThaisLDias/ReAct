using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttons : MonoBehaviour {

	public GameObject buttonWork;
	public GameObject buttonStudy;
	public GameObject buttonFun;
	public GameObject buttonSleep;

	public GameObject stressBar; 
	public float Stress = 0;
	public bool isColliding; 
	public float meta;


	private Vector2 velocity = Vector2.zero;
	private Vector2 Oldpos; 
	private bool isMoving;

	GameObject barScript;

	void Start () {
		Oldpos = this.transform.position;
		isMoving = false;
		isColliding = false;
		stressBar.transform.localScale += new Vector3 (Stress,0,0);
	
	}

	void Update () {
		if (isColliding == true) {
			Stress += 0.1f;
			Debug.Log ("Stress" + Stress);
			meta += 0.1f;
			Debug.Log ("Meta" + meta);
		}
	}
		
	void OnMouseDrag() {
		if (!isMoving) {
			Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			gameObject.transform.position = position;
		}
	}

	void OnTriggerEnter2D(Collider2D colisor) {

		barScript = GameObject.Find ("Slider");
		stressBar declineScript = barScript.GetComponent<stressBar>(); 

		if (colisor.gameObject.tag == "blackHole") {
			isMoving = true;
			isColliding = true;
			this.gameObject.GetComponent<RectTransform> ().anchoredPosition = 
				new Vector2 (colisor.GetComponent<RectTransform> ().anchoredPosition.x, colisor.GetComponent<RectTransform> ().anchoredPosition.y);
			declineScript.Decline ();
			Debug.Log ("Entrou!");
			StartCoroutine (time());
		} 
	}

	void OnTriggerExit2D(Collider2D colisor) {
		if (colisor.gameObject.tag == "blackHole") {
			isMoving = false;
			isColliding = false;
		}
	}

	IEnumerator time() {
		yield return new WaitForSeconds(5f);
		Debug.Log ("Saiu!");
		transform.position = Vector2.Lerp(Oldpos, transform.position, Time.deltaTime);
        //transform.position = Vector2.SmoothDamp(transform.position, Oldpos, ref velocity, 2f);  
    }
}
