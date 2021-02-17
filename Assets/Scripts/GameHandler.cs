using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameHandler : MonoBehaviour
{
	private GameObject pauseTweens;
	private GameObject hudTweens;
	
	private DOTweenVisualManager pauseTweenManager;
	private DOTweenVisualManager hudTweenManager;
	
	public bool pauseMenuOn;
	public bool hudOn;
	
	private GameObject persistentSFXGameObject;
	private PersistentSFX persistentSFX;
	
	public bool frogBossDead;
	private GameObject chaosFrogBoss;
	private GameObject friendlyFrog;
	
    public void Start()
    {
		frogBossDead = false;
		persistentSFXGameObject = GameObject.Find("PersistentSFX");
		persistentSFX = persistentSFXGameObject.GetComponent<PersistentSFX>();
		
		pauseMenuOn = false;
		hudOn = false;
		
		pauseTweens = GameObject.Find("PauseMoveIn");
		hudTweens = GameObject.Find("HUDMoveIn");
		
		pauseTweenManager = pauseTweens.GetComponent<DOTweenVisualManager>();
		hudTweenManager = hudTweens.GetComponent<DOTweenVisualManager>();

    }
	
	void Awake()
	{
		// Debug.Log("GameHandler awake");
		Debug.Log("FrogBossDead = "+frogBossDead);
		KillAndReincarnate();
	}
	
	void Update () 
   {
     if(Input.GetKeyDown("escape")) 
	 {
		 MenuOpenStuff();
		 MenuCloseStuff();
		 pauseTweenManager.enabled = !pauseTweenManager.enabled;
		 hudTweenManager.enabled = !hudTweenManager.enabled;
		 pauseMenuOn = !pauseMenuOn;
     }
   }
   
   public void FrogBossDeathTrigger()
   {
	   Debug.Log("frog boss dead set to true in Game Handler");
	   frogBossDead = true;
   }
   
   public void KillAndReincarnate()
   {
	   Debug.Log("KillAndReincarnate popped");
	   Debug.Log("FrogBossDead = "+frogBossDead);
	    if (frogBossDead)
	   {
		   chaosFrogBoss = GameObject.Find("chaosFrog");
		   chaosFrogBoss.SetActive(false);
		   
		   friendlyFrog = GameObject.Find("frog-friendly");
		   friendlyFrog.SetActive(true);
	   }
   }
   
   void MenuOpenStuff()
   {
	   persistentSFX.PlayMenuOpenSFX();
   }
   
   void MenuCloseStuff()
   {
	   persistentSFX.PlayMenuCloseSFX();
   }
}
