using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickupItem : MonoBehaviour
{	
	private GameObject inventoryManager;
	
	void Start()
	{
		inventoryManager = GameObject.FindWithTag("InventoryManager");
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			inventoryManager.gameObject.GetComponent<InventorySystem>().PickUp(gameObject);
			Debug.Log("Player picked up an item");
		}
	}
}
