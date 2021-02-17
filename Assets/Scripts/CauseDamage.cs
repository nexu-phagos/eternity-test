using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CauseDamage : MonoBehaviour
{
	public int damageValue;
	// public GameObject gameObject;
	Animator anim;
	
	private GameObject persistentSFXGameObject;
	private PersistentSFX persistentSFX;
	
	private float knockedBackTime;
	
    // Start is called before the first frame update
    void Start()
    {
		persistentSFXGameObject = GameObject.Find("PersistentSFX");
		persistentSFX = persistentSFXGameObject.GetComponent<PersistentSFX>();
		
		anim = GetComponentInParent<Animator>(); // this might need to be getcomponentinchildren
		// DOTween.Init(autoKillMode, useSafeMode, logBehaviour);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter(Collider other)
	{				
		if(anim.GetBool ("isAttacking") == true)
		{
			if(other.gameObject.tag == "Container")
				{
					other.gameObject.GetComponent<HealthSystem>().Damage(damageValue);
					Debug.Log("Player hit a container");
				}
		
			if(other.gameObject.tag == "Enemy")
				{
					other.gameObject.GetComponent<HealthSystem>().Damage(damageValue);
					Debug.Log("Player hit an enemy");
					persistentSFX.PlayParasiteDamagedSFX();
				}
				
			if(other.gameObject.tag == "Critter")
				{
					other.gameObject.GetComponent<HealthSystem>().Damage(damageValue);
					Debug.Log("Player hit an critter");
					persistentSFX.PlaySheepDamagedSFX();
				}
				
			if(other.gameObject.tag == "Foliage")
				{
					other.gameObject.GetComponent<HealthSystem>().Damage(damageValue);
					Debug.Log("Player hit foliage");
					persistentSFX.PlayRootSmashSFX();
				}
				
			if(other.gameObject.tag == "FrogBoss")
				{
					other.gameObject.GetComponent<HealthSystem>().Damage(damageValue);
					Debug.Log("Player hit frog boss");
					persistentSFX.PlayParasiteDamagedSFX();
				}
			
			if(other.gameObject.tag == "ChaosVillager")
				{
					other.gameObject.GetComponent<HealthSystem>().Damage(damageValue);
					Debug.Log("Player hit chaos villager");
					persistentSFX.PlayParasiteDamagedSFX();
				}
			
			
		}
	}
}
