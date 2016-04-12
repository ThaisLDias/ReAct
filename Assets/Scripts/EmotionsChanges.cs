using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmotionsChanges : MonoBehaviour {

	Image myImage;
	public Sprite firstImage;
	public Sprite secondImage;
	public Sprite thirdImage;
	public Sprite fourthImage;
	GameObject otherScript; 

	void Start(){
		myImage = GetComponent<Image> ();
	}

	void Update(){
		LoadSprite ();
	}

	void LoadSprite(){
		otherScript = GameObject.Find ("workButton");
		stressButtons buttonScript = otherScript.GetComponent<stressButtons>(); 

		if (buttonScript.Stress >= 20 && buttonScript.Stress < 50) {
			myImage.sprite = secondImage;
		} 
		else if(buttonScript.Stress >= 50 && buttonScript.Stress < 70)
		{
			myImage.sprite = thirdImage;
		}
		else if(buttonScript.Stress >= 70 && buttonScript.Stress <= 100)
		{
			myImage.sprite = fourthImage;
		}
		else
			myImage.sprite = firstImage;
	}
}
