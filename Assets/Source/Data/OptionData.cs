using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionData : ScriptableObject
{
	public string previewText = "";
	public string fullText = "";
	public NodeData resultNode = null;
	public OptionValue value;
}
