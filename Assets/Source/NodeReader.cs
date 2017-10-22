using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeReader : MonoBehaviour {

	[SerializeField]
	private NodeData initialNode = null;
	[SerializeField]
	private NodeData currentNode = null;
	[SerializeField]
	private GameObject ellipsis = null;
	private float startTimeOfCurrentNode = 0f;

	private void Awake ()
	{
		if (GameManager.instance != null)
		{
			GameManager.instance.enterStateEvent += OnEnterState;
		}
	}
	
	private void OnEnterState (GameState state)
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
		//1 Clear all existing text and stuff from the UI

		DisplayNode(initialNode);
	}

	private void DisplayNode(NodeData nodeData)
	{
		if (nodeData != null && currentNode != nodeData)
		{
			currentNode = nodeData;
			//2 Add the node's comments to the vertical layout group one at a time, with delays

			//3 Once the comments are done, show the dialog options, then delay before the input times-out.

			//4 If the options times out, then just move onto the default node AND hide/remove current options
			//DisplayNode(nodeData.defaultResultNode);
		}
	}

	private IEnumerator DisplayNodeComments(NodeData nodeData)
	{
		foreach (NodeData.CommentData commentData in nodeData.comments)
		{
			yield return new WaitForSeconds(commentData.ellipsisDelay);
			yield return new WaitForSeconds(commentData.initialDelay);
		}
	}

	private void Update()
	{
		if (currentNode)
		{
			if (Time.time > startTimeOfCurrentNode + currentNode.endDelay)
			{
				ellipsis.SetActive(false);
			}
			else if (!ellipsis.activeSelf && Time.time > startTimeOfCurrentNode + currentNode.ellipsisDelay)
			{
				ellipsis.SetActive(true);
			}
		}
	}

	public void OnOptionChosen (NodeData.OptionData option)
	{
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
			if (ellipsis.activeSelf)
			{
				ellipsis.SetActive(false);
			}
		}
	}
}
