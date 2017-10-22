using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCommands : MonoBehaviour {

	public Button myButton;

	void Start(){
		myButton.onClick.AddListener (AceComment);
	}

	void AceComment(){
		Debug.Log ("Hello! Hello!");
		//
		OnGUI();
		//GUI.Button(new Rect(10,10,50,50), "Response");
	}

	void OnGUI(){
		GUI.Button(new Rect(10,10,50,50), "Response");
	}
}
