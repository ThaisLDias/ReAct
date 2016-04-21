using UnityEngine;
using System.Collections;

public class taskWindow : MonoBehaviour {

	public GameObject taskMenu;
	private bool setActive;

	void Start () {
		taskMenu.SetActive (false);
		setActive = false;
		//taskMenu.GetComponent<Renderer>().
	}

	public void Appears () {
				setActive = true;
		if (setActive == true) {
			taskMenu.SetActive (true);
		} 
	}

	public void Disappers()
	{
		
		setActive = false;
		taskMenu.SetActive (false);
	}

}
