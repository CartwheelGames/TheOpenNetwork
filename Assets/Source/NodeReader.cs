using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeReader : MonoBehaviour {
	public NodeData initialNode = null;
	private void Awake ()
	{
		if (GameManager.instance != null)
		{
			GameManager.instance.enterStateEvent += OnEnterState;
		}
	}
	
	private void OnEnterState (GameManager.GameState state)
	{
		switch (state)
		{
			case GameManager.GameState.INTRO:
				break;
			case GameManager.GameState.END:
				break;
			case GameManager.GameState.GAME:
				Initialize();
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
		//2 Add the node's comments to the vertical layout group one at a time, with delays

		//3 Once the comments are done, show the dialog options, then delay before the input times-out.

		//4 If the options times out, then just move onto the default node AND hide/remove current options
		//DisplayNode(nodeData.defaultResultNode);
	}

	public void OnOptionChosen (NodeData.DialogOption option)
	{
		if (option != null && option.resultNode != null)
		{
			if (option.resultNode.isEndNode)
			{
				GameManager.instance.SetState(GameManager.GameState.END);
			}
			else
			{
				DisplayNode(option.resultNode);
			}
		}
	}
}
