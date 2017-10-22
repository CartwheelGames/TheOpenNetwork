using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeoutIndicator : MonoBehaviour {
	[SerializeField]
	private Image ellipsis;
	[SerializeField]
	private Text messageText = null;

	public void ShowWithName (string characterName)
	{
		if (messageText && !string.IsNullOrEmpty(characterName))
		{
			messageText.text = string.Format("{0} is typing", characterName);
			//TODO: Drop to the bottom of the list
			gameObject.SetActive(true);
		}
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
