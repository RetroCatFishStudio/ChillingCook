using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	[SerializeField] private Button replayButton;
	[SerializeField] private Button quitButton;
	[SerializeField] private Text pointText;

	private void Start()
	{
		Observer.Instance.AddListener("OnStateChanged", OnStateChanged);
		Hide();
		replayButton.onClick.AddListener(PlayClick);
		quitButton.onClick.AddListener(QuitClick);
	}

	private void OnStateChanged(object[] data)
	{
		if (GameManager.Instance.IsGameOver())
		{
			Show();
			pointText.text = DeliveryManager.Instance.point.ToString();
		}
		else
		{
			Hide();
		}
	}

	private void PlayClick()
	{
		SceneManager.LoadScene(1);
	}

	private void QuitClick()
	{
		Application.Quit();
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
