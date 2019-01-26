using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;

public class AudioManager : MonoBehaviour 
{
	public Sound music;
	public Sound[] sounds;

	bool sfxOn = true;
	bool musicOn = true;

	public static AudioManager instance;

	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		music.source = gameObject.AddComponent<AudioSource>();
		music.source.clip = music.clip;
		music.source.volume = music.volume;
		music.source.pitch = music.pitch;
		music.source.loop = music.loop;

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
            s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	private void Start()
	{
		music.source.Play();
	}

	public bool ToggleMusic()
	{
  		if (musicOn)
		{
			music.source.Stop();
		}
		else
		{
			music.source.Play();
		}

		musicOn = !musicOn;
		return musicOn;
	}

	public bool ToggleSFX()
	{
		sfxOn = !sfxOn;
		return sfxOn;
	}

	public void Play (string name)
	{
		if (sfxOn)
		{
			Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.Log("Sound -" + name + "- not found");
                return;
            }

            s.source.Play();
		}
	}
}
