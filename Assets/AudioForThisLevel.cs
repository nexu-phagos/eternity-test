using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForThisLevel : MonoBehaviour
{
	[SerializeField] private AudioClip musicForThisLevel;
	
	[SerializeField] private AudioClip mainMenuMusic;
	[SerializeField] private AudioClip eternityForestMusic;
	[SerializeField] private AudioClip forestPathMusic;
	
	private void Start()
	{
		// AudioManager.Instance.PlayMusicWithFade(eternityForestMusic);
	}
	
	public void PlayMusicForThisLevel()
	{
		AudioManager.Instance.PlayMusicWithFade(musicForThisLevel);
	}
}
