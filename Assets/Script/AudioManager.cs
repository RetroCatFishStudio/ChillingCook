using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	public Sound[] musicSound, sfxSound;
	public AudioSource musicSource, sfxSource, sfxMusic;
	private void Start()
	{
		DontDestroyOnLoad(this.gameObject);
		PlayMusic("BackGroundMusic");
	}
	public void PlaySfxMusic(string name)
	{
		Sound s = Array.Find(musicSound, x => x.name == name);
		if (s == null)
		{
			Debug.Log("Sound Not Found");
		}
		else
		{
			sfxMusic.clip = s.clip;
			sfxMusic.Play();
		}
	}
	public void StopSfxMusic(string name)
	{
		Sound s = Array.Find(musicSound, x => x.name == name);
		if (s == null)
		{
			Debug.Log("Sound Not Found");
		}
		else
		{
			sfxMusic.clip = s.clip;
			sfxMusic.Stop();
		}
	}
	public void PlayMusic(string name)
	{
		Sound s = Array.Find(musicSound, x => x.name == name);
		if (s == null)
		{
			Debug.Log("Sound Not Found");
		}
		else
		{
			musicSource.clip = s.clip;
			musicSource.Play();
		}
	}
	public void StopMusic(string name)
	{
		Sound s = Array.Find(musicSound, x => x.name == name);
		if (s == null)
		{
			Debug.Log("Sound Not Found");
		}
		else
		{
			musicSource.clip = s.clip;
			musicSource.Stop();
		}
	}
	public void PlayeSFX(string name)
	{
		Sound s = Array.Find(sfxSound, x => x.name == name);
		if (s == null)
		{
			Debug.Log("Sound Not Found");
		}
		else
		{
			sfxSource.PlayOneShot(s.clip);
		}
	}
}
