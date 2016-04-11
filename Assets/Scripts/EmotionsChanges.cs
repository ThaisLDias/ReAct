using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmotionsChanges : MonoBehaviour {

	Image myImage;
	public Sprite firstImage;
	public Sprite secondImage;
	GameObject otherScript; 

	void Start(){
		myImage = GetComponent<Image> ();
	}

	void Update(){
		LoadSprite ();
	}

	void LoadSprite(){
		otherScript = GameObject.Find ("workButton");
		buttons buttonScript = otherScript.GetComponent<buttons>(); 

		if (buttonScript.Stress >= 20) {
			myImage.sprite = secondImage;
		} else
			myImage.sprite = firstImage;
	}
}
