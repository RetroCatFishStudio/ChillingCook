using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button menuButton;
	private void Start()
	{
		Observer.Instance.AddListener("OnStateChanged", OnStateChanged);
		Hide();
		resumeButton.onClick.AddListener(ResumeClick);
		menuButton.onClick.AddListener(MenuClick);
	}

	private void OnStateChanged(object[] data)
	{
		if (GameManager.Instance.IsGamePaused())
		{
			Show();
		}
		else
		{
			Hide();
		}
	}

	private void ResumeClick()
	{
		GameManager.Instance.state = GameManager.GameState.Playing;
		this.Hide();
	}

	private void MenuClick()
	{
		SceneManager.LoadScene(0);
	}

	private void Show()
	{
		gameObject.SetActive(true);
	}

	private void Hide()
	{
		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		Observer.Instance.RemoveListener("OnStateChanged", OnStateChanged);
	}
}
