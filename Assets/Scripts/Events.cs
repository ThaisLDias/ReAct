using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {

	public string name;
	public int id;
	public int startTime;
	public int endTime;
	public bool done;
	public bool started;

	GameObject time;

	void Start () {
	
	}

	void Update () {
		time = GameObject.Find ("time");
		clockTime countScript = time.GetComponent<clockTime>();

		if (countScript.count >= startTime && countScript.count <= endTime) {
			started = true;
		}

		Debug.Log ("Arara");
	
	}

	public Events (string _name, int _id, int _startTime, int _endTime) {

		this.name = _name;
		this.id = _id;
		this.startTime = _startTime;
		this.endTime = _endTime;

	}
}
