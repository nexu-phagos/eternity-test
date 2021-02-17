using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindPlayerToFollow : MonoBehaviour
{
	private GameObject player;
	private GameObject followObject;
	private GameObject lookAtObject;
	
    private Transform followTarget;
	private Transform lookAtTarget;
	
    private CinemachineVirtualCamera vcam;
	private GameObject _vcam;
 
    void Start()
    {
        var vcam = this.GetComponent<CinemachineVirtualCamera>();
		
		if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
		
		lookAtObject = player.transform.Find("LookAtObject").gameObject;
        lookAtTarget= lookAtObject.transform;
		
		followObject = player.transform.Find("FollowObject").gameObject;
        followTarget = followObject.transform;
		
        vcam.LookAt = lookAtTarget;
        vcam.Follow = followTarget;
    }

	public void FindPlayerToFollowOnDemand()
	{
		_vcam = GameObject.FindWithTag("CinemachineCameras");
		var vcam = _vcam.GetComponent<CinemachineVirtualCamera>();
		
		if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
		
		lookAtObject = player.transform.Find("LookAtObject").gameObject;
        lookAtTarget= lookAtObject.transform;
		
		followObject = player.transform.Find("FollowObject").gameObject;
        followTarget = followObject.transform;
		
        vcam.LookAt = lookAtTarget;
        vcam.Follow = followTarget;
	}
	
	void OnTriggerEnter()
	{
		_vcam = GameObject.FindWithTag("CinemachineCameras");
		var vcam = _vcam.GetComponent<CinemachineVirtualCamera>();
		
		if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
		
		lookAtObject = player.transform.Find("LookAtObject").gameObject;
        lookAtTarget= lookAtObject.transform;
		
		followObject = player.transform.Find("FollowObject").gameObject;
        followTarget = followObject.transform;
		
        vcam.LookAt = lookAtTarget;
        vcam.Follow = followTarget;
	}
}
