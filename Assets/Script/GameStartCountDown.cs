using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.CullingGroup;

public class GameStartCountDown : MonoBehaviour
{
	[SerializeField] private Text countdownText;

	private void Start()
	{
		Observer.Instance.AddListener("OnStateChanged", OnStateChanged);
		Hide();
	}

	private void OnStateChanged(object[] data)
	{
		if (GameManager.Instance.IsCountDownToStart())
		{
			Show();
		}
		else
		{
			Hide();
		}
	}

	private void Update()
	{
		if (GameManager.Instance.IsCountDownToStart())
		{
			countdownText.text = Mathf.Ceil(GameManager.Instance.GetCountDownToStartTimer()).ToString();
		}
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
