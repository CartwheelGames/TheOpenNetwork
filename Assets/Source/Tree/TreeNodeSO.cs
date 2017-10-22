using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNodeSO : ScriptableObject
{
    public string data = "";
	public Comment[] comments = new Comment[0];
	public DialogOption[] options = new DialogOption[0];

	[System.Serializable]
	public class Comment
	{
		public float initialDelay = 0;
		public float ellipseDelay = 0;
		public UserCharacterSO character = null;
		public string text = "";
	}

	[System.Serializable]
	public class DialogOption
	{
		public string previewText = "";
		public string fullText = "";
		public TreeNodeSO resultNode = null;
	}
}
