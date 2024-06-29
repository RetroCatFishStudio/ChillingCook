using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Introduction : MonoBehaviour
{
	private void Start()
	{
		Observer.Instance.AddListener("OnStateChanged", OnStateChanged);
		Hide();
	}

	private void OnStateChanged(object[] data)
	{
		if (GameManager.Instance.IsGameStartWaiting())
		{
			Show();
		}
		else
		{
			Hide();
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