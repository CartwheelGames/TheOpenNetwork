using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCharacterSO : ScriptableObject {
	public Sprite avatar = null;
	public string handle = "";
    [TextArea]
	public string bio;
}
