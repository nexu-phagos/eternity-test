using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public float speed;
	private Transform target;
	private Vector3 stayThisFarAway;
	private bool withinAttackRange;
	
	private Animator anim;
	
    void Start()
    {
        speed = 5;
		stayThisFarAway = new Vector3(1.5f, 0, 1.5f);
		withinAttackRange = false;
		
		anim = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
		/*
		GameObject player = GameObject.FindWithTag("Player");
		target = player.transform;
		
		// Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		*/
        
    }
	
	public void TriggerAttackAnimation(bool _isAttacking)
	{
		anim.SetBool("isAttacking", _isAttacking);
		Invoke("ResetAnimations", 1);
	}
	
	void ResetAnimations()
	{
		anim.SetBool("isAttacking", false);
	}
	
	public void StartFollowing(bool _following)
	{
		if (_following)
		{
			GameObject player = GameObject.FindWithTag("Player");
			target = player.transform;
			
			// Move our position a step closer to the target.
			float step =  speed * Time.deltaTime; // calculate distance to move
			transform.position = Vector3.MoveTowards(transform.position, (target.position-stayThisFarAway), step);
			
			// if ((target.position-stayThisFarAway).sqrMagnitude<3*3)
			// if (transform.position == target.position-stayThisFarAway)
			// if ((player.transform.position-this.transform.position).sqrMagnitude<3*3)
			
			if ((this.transform.position-target.position).sqrMagnitude<3*3)
			{
				withinAttackRange = true;
				TriggerAttackAnimation(withinAttackRange);
			}
		}
		else
		{
			withinAttackRange = false;
			TriggerAttackAnimation(withinAttackRange);
			return;
		}
		
	}
}
