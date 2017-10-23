using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeoutIndicator : MonoBehaviour {
	[SerializeField]
	private Text ellipsisLabel;
	[SerializeField]
	private Text contentLabel = null;

	private void Awake()
	{
		gameObject.SetActive(false);
	}

	public void ShowWithName (string characterName)
	{
		if (contentLabel && !string.IsNullOrEmpty(characterName))
		{
			contentLabel.text = string.Format("{0} is typing", characterName);
			transform.SetAsLastSibling();
			gameObject.SetActive(true);
		}
	}

	private void Update()
	{
		float timeMod = Time.time % 1;
		if (timeMod < 0.25)
		{
			ellipsisLabel.text = "";
		}
		else if (timeMod < 0.5)
		{
			ellipsisLabel.text = " .";
		}
		else if (timeMod < 0.75)
		{
			ellipsisLabel.text = " . .";
		}
		else
		{
			ellipsisLabel.text = " . . .";
		}
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
