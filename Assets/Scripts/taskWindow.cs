using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class taskWindow : MonoBehaviour {

	public GameObject taskMenu;
	private bool setActive;

	void Start () {
		//taskMenu.SetActive (false);
		setActive = false;
		taskMenu.GetComponent<Image> ().enabled = false;
		GameObject.Find ("TextTask").GetComponent<Text> ().enabled = false;
		GameObject.Find ("ButtonTask").GetComponent<Button> ().interactable = false;
		//GameObject.Find ("ButtonTask").GetComponent<Button> ().enabled = false;

	}

	public void Appears () {
		setActive = true;
		if (setActive == true)	 {
			taskMenu.GetComponent<Image> ().enabled = true;
			GameObject.Find ("TextTask").GetComponent<Text> ().enabled = true;
			GameObject.Find ("ButtonTask").GetComponent<Button> ().interactable = true;
			//GameObject.Find ("ButtonTask").GetComponent<Button> ().enabled = true;


		} 
	}

	public void Disappers()
	{

		setActive = false;
		taskMenu.GetComponent<Image> ().enabled = false;
		GameObject.Find ("TextTask").GetComponent<Text> ().enabled = false;
		GameObject.Find ("ButtonTask").GetComponent<Button> ().interactable = false;
		//GameObject.Find ("ButtonTask").GetComponent<Button> ().enabled = false;


	}

}
