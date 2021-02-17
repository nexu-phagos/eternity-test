using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadLevel : MonoBehaviour
{
	private GameObject player;
	private GameObject levelManager;
	
	public int zoneToLoad;
	
	public Transform nextZoneSpawnLocation;
	
	[SerializeField]
	private int mainMenu = 0;
	
	[SerializeField]
	private int eternityEdge = 1;
	
	[SerializeField]
	private int forestPath1 = 2;
	[SerializeField]
	private int forestPath2 = 3;
	[SerializeField]
	private int forestPath3 = 4;
	
	[SerializeField]
	private int home = 5;
	
	[SerializeField]
	private int zone1 = 6;
	[SerializeField]
	private int zone2 = 7;
	[SerializeField]
	private int zone3 = 8;
	[SerializeField]
	private int zone4 = 9;
	[SerializeField]
	private int zone5 = 10;
	[SerializeField]
	private int zone6 = 11;
	[SerializeField]
	private int zone7 = 12;
	[SerializeField]
	private int zone8 = 13;
	[SerializeField]
	private int zone9 = 14;
	[SerializeField]
	private int zone10 = 15;
	[SerializeField]
	private int zone11 = 16;
	
	[SerializeField]
	private int limboZone = 99;

	private GameObject fadeInTweenContainer;
	private DOTweenVisualManager fadeInTweener;
	
	private GameObject fadeOutTweenContainer;
	private DOTweenVisualManager fadeOutTweener;
	
	private GameObject audioForThisLevelContainer;
	private AudioForThisLevel audioForThisLevel;

	private GameObject persistentSFXGameObject;
	private PersistentSFX persistentSFX;
	
	private GameObject _gameHandler;
	private GameHandler gameHandler;
	
    // Start is called before the first frame update
    void Start()
    {
		persistentSFXGameObject = GameObject.Find("PersistentSFX");
		persistentSFX = persistentSFXGameObject.GetComponent<PersistentSFX>();
		
		audioForThisLevelContainer = GameObject.Find("MusicForThisLevel");
		audioForThisLevel = audioForThisLevelContainer.GetComponent<AudioForThisLevel>();
		
		player = GameObject.FindWithTag("Player");
        levelManager = GameObject.Find("LevelManager");
		
		fadeInTweenContainer = GameObject.FindWithTag("FadeInTweener");
		fadeInTweener = fadeInTweenContainer.GetComponent<DOTweenVisualManager>();
		
		fadeOutTweenContainer = GameObject.FindWithTag("FadeOutTweener");
		fadeOutTweener = fadeOutTweenContainer.GetComponent<DOTweenVisualManager>();
		
		fadeInTweener.enabled = true;
		fadeOutTweener.enabled = false;
		
		_gameHandler = GameObject.FindWithTag("GameHandler");
		gameHandler = _gameHandler.GetComponent<GameHandler>();
		
		audioForThisLevel.PlayMusicForThisLevel();
    }
	
	void ResetPlayerPosition()
	{
		player = GameObject.FindWithTag("Player");
		
		// player.transform.position = new Vector3(0,0,0);
		player.transform.position = nextZoneSpawnLocation.transform.position;
	}
	
	void KillAndReincarnateProxy()
	{
		gameHandler.KillAndReincarnate();
	}

    void OnTriggerEnter(Collider other)
	{
		// FADE OUT STUFF
		/* 
		This is triggered at two key points:
			FadeIn (from white) is triggered whenever LoadLevel scripts (including instances) Start();
			FadeOut (to white) is triggered when a new level is loaded, e.g. from a portal etc.
			When a level is loaded, fadeIn needs to be disbaled, so it can be re-enabled and trigger the fade in tween
			
			All of this also depends on the Canvas object always being available in every scene
			That means Canvas must be retained with DontDestroyOnLoad
			This is fine because that's already set up
		*/
		if (this.gameObject.tag == "LevelLoader")
		{
			fadeOutTweener.enabled = true;
			Invoke("ResetPlayerPosition", 2);
			//ResetPlayerPosition();
			persistentSFX.PlayPortalSFX();
			
			// not sure if this works; it's supposed to manage what each level loads, using a function in GameHandler
			Invoke("KillAndReincarnateProxy", 2);
		}		
				
		if (zoneToLoad == mainMenu)
		{
			levelManager.GetComponent<LevelManager>().MainMenuLoad();
			levelManager.GetComponent<LevelManager>().CheckLevel(mainMenu);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
			
		}
		
		if (zoneToLoad == eternityEdge)
		{
			levelManager.GetComponent<LevelManager>().EternityEdgeLoad();
			levelManager.GetComponent<LevelManager>().CheckLevel(eternityEdge);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == forestPath1)
		{
			levelManager.GetComponent<LevelManager>().Invoke("ForestPath1Load", 2);
			levelManager.GetComponent<LevelManager>().CheckLevel(forestPath1);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == forestPath2)
		{
			levelManager.GetComponent<LevelManager>().ForestPath2Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(forestPath2);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == forestPath3)
		{
			levelManager.GetComponent<LevelManager>().ForestPath3Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(forestPath3);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == home)
		{
			levelManager.GetComponent<LevelManager>().HomeLoad();
			levelManager.GetComponent<LevelManager>().CheckLevel(home);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone1)
		{
			levelManager.GetComponent<LevelManager>().Zone1Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone1);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone2)
		{
			levelManager.GetComponent<LevelManager>().Zone2Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone2);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone3)
		{
			levelManager.GetComponent<LevelManager>().Zone3Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone3);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone4)
		{
			levelManager.GetComponent<LevelManager>().Zone4Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone4);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone5)
		{
			levelManager.GetComponent<LevelManager>().Zone5Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone5);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone6)
		{
			levelManager.GetComponent<LevelManager>().Zone6Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone6);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone7)
		{
			levelManager.GetComponent<LevelManager>().Zone7Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone7);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone8)
		{
			levelManager.GetComponent<LevelManager>().Zone8Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone8);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone9)
		{
			levelManager.GetComponent<LevelManager>().Zone9Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone9);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone10)
		{
			levelManager.GetComponent<LevelManager>().Zone10Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone10);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == zone11)
		{
			levelManager.GetComponent<LevelManager>().Zone11Load();
			levelManager.GetComponent<LevelManager>().CheckLevel(zone11);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}
		
		if (zoneToLoad == limboZone)
		{
			levelManager.GetComponent<LevelManager>().LimboZoneLoad();
			levelManager.GetComponent<LevelManager>().CheckLevel(limboZone);
			Debug.Log("Tried to load level"+zoneToLoad);
			fadeOutTweener.enabled = true;
			fadeInTweener.enabled = false;
		}

	}
}
