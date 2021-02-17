using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimationStateController : MonoBehaviour
{
	bool _isJumping;
	bool _isRunning;
	bool _isTurningLeft;
	bool _isTurningRight;
	
	int attackLevel = 0;
	
	bool _isAttacking;
	bool _isAttacking2;
	bool _isAttacking3;
	
	public float attackTime;
	public float attack2Time;
	public float attack3Time;
	
	Animator anim;
	
	public float acceleration = 0.1f;
	public float deceleration = 0.5f;
	
	public bool isJumping;
	
	int VelocityHash;
	float velocity = 0.0f;
	
	// int isRunning = Animator.StringToHash("isRunning");
	// int isJumping = Animator.StringToHash("isJumping");
	
    void Start()
    {
		//This gets the Animator, which should be attached to the GameObject you are intending to animate.
        anim = gameObject.GetComponentInChildren<Animator>();
		if(anim == null)
        {
            Debug.Log("Error: Did not find anim!");
        } else
        {
            //Debug.Log("Got anim");
        }
		
       	// The GameObject cannot jump
        _isJumping = false;
		
		VelocityHash = Animator.StringToHash("velocity");

		_isAttacking = false;
		_isAttacking2 = false;
		_isAttacking3 = false;
 
		UpdateAnimClipTimes();
    }
	
	public void RefreshAnimatorController()
	{
		// call this whenever a gameObject with an Animator Controller is enabled / disabled, otherwise this script will reference the wrong anim
		anim = gameObject.GetComponentInChildren<Animator>();
	}

    void Update()
    {
		//Debug.Log(_isAttacking);
		//Debug.Log("start update loop");
		// //////////////////////////
		// JUMPING
		// //////////////////////////
		
		//Press Jump button triggers jump animation
        if (Input.GetButtonDown("Jump"))
		{
			_isJumping = true;
		}
        //Otherwise the GameObject cannot jump.
        else 
		{
			_isJumping = false;
		}

        //If the GameObject is not jumping, send that the Boolean “isJumping” is false to the Animator. 
		// The jump animation does not play.
        if (_isJumping == false)
		{
			anim.SetBool("isJumping", false);
		}

        //The GameObject is jumping, so send the Boolean as enabled to the Animator. The jump animation plays.
        if (_isJumping == true)
		{
			anim.SetBool("isJumping", true);
		}
		
		// //////////////////////////
		// RUNNING
		// //////////////////////////
		
		//Press Run button triggers jump animation
        if (Input.GetButton("Forward"))
		{
			_isRunning = true;
		}
        //Otherwise the GameObject cannot run.
        else 
		{
			_isRunning = false;
		}

        //If the GameObject is not running, send that the Boolean “isRunning” is false to the Animator. 
		// The run animation does not play.
        if (_isRunning == false)
		{
			anim.SetBool("isRunning", false);
		}

        //The GameObject is jumping, so send the Boolean as enabled to the Animator. The jump animation plays.
        if (_isRunning == true)
		{
			anim.SetBool("isRunning", true);
		}
		
		// //////////////////////////
		// TURNING
		// //////////////////////////
		
		//LEFT
        if (Input.GetButton("TurnLeft"))
		{
			_isTurningLeft = true;
		}
        else 
		{
			_isTurningLeft = false;
		}

        if (_isTurningLeft == false)
		{
			anim.SetBool("isTurningLeft", false);
		}

        if (_isTurningLeft == true)
		{
			anim.SetBool("isTurningLeft", true);
		}
		
		//RIGHT
        if (Input.GetButton("TurnRight"))
		{
			_isTurningRight = true;
		}
        else 
		{
			_isTurningRight = false;
		}

        if (_isTurningRight == false)
		{
			anim.SetBool("isTurningRight", false);
		}

        if (_isTurningRight == true)
		{
			anim.SetBool("isTurningRight", true);
		}
		
		// //////////////////////////
		// ATTACK COMBOS
		// //////////////////////////

		if (Input.GetButtonDown("Attack1"))
		{
			_isAttacking = true;
			Invoke("StopAttack", attack3Time/2);
		}
		
		if (_isAttacking == true)
		{
			anim.SetBool("isAttacking", true);
		}
		
		if (_isAttacking == false)
		{
			anim.SetBool("isAttacking", false);
		}

		// //////////////////////////
		// velocity stuff for jumping
		// //////////////////////////
		if (_isJumping == true && velocity < 1.0f)
		{
			velocity += Time.deltaTime * acceleration;
		}
		
		if (_isJumping == false && velocity > 0.0f)
		{
			anim.SetBool("isJumping", false);
			velocity -= Time.deltaTime * deceleration;
		}
		
		if (!_isJumping && velocity <0.0f)
		{
			velocity = 0.0f;
		}
        
		anim.SetFloat(VelocityHash, velocity);
		
		//Debug.Log("end update loop");
    }
	
	// function to delay the animation off switch
	public void StopAttack()
	{
		_isAttacking = false;
	}
	
	public void StopAttack2()
	{
		_isAttacking2 = false;
		attackLevel=0;
	}
	
	public void StopAttack3()
	{
		_isAttacking3 = false;
		attackLevel=0;
	}
	
	public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch(clip.name)
            {
                case "Armature-changeling|changeling-staff-attack":
                    attackTime = clip.length;
                    break;
                case "Armature-changeling|changeling-staff-attack-2":
                    attack2Time = clip.length;
                    break;
                case "Armature-changeling|changeling-staff-attack-3":
                    attack3Time = clip.length;
                    break;
            }
        }
	}
}
