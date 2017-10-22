using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeData : ScriptableObject
{
    public string data = "";
	public CommentData[] comments = new CommentData[0];
	public OptionData[] options = new OptionData[0];
	public float timeoutDelay = 0;
	public float ellipsisDelay = 0;
	public NodeData defaultResultNode = null;

	[System.Serializable]
	public class CommentData
	{
		public float endDelay = 0;
		public float ellipsisDelay = 0;
		public CharacterData character = null;
		public string text = "";
	}

	[System.Serializable]
	public class OptionData
	{
		public string previewText = "";
		public string fullText = "";
		public NodeData resultNode = null;
	}
}
