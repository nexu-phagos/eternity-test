using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
	bool _isJumping;
	bool _isRunning;
	bool _isTurningLeft;
	bool _isTurningRight;
	
	int attackLevel = 0;
	
	bool _isAttacking1;
	bool _isAttacking2;
	bool _isAttacking3;
	
	public float attack1Time;
	public float attack2Time;
	public float attack3Time;
	
	public float attack1FixedTime = 0.8333334f;
	public float attack2FixedTime = 0.8333334f;
	public float attack3FixedTime = 1.666667f;
	
	Animator anim;
	public float acceleration = 0.1f;
	public float deceleration = 0.5f;
	
	int VelocityHash;
	float velocity = 0.0f;
	
	// int isRunning = Animator.StringToHash("isRunning");
	// int isJumping = Animator.StringToHash("isJumping");
	
    void Start()
    {
		//This gets the Animator, which should be attached to the GameObject you are intending to animate.
        anim = gameObject.GetComponent<Animator>();
       	// The GameObject cannot jump
        _isJumping = false;
		
		VelocityHash = Animator.StringToHash("velocity");
		
		// this is to get length of animation for proper attack stuff
		anim = GetComponent<Animator>();
        if(anim == null)
        {
            Debug.Log("Error: Did not find anim!");
        } else
        {
            //Debug.Log("Got anim");
        }
		
		_isAttacking1 = false;
		_isAttacking2 = false;
		_isAttacking3 = false;
 
		UpdateAnimClipTimes();
    }

    void Update()
    {
		Debug.Log(attackLevel);
		Debug.Log("start update loop");
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
		
		// attackLevel = 0;
		
		// three attacks - supposed to work as a combo.
		// attack1, attack2, attack3
		// i.e. can only trigger attack2 during attack1, can only trigger attack2 during attack3
		
		if (Input.GetButtonDown("Attack1"))
		{
				attackLevel += 1; //adds one to power level
				Debug.Log("attack button pressed");
				
				if (attackLevel == 1)
				{
					Invoke("StopAttack1", attack1Time);
					Debug.Log("attack = 1, let's Invoke a function ONCE");
				}
				
				if (attackLevel == 2)
				{
					Invoke("StopAttack2", attack2Time);
				}
				
				if (attackLevel == 3)
				{
					Invoke("StopAttack3", attack2Time);
				}
				
				/*
				Debug.Log(attack1Time); // 0.8333334
				Debug.Log(attack2Time); // 0.8333334
				Debug.Log(attack3Time); // 1.666667
				*/
		}
		
		//ATTACK 1
        if (attackLevel ==1)
		{	
			_isAttacking1 = true;
			Debug.Log("_isAttacking1 BOOL = TRUE, because attackLevel = 1");
		}
		
		if (_isAttacking1 == true)
		{
			anim.SetBool("isAttacking1", true);
			Debug.Log("isAttacking2 ACP = TRUE, because _isAttacking1 BOOL = TRUE");
			
			// Invoke("StopAttack1", attack1Time);
			Debug.Log("StopAttack1 INVOKED, because _isAttacking1 BOOL = TRUE");
		}
		
		if (_isAttacking1 == false)
		{
			anim.SetBool("isAttacking1", false);
			Debug.Log("isAttacking1 ACP = FALSE, because _isAttacking1 BOOL = FALSE");
		}
		
		if (_isAttacking1 == true && attackLevel != 1) // prevents multiple attack states being active at once
		{
			_isAttacking1 = false;
			Debug.Log("_isAttacking1 BOOL = FALSE, because attackLevel mismatch w/ isAttacking state (prevents simultaneous states)");
		}
		
		//ATTACK 2
		if (attackLevel ==2)
		{	
			_isAttacking2 = true;
			Debug.Log("_isAttacking2 BOOL = TRUE, because attackLevel = 2");
		}
		
		if (_isAttacking2 == true)
		{
			anim.SetBool("isAttacking2", true);
			Debug.Log("isAttacking2 ACP = TRUE, because _isAttacking2 BOOL = TRUE");
			
			// Invoke("StopAttack2", attack2Time);
			Debug.Log("StopAttack2 INVOKED, because _isAttacking2 BOOL = TRUE");
		}
		
		if (_isAttacking2 == false)
		{
			anim.SetBool("isAttacking2", false);
			Debug.Log("isAttacking2 ACP = FALSE, because _isAttacking2 BOOL = FALSE");
		}
		
		if (_isAttacking2 == true && attackLevel != 2) // prevents multiple attack states being active at once
		{
			_isAttacking2 = false;
            Debug.Log("_isAttacking1 BOOL = FALSE, because attackLevel mismatch w/ isAttacking state (prevents simultaneous states)");
		}
		
		//ATTACK3
		if (attackLevel ==3)
		{	
			_isAttacking3 = true;
			Debug.Log("_isAttacking3 BOOL = TRUE, because attackLevel = 3");
		}
		
		if (_isAttacking3 == true)
		{
			anim.SetBool("isAttacking3", true);
			Debug.Log("isAttacking3 ACP = TRUE, because _isAttacking3 BOOL = TRUE");

			// Invoke("StopAttack3", attack3Time);
			Debug.Log("StopAttack3 INVOKED, because _isAttacking3 BOOL = TRUE");
		}
		
		if (_isAttacking3 == false)
		{
			anim.SetBool("isAttacking3", false);
			Debug.Log("isAttacking3 ACP = FALSE, because _isAttacking3 BOOL = FALSE");
		}
		
		if (_isAttacking3 == true && attackLevel != 3) // prevents multiple attack states being active at once
		{
			_isAttacking3 = false;
            Debug.Log("_isAttacking3 BOOL = FALSE, because attackLevel mismatch w/ isAttacking state (prevents simultaneous states)");
		}
		
		/*
		if (attackLevel == 1 && !_isAttacking1)
		{
			attackLevel = 0;
		}
		
		if (attackLevel == 3 && !_isAttacking2)
		{	
			attackLevel = 0;
		}
		
		if (attackLevel == 3 && !_isAttacking3)
		{
			attackLevel = 0;
		}
		*/
		
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
		
		Debug.Log("end update loop");
    }
	
	// function to delay the animation off switch
	public void StopAttack1()
	{
		Debug.Log("Before StopAttack1 is called, _isAttacking1 = " + _isAttacking1);
		_isAttacking1 = false;
		Debug.Log("StopAttack1() called. _isAttacking1 should be false. _isAttacking1 = " + _isAttacking1 + " (after StopAttack1 called)");
		attackLevel=0;
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
                    attack1Time = clip.length;
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
