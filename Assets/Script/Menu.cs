using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

	private void Start()
	{
		playButton.onClick.AddListener(PlayClick);
		quitButton.onClick.AddListener(QuitClick);
	}
	private void PlayClick()
	{
		SceneManager.LoadScene(1);
	}
	private void QuitClick()
	{
		Application.Quit();
	}
}
