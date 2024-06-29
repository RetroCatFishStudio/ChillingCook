using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
	[SerializeField] private Image timerIamage;
	private void Update()
	{
		timerIamage.fillAmount = GameManager.Instance.GetPlayingTime();
	}
}
