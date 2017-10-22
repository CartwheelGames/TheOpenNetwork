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
			if (contentLabel != null && !string.IsNullOrEmpty(commentData.text))
			{
				contentLabel.text = commentData.text;
			}
			if (avatarRenderer && commentData.character && commentData.character.avatar)
			{
				avatarRenderer.sprite = commentData.character.avatar;
			}
			if (timeStampLabel != null)
			{
				contentLabel.text = timestamp.ToShortDateString();
			}
		}
	}
}
