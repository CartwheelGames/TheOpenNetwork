using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : ScriptableObject
{
	public Sprite avatar = null;
	private string _displayName = "";
	public string displayName { get { return "@" + (string.IsNullOrEmpty(_displayName) ? name : _displayName); } }
	[TextArea]
	public string bio;
}
