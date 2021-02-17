using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalState : MonoBehaviour
{
	private GameObject portalToForestCrossroads;
	private GameObject portalToHomePortals;
	private Transform portalToHomePortalsTrans;
	private GameObject portalParent;
	
	void Start()
	{
		// TEMP FIX: this will definitely need to be refactored
		// currently there's only one portal handler object, thus only one instance of this script
		// so the portal back to forest crossroads disables as soon as boss area loads, and there's no way back
		Invoke("DisablePortalToForestCrossroads", 3);
	}
	
	public void EnablePortalToHomePortals()
	{
		Debug.Log("tried to activate home portal");
	
		portalParent = GameObject.FindWithTag("PortalParent");
		
		portalToHomePortalsTrans = portalParent.transform.Find("toHomeHub");
		portalToHomePortals = portalToHomePortalsTrans.gameObject;
			
		//portalToHomePortals = portalParent.FindObject("toHomeHub");
		portalToHomePortals.SetActive(true);
	}
	
	public void DisablePortalToForestCrossroads()
	{
		portalToForestCrossroads = GameObject.Find("toFPCrossroads");
		portalToForestCrossroads.SetActive(false);
	}
}
