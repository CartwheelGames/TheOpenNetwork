using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

	[SerializeField]
	private InputField userInfo = null;
	[SerializeField]
	private InputField passInfo = null;
	[SerializeField]
	private Text userText = null;
	[SerializeField]
	private Text passText = null;
	[SerializeField]
	private Button submitButton = null;
	private string passwordToEdit = "";


}
