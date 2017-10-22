using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeData : ScriptableObject
{
    public string data = "";
	public Comment[] comments = new Comment[0];
	public DialogOption[] options = new DialogOption[0];
	public float endDelay = 0;
	public float ellipseDelay = 0;

	[System.Serializable]
	public class Comment
	{
		public float initialDelay = 0;
		public float ellipseDelay = 0;
		public CharacterData character = null;
		public string text = "";
	}

	[System.Serializable]
	public class DialogOption
	{
		public string previewText = "";
		public string fullText = "";
		public NodeData resultNode = null;
	}
}
