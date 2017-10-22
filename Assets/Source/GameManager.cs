using Action = System.Action;
using System.Collections;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public enum GameState {NONE, INTRO, GAME, END}
	private GameState currentGameState = GameState.NONE;
	public event Action<GameState> enterStateEvent;
	public event Action<GameState> leaveStateEvent;
	private void Awake()
	{
		instance = this;
	}
	private void Start()
	{
		SetState(GameState.GAME);
	}
	public GameState GetCurrentState()
	{
		return currentGameState;
	}
	public void SetState(GameState state)
	{
		if (currentGameState != state)
		{
			if (leaveStateEvent != null)
			{
				leaveStateEvent(currentGameState);
			}
			if (enterStateEvent != null)
			{
				enterStateEvent(state);
			}
			currentGameState = state;
		}
	}
}
