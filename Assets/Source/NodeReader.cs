using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeReader : MonoBehaviour
{

	[SerializeField]
	private NodeData initialNode = null;
	[SerializeField]
	private TimeoutIndicator timeoutIndicator = null;
	[SerializeField]
	private float minOptionInputDelay = 4f;
	private bool debugIsShowingOptions = false;
	private NodeData currentNode = null;

	private void Awake()
	{
		if (GameManager.instance != null)
		{
			GameManager.instance.enterStateEvent += OnEnterState;
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
		if (debugIsShowingOptions)
		{
			yield return new WaitForSeconds(minOptionInputDelay);	
		}
		foreach (NodeData.CommentData commentData in nodeData.comments)
		{
			//The pause before the timeout indicator appears:
			yield return new WaitForSeconds(commentData.ellipsisDelay);
			ShowTimeoutWithName(commentData.character.displayName);
			//The pause after the ellipsis appears, before the next comment is shown:
			yield return new WaitForSeconds(commentData.endDelay);
			HideEllipsis();
			//Hide any latantly displaying options:
			HideOptions();
			//Actually add the comment to the feed:
			AddComment(commentData);
		}
		//Now that all comments from this node have been shown, show the player their options:
		DisplayOptions(nodeData.options);
		//Begin showing the default next node. A player input should interrupt this.
		DisplayNode(nodeData.defaultResultNode);
	}

	public void AddComment(NodeData.CommentData commentData)
	{
		//TODO: Create comment oject based on data contents. Add to UI list.
		if (commentData != null && commentData.character != null)
		{
			Debug.LogFormat("Add Comment: {0} says \"{1}\"", commentData.character.displayName, commentData.text);
		}
	}

	public void DisplayOptions(NodeData.OptionData[] options)
	{
		if (!debugIsShowingOptions)
		{
			debugIsShowingOptions = true;
			//TODO: Show dialog options based on stored data.
			Debug.Log("Display Options");
		}
	}

	public void HideOptions()
	{
		if (debugIsShowingOptions)
		{
			debugIsShowingOptions = false;
			//TODO: Hide the options UI
			Debug.Log("Hide Options");
		}
	}

	private void ShowTimeoutWithName(string characterName)
	{
		//TODO: Should be in a UI script
		if (timeoutIndicator != null && !timeoutIndicator.gameObject.activeSelf)
		{
			timeoutIndicator.ShowWithName(characterName);
		}
	}

	private void HideEllipsis()
	{
		//TODO: Should be in a UI script
		if (timeoutIndicator != null && timeoutIndicator.gameObject.activeSelf)
		{
			timeoutIndicator.Hide();
		}
	}

	public void OnOptionChosen(NodeData.OptionData option)
	{
		//Interrupt the crrent node:
		StopAllCoroutines();
		HideOptions();
		timeoutIndicator.Hide();
		//Show the next node specified by the chosen option:
		if (option != null)
		{
			if (option.resultNode != null)
			{
				DisplayNode(option.resultNode);
			}
			else
			{
				GameManager.instance.SetState(GameState.END);
				currentNode = null;
			}
			HideEllipsis();
		}
	}
}
