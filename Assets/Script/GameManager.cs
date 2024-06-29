using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public enum GameState
	{
		Pre = 0,
		Waiting = 1,
		Loading = 2,
		Playing = 3,
		Over = 4,
		Pause = 5
	}

	public GameState state;
	private float waitingforState = 0f;
	private float waitingToStartTimer = 15f;
	private float countdownToStartTimer = 3f;
	public float gamePlayTimer;
	private float gamePlayTimerMax = 120f;

	private void Start()
	{
		Observer.Instance.AddListener("OnStateChanged", OnStateChanged);
		SetState(GameState.Pre);
	}

	private void Update()
	{
		switch (state)
		{
			case GameState.Pre:
				waitingforState -= Time.deltaTime;

				if (waitingforState < 0f)
				{
					SetState(GameState.Waiting);
				}
				break;
			case GameState.Waiting:
				waitingToStartTimer -= Time.deltaTime;
				if (waitingToStartTimer < 0f)
				{
					SetState(GameState.Loading);
				}
				break;
			case GameState.Loading:
				countdownToStartTimer -= Time.deltaTime;
				if (countdownToStartTimer < 0f)
				{
					gamePlayTimer = gamePlayTimerMax;
					SetState(GameState.Playing);
				}
				break;
			case GameState.Playing:
				gamePlayTimer -= Time.deltaTime;
				if (gamePlayTimer < 0f)
				{
					SetState(GameState.Over);
				}
				break;
			case GameState.Pause:
				SetState(GameState.Pause);
				break;
			case GameState.Over:
				break;
		}
		Debug.Log(state);
	}

	private void SetState(GameState newState)
	{
		state = newState;
		Observer.Instance.Notify("OnStateChanged", state);
	}

	private void OnStateChanged(object[] data)
	{
	}

	public bool IsGamePlaying()
	{
		return state == GameState.Playing;
	}

	public bool IsCountDownToStart()
	{
		return state == GameState.Loading;
	}

	public float GetCountDownToStartTimer()
	{
		return countdownToStartTimer;
	}

	public bool IsGameOver()
	{
		return state == GameState.Over;
	}
	public bool IsGamePaused()
	{
		return state == GameState.Pause;
	}

	public bool IsGameStartWaiting()
	{
		return state == GameState.Waiting;
	}

	public float GetPlayingTime()
	{
		return gamePlayTimer / gamePlayTimerMax;
	}

	private void OnDestroy()
	{
		Observer.Instance.RemoveListener("OnStateChanged", OnStateChanged);
	}
}
