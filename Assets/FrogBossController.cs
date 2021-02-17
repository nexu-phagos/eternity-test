using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBossController : MonoBehaviour
{
	bool facingSOUTH;
	bool facingEAST;
	bool facingNORTH;
	bool facingWEST;
	
	bool _jumpNORTH;
	bool _jumpEAST;
	bool _jumpSOUTH;
	bool _jumpWEST;
	
	bool _tongueNORTH;
	bool _tongueEAST;
	bool _tongueSOUTH;
	bool _tongueWEST;
	
	bool _projectileNORTH;
	bool _projectileEAST;
	bool _projectileSOUTH;
	bool _projectileWEST;
	
	bool _flippedNORTH;
	bool _flippedEAST;
	bool _flippedSOUTH;
	bool _flippedWEST;
	
	bool _turningToNORTH;
	bool _turningToEAST;
	bool _turningToSOUTH;
	bool _turningToWEST;
	
	Animator anim;
	
	public float turningTime;
	public float idleTime;
	public float spawnTime;
	public float projectileTime;
	public float jumpTime;
	public float tongueTime;
	
	public float aBitLongerThanLongestAction;
	
	int frogCount;
	public float transitionTime;
	
    void Start()
    {
		frogCount = -1;
		facingSOUTH = true;
		facingNORTH = false;
		facingWEST = false;
		facingEAST = false;
		
		anim = gameObject.GetComponent<Animator>();
		if(anim == null)
        {
            Debug.Log("Error: Did not find anim!");
        } else
        {
            //Debug.Log("Got anim");
        }
		
		UpdateAnimClipTimes();
			
		//Debug.Log("Spawn Time ="+spawnTime);
		//Debug.Log("Idle Time ="+idleTime);
		//Debug.Log("Proj Time ="+projectileTime);
		
		InvokeRepeating("FrogCounter", spawnTime, (idleTime + projectileTime));
		InvokeRepeating("ActionRoulette", spawnTime, (idleTime + projectileTime));
    }
	
	void FrogCounter()
	{
		frogCount = frogCount+1;
		
		if (frogCount > 3)
		{
			frogCount = 0;
		}
		
		//Debug.Log("frogCount ="+frogCount);
	}

    void ActionRoulette()
    {
		//Debug.Log("ActionRoulette popped");
		
		if (frogCount == 0)
		{
			if (facingSOUTH && !facingEAST && !facingNORTH && !facingWEST)
			{
				//Debug.Log("ActionRoulette says 'facing South'");
				SouthActionRoulette();
				Invoke("MoveSouthToEast", transitionTime);
				facingSOUTH = false;
				//MoveSouthToEast();
			}
		}
		
		if (frogCount == 1)
		{
			if (facingEAST && !facingNORTH && !facingWEST && !facingSOUTH)
			{
				//Debug.Log("ActionRoulette says 'facing East'");
				EastActionRoulette();
				Invoke("MoveEastToNorth", transitionTime);
				facingEAST = false;
				//MoveEastToNorth();
			}
		}
		
		if (frogCount == 2)
		{
			if (facingNORTH && !facingWEST && !facingSOUTH && !facingEAST)
			{
				//Debug.Log("ActionRoulette says 'facing North'");
				NorthActionRoulette();
				Invoke("MoveNorthToWest", transitionTime);
				facingNORTH = false;
				//MoveNorthToWest();
			}
		}
		
		if (frogCount == 3)
		{
			if (facingWEST && !facingSOUTH && !facingEAST && !facingNORTH)
			{
				//Debug.Log("ActionRoulette says 'facing West'");
				WestActionRoulette();
				Invoke("MoveWestToSouth", transitionTime);
				facingWEST = false;
				//MoveWestToSouth();
			}
		}
        
    }
	
	public void MoveSouthToEast()
	{
		//Debug.Log("moving East via MoveSouthToEast");
		facingEAST = true;
		anim.SetBool("turningToEAST", true);
		//Invoke("ResetRoulette", projectileTime);
		//ResetRoulette();
	}
	
	public void MoveEastToNorth()
	{
		//Debug.Log("moving North via MoveEastToNorth");
		facingNORTH = true;
		anim.SetBool("turningToNORTH", true);
		//Invoke("ResetRoulette", projectileTime);
		//ResetRoulette();
	}
	
	public void MoveNorthToWest()
	{
		//Debug.Log("moving West via MoveNorthToWest");
		facingWEST = true;
		anim.SetBool("turningToWEST", true);
		//Invoke("ResetRoulette", projectileTime);
		//ResetRoulette();
	}
	
	public void MoveWestToSouth()
	{
		//Debug.Log("moving South via MoveWestToSouth");
		facingSOUTH = true;
		anim.SetBool("turningToSOUTH", true);
		//Invoke("ResetRoulette", projectileTime);
		//ResetRoulette();
	}
	
	public void SouthActionRoulette()
	{
		//Debug.Log("tried to do a South action");
		int southAction = Random.Range(0,2);
		
		if (southAction == 0)
		{
			anim.SetBool("jumpSOUTH", true);
			transitionTime = jumpTime;
		}
		
		if (southAction == 1)
		{
			anim.SetBool("tongueSOUTH", true);
			transitionTime = tongueTime;
		}
		
		if (southAction == 2)
		{
			anim.SetBool("projectileSOUTH", true);
			transitionTime = projectileTime;
		}
		
		Invoke("ResetRoulette", transitionTime);
	}
	
	public void EastActionRoulette()
	{
		//Debug.Log("tried to do a East action");
		int eastAction = Random.Range(0,2);
		
		if (eastAction == 0)
		{
			anim.SetBool("jumpEAST", true);
			transitionTime = jumpTime;
		}
		
		if (eastAction == 1)
		{
			anim.SetBool("tongueEAST", true);
			transitionTime = tongueTime;
		}
		
		if (eastAction == 2)
		{
			anim.SetBool("projectileEAST", true);
			transitionTime = projectileTime;
		}
		
		Invoke("ResetRoulette", transitionTime);
	}
	
	public void NorthActionRoulette()
	{
		//Debug.Log("tried to do a North action");
		int northAction = Random.Range(0,2);
		
		if (northAction == 0)
		{
			anim.SetBool("jumpNORTH", true);
			transitionTime = jumpTime;
		}
		
		if (northAction == 1)
		{
			anim.SetBool("tongueNORTH", true);
			transitionTime = tongueTime;
		}
		
		if (northAction == 2)
		{
			anim.SetBool("projectileNORTH", true);
			transitionTime = projectileTime;
		}
		
		Invoke("ResetRoulette", transitionTime);
	}
	
	public void WestActionRoulette()
	{
		//Debug.Log("tried to do a West action");
		int westAction = Random.Range(0,2);
		
		if (westAction == 0)
		{
			anim.SetBool("jumpWEST", true);
			transitionTime = jumpTime;
		}
		
		if (westAction == 1)
		{
			anim.SetBool("tongueWEST", true);
			transitionTime = tongueTime;
		}
		
		if (westAction == 2)
		{
			anim.SetBool("projectileWEST", true);
			transitionTime = projectileTime;
		}
		
		Invoke("ResetRoulette", transitionTime);
	}
	
	void ResetRoulette()
	{
		anim.SetBool("jumpSOUTH", false);
		anim.SetBool("jumpNORTH", false);
		anim.SetBool("jumpWEST", false);
		anim.SetBool("jumpEAST", false);
		
		anim.SetBool("tongueSOUTH", false);
		anim.SetBool("tongueNORTH", false);
		anim.SetBool("tongueWEST", false);
		anim.SetBool("tongueEAST", false);
		
		anim.SetBool("projectileSOUTH", false);
		anim.SetBool("projectileNORTH", false);
		anim.SetBool("projectileWEST", false);
		anim.SetBool("projectileEAST", false);
		
		anim.SetBool("flippedSOUTH", false);
		anim.SetBool("flippedNORTH", false);
		anim.SetBool("flippedWEST", false);
		anim.SetBool("flippedEAST", false);
		
		anim.SetBool("turningToSOUTH", false);
		anim.SetBool("turningToNORTH", false);
		anim.SetBool("turningToWEST", false);
		anim.SetBool("turningToEAST", false);
	}
	
	void SouthFlipped()
	{
		anim.SetBool("flippedSOUTH", true);
	}
	
	void EastFlipped()
	{
		anim.SetBool("flippedEAST", true);
	}
	
	void NorthFlipped()
	{
		anim.SetBool("flippedNORTH", true);
	}
	
	void WestFlipped()
	{
		anim.SetBool("flippedWEST", true);
	}
	
	public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch(clip.name)
            {
                case "chaosFROGarmature|chaosFROG-north-to-west":
                    turningTime = clip.length;
                    break;
                case "chaosFROGarmature|chaosFROG-south-IDLE":
                    idleTime = clip.length;
                    break;
				case "chaosFROGarmature|chaosFROG-west-PROJECTILE":
                    projectileTime = clip.length;
                    break;	
				case "chaosFROGarmature|chaosFROG--spawn":
                    spawnTime = clip.length;
                    break;	
				case "chaosFROGarmature|chaosFROG-west-JUMP":
                    jumpTime = clip.length;
                    break;	
				case "chaosFROGarmature|chaosFROG-south-TONGUE":
                    tongueTime = clip.length;
                    break;	
            }
        }
	}
}
