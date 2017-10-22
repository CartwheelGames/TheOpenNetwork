using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsDisplay : MonoBehaviour
{
	[SerializeField]
	private OptionItem[] optionItems = new OptionItem[0];
	[SerializeField]
	public event Action<OptionData> onOptionChosenEvent;
	public bool isInputEnabled { get; private set; }

	private void Start()
	{
		foreach (OptionItem item in optionItems)
		{
			item.Initialize(ChooseOption);
		}
	}

	public void EnableInput()
	{
		isInputEnabled = true;
	}

	public void DisableInput()
	{
		isInputEnabled = false;
	}

	public void SetupOptions(OptionData[] options)
	{
		for (int i = 0; i < optionItems.Length; i++)
		{
			if (i < options.Length)
			{
				optionItems[i].Setup(options[i]);
			}
			else
			{
				optionItems[i].Disable();
			}
		}
	}

	private void Update()
	{
		if (isInputEnabled)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			{
				ChooseOption(optionItems[0]);
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
			{
				ChooseOption(optionItems[1]);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				ChooseOption(optionItems[2]);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				ChooseOption(optionItems[3]);
			}
		}
	}

	private void ChooseOption(OptionItem item)
	{
		if (item != null && item.isEnabled && onOptionChosenEvent != null && item.optionData != null)
		{
			onOptionChosenEvent(item.optionData);
		}
	}

	[System.Serializable]
	public class OptionItem
	{
		[SerializeField]
		private Button button = null;
		[SerializeField]
		private Text label = null;
		public OptionData optionData { get; private set; }
		public bool isEnabled = false;
		private Action<OptionItem> choiceCallback;
		public void Initialize(Action<OptionItem> choiceAction)
		{
			choiceCallback = choiceAction;
			if (button != null)
			{
				button.onClick.AddListener(OnClickButton);
			}
		}

		private void OnClickButton()
		{
			choiceCallback(this);
		}

		public void Setup(OptionData rawOptionData)
		{
			isEnabled = true;
			optionData = rawOptionData;
			if (label != null)
			{
				label.text = optionData.previewText;
			}
			if (button != null)
			{
				button.gameObject.SetActive(true);
			}
		}

		public void Disable()
		{
			optionData = null;
			isEnabled = false;
			if (label != null)
			{
				label.text = "";
			}
			if (button != null)
			{
				button.gameObject.SetActive(false);
			}
		}
	}
}
