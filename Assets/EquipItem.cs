using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
	public GameObject playerEquippedWithItemPrefab;
	private GameObject player;
	private SimpleAnimationStateController animControllerScript;
	
	private GameObject _playerEquipped;
	
	private GameObject canvas;
	private FindRenderCamera findRenderCam;
	
	private GameObject cinemachineCam;
	private FindPlayerToFollow findPlayerToFollow;
	
	private DontDestroyOnLoad ddol;
	
	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}
	
	public void EquipPickup()
	{		
		Vector3 deathPos = this.gameObject.transform.position;
		Quaternion deathRot = this.gameObject.transform.rotation;	
		
		player = GameObject.FindWithTag("Player");
		Destroy(player);
	
		// search again after original player destroyed
		player = GameObject.FindWithTag("Player");
		ddol = player.GetComponent<DontDestroyOnLoad>();
		ddol.PlayerCheck();
		
		GameObject _playerEquipped = Instantiate(playerEquippedWithItemPrefab, deathPos, deathRot);
		_playerEquipped.tag="Player";
		
		animControllerScript = player.GetComponentInChildren<SimpleAnimationStateController>();
		animControllerScript.RefreshAnimatorController();

		
	}
}
