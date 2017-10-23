using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentFeed : MonoBehaviour
{
	[SerializeField]
	private GameObject commentItemPrefab;
	[SerializeField]
	private Transform commentContainer;
	[SerializeField]
	private Transform bottomSpacer;
	public void AddComment(CharacterData character, string text)
	{
		Debug.LogFormat("Add Comment: {0} says \"{1}\"", character.displayName, text);
		if (commentItemPrefab)
		{
			GameObject itemInstance = Instantiate(commentItemPrefab);
			CommentItem commentItem = itemInstance.GetComponent<CommentItem>();
			if (commentItem != null)
			{
				commentItem.Setup(character, text, System.DateTime.UtcNow);
				commentItem.transform.SetParent(commentContainer);
				commentItem.transform.SetAsLastSibling();
				MoveSpacerToBottom();
			}
		}
	}
	public void MoveSpacerToBottom()
	{
		if (bottomSpacer != null)
		{
			bottomSpacer.SetAsLastSibling();
		}
	}
}
