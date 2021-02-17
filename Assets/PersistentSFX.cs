using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSFX : MonoBehaviour
{
	[SerializeField] private AudioClip menuOpenSFX;
	[SerializeField] private AudioClip menuCloseSFX;
	[SerializeField] private AudioClip menuNavSFX;
	[SerializeField] private AudioClip menuAcceptSFX;
	
	private int randomContainerSmash;
	[SerializeField] private AudioClip container1Smash1SFX;
	[SerializeField] private AudioClip container1Smash2SFX;
	[SerializeField] private AudioClip container1Smash3SFX;
	[SerializeField] private AudioClip container1Smash4SFX;
	
	[SerializeField] private AudioClip forestPortalSFX;
	[SerializeField] private AudioClip portalSFX;
	
	private int randomMarble;
	[SerializeField] private AudioClip marble1PickUpSFX;
	[SerializeField] private AudioClip marble2PickUpSFX;
	[SerializeField] private AudioClip marble3PickUpSFX;
	[SerializeField] private AudioClip marble4PickUpSFX;
	
	[SerializeField] private AudioClip essencePickUpSFX;
	[SerializeField] private AudioClip jingleBellPickUpSFX;
	[SerializeField] private AudioClip brambleStonePickUpSFX;
	
	private int randomAttack;
	[SerializeField] private AudioClip playerAttack1SFX;
	[SerializeField] private AudioClip playerAttack2SFX;
	
	private int randomDamage;
	[SerializeField] private AudioClip playerDamaged1SFX;
	[SerializeField] private AudioClip playerDamaged2SFX;
	
	[SerializeField] private AudioClip playerDeathSFX;
	
	[SerializeField] private AudioClip sheepDamagedSFX;
	[SerializeField] private AudioClip critterDeathSFX;
	
	[SerializeField] private AudioClip parasiteAttackSFX;
	[SerializeField] private AudioClip parasiteDeathSFX;
	[SerializeField] private AudioClip parasiteFeedingSFX;
	[SerializeField] private AudioClip parasiteDamagedSFX;
	
	private int randomRootSmash;
	[SerializeField] private AudioClip rootSmash1SFX;
	[SerializeField] private AudioClip rootSmash2SFX;
	[SerializeField] private AudioClip rootSmash3SFX;
	
	[SerializeField] private AudioClip chaosVillagerDeathSFX;
	[SerializeField] private AudioClip chaosVillagerDamagedSFX;
	
	private void Start()
	{
		// AudioManager.Instance.PlayMusicWithFade(marblePickUpSFX);
	}
	
	public void PlayChaosVillagerDamagedSFX()
	{
		AudioManager.Instance.PlaySFX(chaosVillagerDamagedSFX);
	}
	
	public void PlayChaosVillagerDeathSFX()
	{
		AudioManager.Instance.PlaySFX(chaosVillagerDeathSFX);
	}
	
	public void PlayMarbleSFX()
	{
		randomMarble = Random.Range(1,4);
		
		if (randomMarble == 1)
		{
			AudioManager.Instance.PlaySFX(marble1PickUpSFX);
		}
		
		if (randomMarble == 2)
		{
			AudioManager.Instance.PlaySFX(marble2PickUpSFX);
		}
		
		if (randomMarble == 3)
		{
			AudioManager.Instance.PlaySFX(marble3PickUpSFX);
		}
		
		if (randomMarble == 4)
		{
			AudioManager.Instance.PlaySFX(marble4PickUpSFX);
		}
	}
	
	public void PlayContainer1SmashSFX()
	{
		randomContainerSmash = Random.Range(1,4);
		
		if (randomContainerSmash == 1)
		{
			AudioManager.Instance.PlaySFX(container1Smash1SFX);
		}
		
		if (randomContainerSmash == 2)
		{
			AudioManager.Instance.PlaySFX(container1Smash2SFX);
		}
		
		if (randomContainerSmash == 3)
		{
			AudioManager.Instance.PlaySFX(container1Smash3SFX);
		}
		
		if (randomContainerSmash == 4)
		{
			AudioManager.Instance.PlaySFX(container1Smash4SFX);
		}
	}
	
	public void PlayEssenceSFX()
	{
		AudioManager.Instance.PlaySFX(essencePickUpSFX);
	}
	
	public void PlayJingleBellSFX()
	{
		AudioManager.Instance.PlaySFX(jingleBellPickUpSFX);
	}
	
	public void PlayBrambleStoneSFX()
	{
		AudioManager.Instance.PlaySFX(brambleStonePickUpSFX);
	}
	
	public void PlayPlayerAttackSFX()
	{
		randomAttack = Random.Range(1,2);
		
		if (randomAttack == 1)
		{
			AudioManager.Instance.PlaySFX(playerAttack1SFX);
		}
		
		if (randomAttack == 2)
		{
			AudioManager.Instance.PlaySFX(playerAttack2SFX);
		}
		
	}
	
	public void PlayPlayerDamagedSFX()
	{
		randomDamage = Random.Range(1,2);
		
		if (randomDamage == 1)
		{
			AudioManager.Instance.PlaySFX(playerDamaged1SFX);
		}
		
		if (randomDamage == 2)
		{
			AudioManager.Instance.PlaySFX(playerDamaged2SFX);
		}
		
	}
	
	public void PlayPlayerDeathSFX()
	{
		AudioManager.Instance.PlaySFX(playerDeathSFX);
	}
	
	public void PlaySheepDamagedSFX()
	{
		AudioManager.Instance.PlaySFX(sheepDamagedSFX);
	}
	
	public void PlayCritterDeathSFX()
	{
		AudioManager.Instance.PlaySFX(critterDeathSFX);
	}
	
	public void PlayParasiteAttackSFX()
	{
		AudioManager.Instance.PlaySFX(parasiteAttackSFX);
	}
	
	public void PlayParasiteDeathSFX()
	{
		AudioManager.Instance.PlaySFX(parasiteDeathSFX);
	}
	
	public void PlayParasiteFeedingSFX()
	{
		AudioManager.Instance.PlaySFX(parasiteFeedingSFX);
	}
	
	public void PlayParasiteDamagedSFX()
	{
		AudioManager.Instance.PlaySFX(parasiteDamagedSFX);
	}
	
	public void PlayForestPortalSFX()
	{
		AudioManager.Instance.PlaySFX(forestPortalSFX);
	}
	
	public void PlayPortalSFX()
	{
		AudioManager.Instance.PlaySFX(portalSFX);
	}
	
	public void PlayMenuOpenSFX()
	{
		AudioManager.Instance.PlaySFX(menuOpenSFX);
	}
	
	public void PlayMenuCloseSFX()
	{
		AudioManager.Instance.PlaySFX(menuCloseSFX);
	}
	
	public void PlayMenuAcceptSFX()
	{
		AudioManager.Instance.PlaySFX(menuAcceptSFX);
	}
	
	public void PlayMenuNavSFX()
	{
		AudioManager.Instance.PlaySFX(menuNavSFX);
	}
	
	public void PlayRootSmashSFX()
	{
		randomRootSmash = Random.Range(1,3);
		
		if (randomRootSmash == 1)
		{
			AudioManager.Instance.PlaySFX(rootSmash1SFX);
		}
		
		if (randomRootSmash == 2)
		{
			AudioManager.Instance.PlaySFX(rootSmash2SFX);
		}
		
		if (randomRootSmash == 3)
		{
			AudioManager.Instance.PlaySFX(rootSmash3SFX);
		}
	}
}
