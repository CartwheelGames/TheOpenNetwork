using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentItem : MonoBehaviour
{
	private float textDelay = 0.125f;

	[SerializeField]
	private Image avatarRenderer = null;
	[SerializeField]
	private Text contentLabel = null;
	[SerializeField]
	private Text timeStampLabel = null;


    public void Setup (CharacterData character, string text, System.DateTime timestamp)
	{
		if (contentLabel != null && character && !string.IsNullOrEmpty(text))
		{
			contentLabel.text = "<color=darkblue>" + character.displayName + ":</color> " + text;
			//StartCoroutine (Typing());
		}
		if (avatarRenderer && character && character.avatar)
		{
			avatarRenderer.sprite = character.avatar;
		}
		if (timeStampLabel != null)
		{
			timeStampLabel.text = timestamp.ToShortTimeString();
		}
	}

	//IEnumerator Typing(){
			//foreach (char i in contentLabel.text) {
			    //contentLabel.text += i;
				//yield return new WaitForSeconds (textDelay);
			//}
}
