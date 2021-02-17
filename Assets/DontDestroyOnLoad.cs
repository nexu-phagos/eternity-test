using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] soundManager = GameObject.FindGameObjectsWithTag("SoundManager");
		GameObject[] eventSystem = GameObject.FindGameObjectsWithTag("EventSystem");
		GameObject[] canvas = GameObject.FindGameObjectsWithTag("Canvas");
		GameObject[] inventoryManager = GameObject.FindGameObjectsWithTag("InventoryManager");
		GameObject[] tweenManager = GameObject.FindGameObjectsWithTag("TweenManager");
		GameObject[] dialogueManager = GameObject.FindGameObjectsWithTag("DialogueManager");
		GameObject[] levelManager = GameObject.FindGameObjectsWithTag("LevelManager");
		GameObject[] gameHandler = GameObject.FindGameObjectsWithTag("GameHandler");
		GameObject[] persistentSFX = GameObject.FindGameObjectsWithTag("PersistentSFX");
	
		if (this.tag == "Player")
			{
				if (player.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		if (this.tag == "PersistentSFX")
			{
				if (persistentSFX.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		if (this.tag == "GameHandler")
			{
				if (gameHandler.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		if (this.tag == "SoundManager")
			{
				if (soundManager.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		if (this.tag == "EventSystem")
			{
				if (eventSystem.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		if (this.tag == "Canvas")
			{
				if (canvas.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		if (this.tag == "InventoryManager")
			{
				if (inventoryManager.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		 if (this.tag == "TweenManager")
			{
				if (tweenManager.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		if (this.tag == "DialogueManager")
			{
				if (dialogueManager.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
			
		if (this.tag == "LevelManager")
			{
				if (levelManager.Length > 1)
				{
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
    }
	
	public void PlayerCheck()
	{
		GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
		
		Debug.Log("PlayerCheck DDOL successful");
		if (this.tag == "Player")
			{
				if (player.Length > 1)
				{
					Debug.Log("found multiple items tagged with Player");
					Destroy(this.gameObject);
				}

				DontDestroyOnLoad(this.gameObject);
			}
	}
}