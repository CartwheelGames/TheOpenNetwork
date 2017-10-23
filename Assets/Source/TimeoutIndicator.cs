using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeoutIndicator : MonoBehaviour {
	[SerializeField]
	private Image ellipsis;
	[SerializeField]
	private Text label = null;

	public void ShowWithName (string characterName)
	{
		if (label && !string.IsNullOrEmpty(characterName))
		{
			label.text = string.Format("{0} is typing", characterName);
			transform.SetAsLastSibling();
			gameObject.SetActive(true);
		}
	}
	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
