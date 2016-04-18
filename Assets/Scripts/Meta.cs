﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Meta : MonoBehaviour {
	
	GameObject btScript; 
	public Text goalText;

	public void OnGUI() {
		btScript = GameObject.Find ("BlackHole");
		BlackHole blackScript = btScript.GetComponent<BlackHole>(); 
		
		goalText = gameObject.GetComponent<Text>();
		goalText.text = (blackScript.meta + "%").ToString();
	} 
}
