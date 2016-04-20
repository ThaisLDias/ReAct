using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttons : MonoBehaviour {

	public GameObject buttonFun;
	public GameObject buttonSleep;

	private Vector2 Oldpos;  
	private bool isMoving;
	int h;
    public string textGoal;
    public int startTime;
    public int endTime;
    public bool started;
    public bool done;


	void Start () {
		Oldpos = this.transform.position;
		isMoving = false;
		h = FindObjectOfType<clockTime>().hours;
	}

	void FixedUpdate()
	{
		h = FindObjectOfType<clockTime>().hours;


	}

	void OnMouseDrag() {
		if (!isMoving) {
			Vector2 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			gameObject.transform.position = position;
		}
	}

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag == "blackHole") {
			if (this.gameObject.name == "workButton") {
				if (this.startTime <= h && this.endTime >= h) {
					this.done = true;
					isMoving = true;
					this.started = true;
					this.gameObject.GetComponent<RectTransform> ().anchoredPosition = 
						new Vector2 (colisor.GetComponent<RectTransform> ().anchoredPosition.x,
						colisor.GetComponent<RectTransform> ().anchoredPosition.y);
					StartCoroutine (time (5f));
				} else {
					this.started = false;
					//StartCoroutine (time(1f));
					isMoving = false;
					Debug.Log ("Nao ta na hora, viado");
				}
			}


			if (this.gameObject.name == "sleepButton") {
				this.done = true;
				isMoving = true;
				this.gameObject.GetComponent<RectTransform> ().anchoredPosition = 
					new Vector2 (colisor.GetComponent<RectTransform> ().anchoredPosition.x,
					colisor.GetComponent<RectTransform> ().anchoredPosition.y);
				StartCoroutine (time (2f));
			
			}
			if (this.gameObject.name == "studyButton") {
				this.done = true;
				isMoving = true;
				this.gameObject.GetComponent<RectTransform> ().anchoredPosition = 
					new Vector2 (colisor.GetComponent<RectTransform> ().anchoredPosition.x,
					colisor.GetComponent<RectTransform> ().anchoredPosition.y);
				StartCoroutine (time (2f));

			}
			if (this.gameObject.name == "funButton") {	
				this.done = true;
				isMoving = true;
				this.gameObject.GetComponent<RectTransform> ().anchoredPosition = 
					new Vector2 (colisor.GetComponent<RectTransform> ().anchoredPosition.x,
						colisor.GetComponent<RectTransform> ().anchoredPosition.y);
				StartCoroutine (time (2f));

			}
		}
	}
	void OnTriggerExit2D(Collider2D colisor) {
		if (colisor.gameObject.tag == "blackHole") {
			isMoving = false;
		}
	}

	IEnumerator time(float t) {
		yield return new WaitForSeconds(t);
		this.transform.position = Vector2.Lerp(Oldpos, transform.position, Time.deltaTime);
    }

}
