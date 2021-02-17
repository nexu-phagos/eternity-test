using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{
	private GameObject player;
	public Transform _nextZoneSpawnLocation;
	
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
	
	void OnTriggerEnter()
	{
		// player.transform.position = new Vector3(0,0,0);
		
		PlayerPosReset();	
	}
	
	void PlayerPosReset()
	{
		player = GameObject.FindWithTag("Player");
		
		// player.transform.position = new Vector3(0,0,0);
		player.transform.position = _nextZoneSpawnLocation.transform.position;
	}
}
