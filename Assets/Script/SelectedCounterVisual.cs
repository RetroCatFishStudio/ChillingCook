using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class SelectedCounterVisual : MonoBehaviour
{
	[SerializeField] private BaseCounter clearCounter;
	[SerializeField] private GameObject[] visualGameObject;
	private void Start()
	{
		PlayerController.Instance.OnSelectedCounter += Player_SelectedCounter;
	}

	private void Player_SelectedCounter(object sender, PlayerController.OnSelectedCounterChanged e)
	{

		if (e.selectedCouter == clearCounter)
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
		foreach (GameObject go in visualGameObject)
		{
			go.SetActive(true);
		}
	}
	private void Hide()
	{
		foreach (GameObject go in visualGameObject)
		{
			go.SetActive(false);
		}
	}
}
