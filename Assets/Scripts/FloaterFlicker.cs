using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterFlicker : MonoBehaviour
{
	public Floater floater;
	//comment test
	
	void Start()
	{
		floater = GetComponent<Floater>();
		Invoke("TurnOnFloater", 3.0f);
	}
	
	void TurnOnFloater()
	{
		floater.enabled = true;
	}
}
