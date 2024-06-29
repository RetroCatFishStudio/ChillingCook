using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
	[SerializeField] private Button pauseButton;
	void Start()
    {
		pauseButton.onClick.AddListener(PauseClick);

	}

	private void PauseClick()
	{
		if (GameManager.Instance.IsGamePlaying())
		{
			GameManager.Instance.state = GameManager.GameState.Pause;
		}
	}
}
