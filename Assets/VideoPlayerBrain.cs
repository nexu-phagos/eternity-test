using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class VideoPlayerBrain : MonoBehaviour
{
	private VideoPlayer videoPlayer;
	
	private long frame;
	private long _frameCount;
	private ulong frameCount;

	private GameObject fadeInTweenContainer;
	private DOTweenVisualManager fadeInTweener;
	
	private GameObject fadeOutTweenContainer;
	private DOTweenVisualManager fadeOutTweener;
	
	private GameObject audioForThisLevelContainer;
	private AudioForThisLevel audioForThisLevel;
	
    void Awake()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();
		
		fadeInTweenContainer = GameObject.FindWithTag("FadeInTweener");
		fadeInTweener = fadeInTweenContainer.GetComponent<DOTweenVisualManager>();
		
		fadeOutTweenContainer = GameObject.FindWithTag("FadeOutTweener");
		fadeOutTweener = fadeOutTweenContainer.GetComponent<DOTweenVisualManager>();
		
		
		fadeInTweener.enabled = false;
		fadeOutTweener.enabled = false;
		
		audioForThisLevelContainer = GameObject.Find("MusicForThisLevel");
		audioForThisLevel = audioForThisLevelContainer.GetComponent<AudioForThisLevel>();
		
		Invoke("FadeIntoCutscene", 0.5f);
		//Invoke("ResetFades", 2);
    }
	
	void FadeOutOfCutscene()
	{
		fadeOutTweener.enabled = false;
		fadeInTweener.enabled = false;
		
		fadeOutTweener.enabled = true;
	}
	
	void FadeIntoCutscene()
	{
		fadeInTweener.enabled = true;
		fadeOutTweener.enabled = false;
	}
	
	void ResetFades()
	{
		fadeOutTweener.enabled = false;
	}
	
	void TurnOffCutscene()
	{
		gameObject.SetActive(false);
	}

    void Update()
    {
		frame = videoPlayer.frame;
		frameCount = videoPlayer.frameCount;
		
		_frameCount = (long)frameCount;
		
		if(frame == _frameCount-1)
		{
			//Video has finshed playing!
			Debug.Log("Event for movie end called");
			videoPlayer.Stop();
		
			FadeOutOfCutscene();
			audioForThisLevel.PlayMusicForThisLevel();
			Invoke("TurnOffCutscene", 2);
			Invoke("FadeIntoCutscene", 3);
		}
    }
}
