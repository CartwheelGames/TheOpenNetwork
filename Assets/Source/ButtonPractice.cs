using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPractice : MonoBehaviour {

	public Button btnRock;
	public Button btnPaper;
	public Button btnScissors;
	public GameObject textBox;
	private int Xrandom;
	//private int delay = 2.0f;
	[SerializeField]
	private Text txtP1;
	[SerializeField]
	private Text txtP2;
	//
	private bool rockClicked;
	private bool paperClicked;
	private bool scissorsClicked;
	//
	[SerializeField]
	private Image lifeBarP1;
	[SerializeField]
	private Image lifeBarP2;
	//public bool coolingDown;
	private float currAmount;
	private float maxAmount = 0.5f;
	//public float waitTime = 15.0f;
	//
	//public Text theText;
	[SerializeField]
	private TextAsset textFile;
	[SerializeField]
	private string[] textLines;
	[SerializeField]
	private int currentLine;
	[SerializeField]
	private int endAtLine;

	// Use this for initialization
	void Start () {
		rockClicked = false;
		paperClicked = false;
		scissorsClicked = false;
		Xrandom = Random.Range (1, 3);
		//
		lifeBarP1.fillAmount = currAmount;
		lifeBarP2.fillAmount = currAmount;
		//
		Button btn1 = btnRock.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick1);
		//
		Button btn2 = btnPaper.GetComponent<Button>();
		btn2.onClick.AddListener(TaskOnClick2);
		//
		Button btn3 = btnScissors.GetComponent<Button>();
		btn3.onClick.AddListener(TaskOnClick3);
		//
		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length + 1;
		}
	}

	void TaskOnClick1()
	{
		//Debug.Log("You have clicked the button!");
		//
		//txtP1 = gameObject.GetComponent<Text>();
		//txtP1.text = "You have clicked Rock.";
		//txtP1.text = textLines [currentLine];
		//currentLine += 1;
		Rock ();
	}

	void TaskOnClick2()
	{
		//Debug.Log("You have clicked the 2nd button!");
		//
		//txtP1 = gameObject.GetComponent<Text>();
		//txtP1.text = "You have clicked Paper.";
		//txtP1.text = textLines [currentLine];
		//currentLine += 1;
		Paper ();
	}

	void TaskOnClick3()
	{
		//Debug.Log("You have clicked the 3rd button!");
		//
		//txtP1 = gameObject.GetComponent<Text>();
		//txtP1.text = "You have clicked Scissors.";
		//txtP1.text = textLines [currentLine];
		//currentLine += 1;
		Scissors ();
	}
	
	// Update is called once per frame
	void Update () {
		//txtP1.text = textLines [currentLine];
		//content.fillAmount = fillAmount;
		//if (coolingDown == true)
		//{
			//Reduce fill amount over 30 seconds
			//fillAmount += 1.0f/waitTime * Time.deltaTime;
		//}
		// If choices are the same.
		//if (rockClicked = true && Xrandom == 1) {
			//GameDraw ();
			//Debug.Log("Integer is " + Xrandom + ".");
		//}
		//if (paperClicked = true && Xrandom == 2) {
			//GameDraw ();
		//}
		//if (scissorsClicked = true && Xrandom == 3) {
			//GameDraw ();
		//}
		// If opponent chooses wisely.
		//if (rockClicked = true && Xrandom == 2) {
			//P2Win ();
			//Debug.Log("Integer is " + Xrandom + ".");
		//}
		//if (paperClicked = true && Xrandom == 3) {
			//P2Win ();
		//}
		//if (scissorsClicked = true && Xrandom == 1) {
			//P2Win ();
		//}
		//If Player chooses wisely.
		//if (rockClicked = true && Xrandom == 3) {
			//P1Win ();
			//Debug.Log("Integer is " + Xrandom + ".");
		//}
		//if (paperClicked = true && Xrandom == 1) {
			//P1Win ();
		//}
		//if (scissorsClicked = true && Xrandom == 2) {
			//P1Win ();
		//}
	}

	void Rock(){
		rockClicked = true;
		Debug.Log("Rock is true.");
		//
		// If choices are the same.
		if (rockClicked = true && Xrandom == 1) {
			//GameDraw ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = "Stalemate.";
			//
			txtP1.text = textLines [currentLine];
			currentLine += 3;
		}
		//If Player chooses wisely.
		if (rockClicked = true && Xrandom == 3) {
			//P1Win ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = textLines [currentLine];
			currentLine += 8;	
			//
			lifeBarP1.fillAmount += 0.10f;
			//lifeBarP2.fillAmount -= 0.10f;
			txtP1.text = textLines [currentLine];
			currentLine += 1;
		}
		if (rockClicked = true && Xrandom == 2) {
			//P2Win ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = "Ha. I beat you.";
			//
			//lifeBarP1.fillAmount -= 0.10f;
			lifeBarP2.fillAmount += 0.10f;
			txtP1.text = textLines [currentLine];
			currentLine += 2;
		}
	}

	void Paper(){
		paperClicked = true;
		Debug.Log("Paper is true.");
		//
		//If choices are the same.
		if (paperClicked = true && Xrandom == 2) {
			//GameDraw ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = "Stalemate.";
			txtP1.text = textLines [currentLine];
			currentLine += 1;
		}
		//If Player chose wisely.
		if (paperClicked = true && Xrandom == 1) {
			//P1Win ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = "Dang. You beat me.";
			//
			lifeBarP1.fillAmount += 0.10f;
			//lifeBarP2.fillAmount -= 0.10f;
			txtP1.text = textLines [currentLine];
			currentLine += 2;
		}
		//If opponent chooses wisely.
		if (paperClicked = true && Xrandom == 3) {
			//P2Win ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = "Ha. I beat you.";
			//lifeBarP1.fillAmount -= 0.10f;
			lifeBarP2.fillAmount += 0.10f;
			txtP1.text = textLines [currentLine];
			currentLine += 3;
		}
	}

	void Scissors(){
		scissorsClicked = true;
		Debug.Log("Scissors is true.");
		//
		//If choices are the same.
		if (scissorsClicked = true && Xrandom == 3) {
		//GameDraw ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = "Stalemate.";
			txtP1.text = textLines [currentLine];
			currentLine += 1;
		}
		//If Player chose wisely.
		if (scissorsClicked = true && Xrandom == 2) {
		//P1Win ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = "Dang. You beat me.";
			lifeBarP1.fillAmount += 0.10f;
			//lifeBarP2.fillAmount -= 0.10f;
			txtP1.text = textLines [currentLine];
			currentLine += 2;
		}
		//If opponent chooses wisely.
		if (scissorsClicked = true && Xrandom == 1) {
		//P2Win ();
			Debug.Log("Integer is " + Xrandom + ".");
			txtP2.text = "Ha. I beat you.";
			//lifeBarP1.fillAmount -= 0.10f;
			lifeBarP2.fillAmount += 0.10f;
			txtP1.text = textLines [currentLine];
			currentLine += 3;
		}
	}
}
