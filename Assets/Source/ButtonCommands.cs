using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCommands : MonoBehaviour {

	public GameObject textBox;
	public Button myButton;
	public string comment = "";
	//
	public float delay = 0.1f;
	public string fullText;

	void Start(){
		myButton.onClick.AddListener (OnSend);
	}

	public void OnSend(){
		StartCoroutine(ShowText());
	}

	IEnumerator ShowText(){
		for (int i = 0; i < fullText.Length; i++) {
			comment = fullText.Substring (0, i);
			this.GetComponent<Text> ().text = comment;
			yield return new WaitForSeconds (delay);
		}
	}
}
