using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentItem : MonoBehaviour
{
	[SerializeField]
	private Image avatarRenderer = null;
	[SerializeField]
	private Text contentLabel = null;
	[SerializeField]	
	private Text timeStampLabel = null;
	public void Setup(NodeData.CommentData commentData, System.DateTime timestamp)
	{
		if (commentData != null)
		{
			if (contentLabel != null && commentData.character && !string.IsNullOrEmpty(commentData.text))
			{
				contentLabel.text = "<b><color=darkblue>" + commentData.character.displayName + ":</color></b> " + commentData.text;
			}
			if (avatarRenderer && commentData.character && commentData.character.avatar)
			{
				avatarRenderer.sprite = commentData.character.avatar;
			}
			if (timeStampLabel != null)
			{
				timeStampLabel.text = timestamp.ToShortTimeString();
			}
		}
	}
}
