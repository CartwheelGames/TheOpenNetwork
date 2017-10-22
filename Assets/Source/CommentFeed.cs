using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentFeed : MonoBehaviour
{
	[SerializeField]
	private GameObject commentItemPrefab;
	private Transform commentContainer;

	public void AddComment(NodeData.CommentData commentData)
	{
		Debug.LogFormat("Add Comment: {0} says \"{1}\"", commentData.character.displayName, commentData.text);
		if (commentItemPrefab)
		{
			GameObject itemInstance = Instantiate(commentItemPrefab);
			CommentItem commentItem = itemInstance.GetComponent<CommentItem>();
			if (commentItem != null)
			{
				commentItem.Setup(commentData, System.DateTime.UtcNow);
				commentItem.transform.SetParent(commentContainer);
				commentItem.transform.SetAsLastSibling();
			}
		}
	}
}
