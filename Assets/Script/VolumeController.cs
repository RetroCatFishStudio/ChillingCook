using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource volumeSource;
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeValue);
        volumeSource =GameObject.Find("AudioManager").GetComponentInChildren<AudioSource>();
    }

	private void ChangeValue(float arg0)
	{
		volumeSource.volume = arg0;
	}
}
