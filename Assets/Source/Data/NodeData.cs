using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OptionValue {NONE, NEGATIVE, CONFRONTATIONAL, POSITIVE}

public class NodeData : ScriptableObject
{
	public string data = "";
	public CommentData[] comments = new CommentData[0];
	public OptionData[] options = new OptionData[0];
	public NodeData defaultResultNode = null;

	[System.Serializable]
	public class CommentData
	{
		public float endDelay = 1f;
		public float ellipsisDelay = 1f;
		public CharacterData character = null;
		[TextArea]
		public string text = "";
	}

	[System.Serializable]
	public class OptionData
	{
		public string previewText = "";
		public string fullText = "";
		public NodeData resultNode = null;
		public OptionValue value;
	}
}
