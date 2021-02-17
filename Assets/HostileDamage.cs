using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileDamage : MonoBehaviour
{
	[SerializeField]
	private int damageValue;
	
	private GameObject persistentSFXGameObject;
	private PersistentSFX persistentSFX;
	
	Animator hostileAnim;
	Animator playerAnim;
	
	private float knockedBackTime;
	
    void Start()
    {
		persistentSFXGameObject = GameObject.Find("PersistentSFX");
		persistentSFX = persistentSFXGameObject.GetComponent<PersistentSFX>();
		
        if (this.tag == "FrogBoss")
		{
			damageValue = 40;
		}
		else
		{
			damageValue = 10;
		}
    }

    void Update()
    {
        
    }
	
	public void DisableDamage()
	{
		damageValue = 0;
	}
	
	void ResetPlayerDamagedBool()
	{
		playerAnim.SetBool("isDamaged", false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Player was damaged by FrogBoss");
			other.gameObject.GetComponent<HealthSystem>().Damage(damageValue);
			persistentSFX.PlayPlayerDamagedSFX();
			playerAnim = other.GetComponentInChildren<Animator>();
			playerAnim.SetBool("isDamaged", true);
			Invoke("ResetPlayerDamagedBool", 1);
		}
	}
}
