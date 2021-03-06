﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeReader : MonoBehaviour
{
	[SerializeField]
	private CharacterData playerCharacter = null;
	[SerializeField]
	private NodeData initialNode = null;
	[SerializeField]
	private TimeoutIndicator timeoutIndicator = null;
	[SerializeField]
	private float minOptionInputDelay = 4f;
	[SerializeField]
	private CommentFeed commentFeed = null;
	[SerializeField]
	private OptionsDisplay optionsDisplay = null;
	[SerializeField]
	private ScrollRect scrollRect;
	private NodeData currentNode = null;
	private Dictionary<OptionValue, int> scoreTracker = new Dictionary<OptionValue, int>();

	private void Awake()
	{
		if (GameManager.instance != null)
		{
			GameManager.instance.enterStateEvent += OnEnterState;
		}
		if (optionsDisplay != null)
		{
			optionsDisplay.onOptionChosenEvent += OnOptionChosen;
		}
	}

	private void OnEnterState(GameState state)
	{
		switch (state)
		{
		    case GameState.INTRO:
				break;
			case GameState.GAME:
			    Initialize();
				break;
			case GameState.END:
				break;
		}
	}

	private void Initialize()
	{
		DisplayNode(initialNode);
	}

	private void DisplayNode(NodeData nodeData)
	{
		if (nodeData != null && currentNode != nodeData)
		{
			currentNode = nodeData;
			StartCoroutine(ProcessNodeData(nodeData));
		}
	}

	private IEnumerator ProcessNodeData(NodeData nodeData)
	{
		if (optionsDisplay && optionsDisplay.isInputEnabled)
		{
			yield return new WaitForSeconds(minOptionInputDelay);
		}
		foreach (NodeData.CommentData commentData in nodeData.comments)
		{
			//The pause before the timeout indicator appears:
			yield return new WaitForSeconds(commentData.ellipsisDelay);
			ShowTimeoutIndicator(commentData.character.displayName);
			//The pause after the timeout indicator appears, before the next comment is shown:
			yield return new WaitForSeconds(commentData.endDelay);
			HideTimeoutIndicator();
			//Hide any latantly displaying options:
			HideOptions();
			//Actually add the comment to the feed:
			commentFeed.AddComment(commentData.character, commentData.text);
			if (scrollRect)
			{
				scrollRect.velocity = Vector2.zero;
				scrollRect.normalizedPosition = Vector2.zero;
			}
		}
		//Now that all comments from this node have been shown, show the player their options:
		ShowOptions(nodeData.options);
		//Begin showing the default next node. A player input should interrupt this.
		DisplayNode(nodeData.defaultResultNode);
	}

	public void ShowOptions(OptionData[] options)
	{
		if (optionsDisplay != null)
		{
			optionsDisplay.SetupOptions(options);
		}
	}

	public void HideOptions()
	{
		if (optionsDisplay != null)
		{
			optionsDisplay.Hide();
		}
	}

	public void OnOptionChosen(OptionData option)
	{
		if (option != null)
		{
			//Interrupt the crrent node:
			StopAllCoroutines();
			HideOptions();
			//Show the next node specified by the chosen option:
			if (option.resultNode != null)
			{
				DisplayNode(option.resultNode);
			}
			else
			{
				GameManager.instance.SetState(GameState.END);
				currentNode = null;
			}
			commentFeed.AddComment(playerCharacter, option.fullText);
			AddToScore(option.value);
			HideTimeoutIndicator();
			if (scrollRect)
			{
				scrollRect.velocity = Vector2.zero;
				scrollRect.normalizedPosition = Vector2.zero;
			}
		}
	}

	private void AddToScore(OptionValue value)
	{
		if (scoreTracker.ContainsKey(value))
		{
			scoreTracker[value]++;
		}
		else
		{
			scoreTracker.Add(value, 1);
		}
	}

	private void ShowTimeoutIndicator(string characterName)
	{
		if (timeoutIndicator != null)
		{
			timeoutIndicator.ShowWithName(characterName);
			commentFeed.MoveSpacerToBottom();
		}
	}
	private void HideTimeoutIndicator()
	{
		if (timeoutIndicator != null)
		{
			timeoutIndicator.Hide();
		}
	}
}
