using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCommands : MonoBehaviour {

	public GameObject commentImage;
	public InputField commentBox;
	public string comment;
	//
	//public Button myButton;

	public void OnSend(){
		comment = commentBox.text;
		Instantiate (commentImage, new Vector2 (0, 0), Quaternion.identity);

		//
		Debug.Log(comment);

	}
}
