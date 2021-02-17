using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileBrain : MonoBehaviour
{
	private Vector3 prevPos;
	private Vector3 actualPos;
	
	private bool withinPlayerRange;
	private bool isMoving;
	
	private Animator anim;
	private FollowPlayer followPlayer;
	
	private bool hostileBrainAlive;
	
    void Start()
    {
		hostileBrainAlive = true;
        StartCoroutine(CalcIfMoved());
		isMoving = false;
		anim = this.GetComponent<Animator>();
		followPlayer = this.GetComponentInParent<FollowPlayer>();
    }
	
	public void SetHostileBrainDead()
	{
		hostileBrainAlive = false;
	}

	void Update()
	{
		if (withinPlayerRange && hostileBrainAlive)
		{
			StartCoroutine(CalcIfMoved());
			followPlayer.StartFollowing(withinPlayerRange);
			
			if (prevPos == actualPos) 
				{
					Debug.Log("hostile stoped");
					isMoving = false;
					anim.SetBool("isMoving", false);
				}
				
			if (prevPos != actualPos) 
				{
					Debug.Log("hostile on the move");
					isMoving = true;
					anim.SetBool("isMoving", true);
					followPlayer.StartFollowing(isMoving);
				}
		}
	
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			withinPlayerRange = true;
		}
		
		
	}
	
	IEnumerator CalcIfMoved()
	{
		prevPos = this.transform.position;
		yield return new WaitForSeconds(0.5f);
		actualPos = this.transform.position;
	}
}
