﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsDisplay : MonoBehaviour
{
	[SerializeField]
	private OptionItem[] optionItems = new OptionItem[0];
	[SerializeField]
	private Image userFeed = null;
	[SerializeField]
	private Image userIcon = null;
	[SerializeField]
	private Text userComment = null;
	public event Action<OptionData> onOptionChosenEvent;
	public bool isInputEnabled { get; private set; }

	private void Start()
	{
		userFeed.enabled = true;
		userIcon.enabled = true;
		userComment.enabled = true;
		userComment.text = "What's on your mind right now?";
		foreach (OptionItem item in optionItems)
		{
			item.Initialize(ChooseOption);
		}
	}

	public void Hide()
	{
		isInputEnabled = false;
		//
		userFeed.enabled = true;
		userIcon.enabled = true;
		userComment.enabled = true;
		foreach (OptionItem item in optionItems)
		{
			if (item != null)
			{
				item.Disable();
			}
		}
	}

	public void SetupOptions(OptionData[] options)
	{
		isInputEnabled = true;
		//
		userFeed.enabled = false;
		userIcon.enabled = false;
		userComment.enabled = false;
		string[] gamePadNames = Input.GetJoystickNames();
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
		[SerializeField]
		private Image arrowImage = null;
		[SerializeField]
		private Image gamePadImage = null;
		public OptionData optionData { get; private set; }
		public bool isEnabled { get; private set; }
		private Action<OptionItem> choiceCallback;
		public void Initialize(Action<OptionItem> choiceAction)
		{
			choiceCallback = choiceAction;
			if (button != null)
			{
				button.onClick.AddListener(OnClickButton);
				button.targetGraphic = arrowImage;
				arrowImage.enabled = true;
				gamePadImage.enabled = false;
			}
			Disable();
		}

		private void OnClickButton()
		{
			choiceCallback(this);
		}

		public void Setup(OptionData rawOptionData)
		{
			isEnabled = true;
			if (rawOptionData)
			{
				optionData = rawOptionData;
				if (label != null)
				{
					label.text = optionData.previewText;
				}
				if (button != null)
				{
					button.gameObject.SetActive(true);
					string[] names = Input.GetJoystickNames();
					if (names.Length > 0)
					{
						arrowImage.enabled = false;
						gamePadImage.enabled = true;
					}
					else
					{
						arrowImage.enabled = true;
						gamePadImage.enabled = false;
					}
				}
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
