using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSounds : MonoBehaviour
{
	// AudioSource seems to be for looping/one track
	// public AudioSource backgroundThunderAudioSource;
	public AudioSource lightningStrikeOneShots;
	
	// AudioClip seems better for layered one-shots
	// public AudioClip magic1SFX;
	
	public AudioClip[] lightningSFX;
	
	public float volume=0.8f;
	public float lightningPitch;
	
	void Start()
    {
		lightningPitch = Random.Range(0.1f, 1.5f);
    }

	public void PlayLightningSFX()
	{
		lightningStrikeOneShots.pitch = lightningPitch;
		lightningStrikeOneShots.PlayOneShot(lightningSFX[Random.Range(0, lightningSFX.Length)], volume);
		Debug.Log("Playing Lightning SFX (one-shots)");
	}
}
