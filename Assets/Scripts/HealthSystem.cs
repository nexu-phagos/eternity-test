using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthSystem : MonoBehaviour
{
	private int health;
	private int healthMax;
	
	private int playerHealth;
	private int enemyHealth;
	private int containerHealth;
	private int critterHealth;
	private int foliageHealth;
	private int frogBossHealth;
	private int chaosVillagerHealth;
	
	private Vector3 deathpos;
	private Quaternion deathRot;
	
	private GameObject prefabToSpawn;
	private GameObject container1ShatteredPrefab;
	
	public GameObject pickupPrefab;
	public int numberOfPickupsToDrop;
	public GameObject entityDestroyedPrefab;
	
	private GameObject persistentSFXGameObject;
	private PersistentSFX persistentSFX;
	
	private GameObject _gameHandler;
	private GameHandler gameHandler;
	
	private GameObject _portalState;
	private PortalState portalState;
	
	GameObject animContainer;
	Animator anim;
	DOTweenVisualManager visualManager;
	
	private GameObject levelManager;
	
	private GameObject fadeInTweenContainer;
	private DOTweenVisualManager fadeInTweener;
	
	private GameObject fadeOutTweenContainer;
	private DOTweenVisualManager fadeOutTweener;
	
	private Vector3 respawnPos;
	
	private HostileDamage[] hostileDamageComponents;
	
	private HostileBrain hostileBrain;
	
	public HealthSystem(int health)
	{
		this.health = health;
		//health = healthMax;
	}
	
	public void Start()
    {
		_gameHandler = GameObject.FindWithTag("GameHandler");
		gameHandler = _gameHandler.GetComponent<GameHandler>();
		
		_portalState = GameObject.FindWithTag("PortalHandler");
		portalState = _portalState.GetComponent<PortalState>();
		
		persistentSFXGameObject = GameObject.Find("PersistentSFX");
		persistentSFX = persistentSFXGameObject.GetComponent<PersistentSFX>();
		
		DOTween.Init();
		
		levelManager = GameObject.Find("LevelManager");
		
		fadeInTweenContainer = GameObject.FindWithTag("FadeInTweener");
		fadeInTweener = fadeInTweenContainer.GetComponent<DOTweenVisualManager>();
		
		fadeOutTweenContainer = GameObject.FindWithTag("FadeOutTweener");
		fadeOutTweener = fadeOutTweenContainer.GetComponent<DOTweenVisualManager>();
		
		hostileBrain = this.GetComponentInChildren<HostileBrain>();
		
		//healthMax = 100;
		
		containerHealth = 20;
		enemyHealth = 50;
		playerHealth = 100;
		critterHealth = 10;
		foliageHealth = 15;
		frogBossHealth = 100;
		chaosVillagerHealth = 30;
		
		respawnPos = new Vector3(0,0,0);
		
		if (this.tag == "Player")
		{
			health = playerHealth;
			
			//anim = gameObject.GetComponent<Animator>();
			anim = gameObject.GetComponentInChildren<Animator>();
			if(anim == null)
			{
				//anim = gameObject.GetComponentInChildren<Animator>();
				Debug.Log("Error: Did not find anim!");
			} else
			{
				//Debug.Log("Got anim");
			}
		}
		
		if (this.tag == "Foliage")
		{
			health = foliageHealth;
		}
		
		if (this.tag == "Enemy")
		{
			health = enemyHealth;
			
			anim = gameObject.GetComponent<Animator>();
			if(anim == null)
			{
				Debug.Log("Error: Did not find anim!");
			} else
			{
				//Debug.Log("Got anim");
			}
		}
		
		if (this.tag == "Container")
		{
			health = containerHealth;
		}
		
		if (this.tag == "Critter")
		{
			health = critterHealth;
			
			anim = gameObject.GetComponent<Animator>();
			if(anim == null)
			{
				Debug.Log("Error: Did not find anim!");
			} else
			{
				//Debug.Log("Got anim");
			}
		}
		
		if (this.tag == "FrogBoss")
		{
			health = frogBossHealth;
			
			animContainer = GameObject.Find("chaosFrog");
			anim = animContainer.GetComponent<Animator>();
			
			if(anim == null)
			{
				Debug.Log("Error: Did not find anim!");
			} else
			{
				//Debug.Log("Got anim");
			}
		}
		
		if (this.tag == "ChaosVillager")
		{
			health = chaosVillagerHealth;
			
			anim = this.GetComponentInChildren<Animator>();
			
			if(anim == null)
			{
				Debug.Log("Error: Did not find anim!");
			} else
			{
				//Debug.Log("Got anim");
			}
		}
    }
	
	void Update()
	{
		if(health<=0)
		{
			if(this.tag=="Player")
			{
				PlayerDied();
				health = playerHealth;
			}
			
			if(this.tag=="Enemy")
			{
				EnemyDied();
			}
			
			if(this.tag=="Critter")
			{
				anim.SetBool("isDead", true);
				Invoke("CritterDied", 3);
			}
			
			if(this.tag=="Container")
			{
				ContainerDestroyed();
			}
			
			if(this.tag=="Foliage")
			{
				FoliageDestroyed();
			}
			
			if(this.tag=="FrogBoss")
			{
				FrogBossDestroyed();
			}
			
			if(this.tag=="ChaosVillager")
			{
				ChaosVillagerDestroyed();
			}
		}
	}
	
	public void Damage(int damageAmount)
	{
		health-=damageAmount;
		if (health<0) health = 0;
	}
	
	public void Heal(int healAmount)
	{
		health+=healAmount;
		if (health>healthMax) health = healthMax;
	}
	
	public void PlayerDied()
	{
		Debug.Log("Player Died");
		//gameObject.SetActive(false);
		anim.SetBool("isDead", true);
		
		Debug.Log("Tried to reload this level");
		fadeOutTweener.enabled = true;
		fadeInTweener.enabled = false;
		Invoke("ReloadLevelProxy", 2);
	}
	
	void ReloadLevelProxy()
	{
		// upon further inspection, it seems this is not necessary. I think the problem is with the async loading. i'll leave this here for now anywya just in case
		levelManager.GetComponent<LevelManager>().ThisLevelReload();
		anim.SetBool("isDead", false);
		anim.SetBool("isDamaged", false);
		this.transform.position = respawnPos;
	}
	
	public void FrogBossDestroyed()
	{
		Debug.Log("Frog Boss Died");
		
		anim.SetBool("isDead", true);
		
		Vector3 deathPos = this.gameObject.transform.position;
		Quaternion deathRot = this.gameObject.transform.rotation;
		
		for (int i = 0; i < numberOfPickupsToDrop; i++)
        {
			GameObject prefabToSpawn = Instantiate(pickupPrefab, deathPos, deathRot);
		}
		
		persistentSFX.PlayParasiteDeathSFX();
		
		gameHandler.FrogBossDeathTrigger();
		portalState.EnablePortalToHomePortals();
		
		Invoke("DestroyLater", 5);
	}
	
	void DestroyLater()
	{
		Debug.Log("tried to destroy frog boss");
		//animContainer.SetActive(false);
		Destroy(gameObject);
	}
	
	public void EnemyDied()
	{
		Debug.Log("Enemy Died");
		Destroy(gameObject);
		anim.SetBool("isDead", true);
		
		Vector3 deathPos = this.gameObject.transform.position;
		Quaternion deathRot = this.gameObject.transform.rotation;
		
		for (int i = 0; i < numberOfPickupsToDrop; i++)
        {
			GameObject prefabToSpawn = Instantiate(pickupPrefab, deathPos, deathRot);
		}
		
		persistentSFX.PlayParasiteDeathSFX();
	}
	
	public void CritterDied()
	{
		persistentSFX.PlayCritterDeathSFX();
		Debug.Log("Critter Died");
		Destroy(gameObject);
		anim.SetBool("isDead", true);
	}
	
	public void FoliageDestroyed()
	{
		Debug.Log("Foliage destroyed");
		persistentSFX.PlayRootSmashSFX();
		Destroy(gameObject);
	}
	
	public void ContainerDestroyed()
	{
		persistentSFX.PlayContainer1SmashSFX();
		Debug.Log("Container Destroyed");
		Destroy(gameObject);
		
		// theatreManager.PainSFX(); --- need to implement sounds later - look to how i did theatremanager in Organ of Eden
		
		Vector3 deathPos = this.gameObject.transform.position;
		Quaternion deathRot = this.gameObject.transform.rotation;
		
		GameObject container1ShatteredPrefab = Instantiate(entityDestroyedPrefab, deathPos, deathRot);
		
		for (int i = 0; i < numberOfPickupsToDrop; i++)
        {
			GameObject prefabToSpawn = Instantiate(pickupPrefab, deathPos, deathRot);
		}
	}
	
	public void ChaosVillagerDestroyed()
	{
		persistentSFX.PlayChaosVillagerDeathSFX();
		Debug.Log("Chaos Villager Died");
		//Destroy(gameObject);
		anim.SetBool("isDead", true);
		
		hostileBrain.SetHostileBrainDead();
				
		hostileDamageComponents = FindObjectsOfType<HostileDamage>();
		
		foreach(HostileDamage hostileDamage in hostileDamageComponents)
		{
			hostileDamage.enabled = false;
		}
	}
}
