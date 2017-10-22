using Action = System.Action;
using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{
	public enum GameState {NONE, INTRO, GAME, END}
	private GameState _currentGameState = GameState.NONE;
	public static event Action enterStateEvent;
	public static event Action<float> leaveStateEvent;	
	public GameState currentGameState {
		get{
			return _currentGameState;
		}
		set
		{
			if (_currentGameState != value)
			{
				_currentGameState = value;
			}
		}
	}
}
