using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
	public int marbles;
	public int brambleStones;
	public int essence;
	public bool jingleBell;
	
	private GameObject marblePanel;
	private GameObject brambleStonePanel;
	private GameObject essencePanel;
	private GameObject jingleBellPanel;
	
	private TextMeshProUGUI marbleCountTMP;
	private TextMeshProUGUI brambleStoneCountTMP;
	private TextMeshProUGUI essenceCountTMP;
	
	private GameObject jingleBellGameObject;
	private EquipItem jingleBellEquip;
	
	private GameObject persistentSFXGameObject;
	private PersistentSFX persistentSFX;
	
    void Start()
    {
		persistentSFXGameObject = GameObject.Find("PersistentSFX");
		persistentSFX = persistentSFXGameObject.GetComponent<PersistentSFX>();
		
		jingleBellGameObject = GameObject.Find("jingleBell");
		jingleBellEquip = jingleBellGameObject.GetComponent<EquipItem>();
		
		marbles = 0;
		brambleStones = 0;
		essence = 0;
		jingleBell = false;
		
		// get panel object for each pickip
		// get TMP for each pickup from hud object
		// set TMP using pickup value
		
		marblePanel = GameObject.Find("marblePanel");
		brambleStonePanel = GameObject.Find("bramblePanel");
		essencePanel = GameObject.Find("essencePanel");
		
		marbleCountTMP = marblePanel.GetComponentInChildren<TextMeshProUGUI>();
		brambleStoneCountTMP = brambleStonePanel.GetComponentInChildren<TextMeshProUGUI>();
		essenceCountTMP = essencePanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }
	
	public void PickUp(GameObject itemToPickUp)
	{
		// Debug.Log("At least the PickUp function is calling.");
		if(itemToPickUp.tag=="Marble")
		{
			marbles = marbles+1;
			// Debug.Log("Player picked up a marble");
			Destroy(itemToPickUp);
			marbleCountTMP.SetText($"{marbles}");
			
			// DOSpiral
			// transform.DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 1, 10);
			
			persistentSFX.PlayMarbleSFX();

		}
		
		if(itemToPickUp.tag=="BrambleStone")
		{
			brambleStones = brambleStones+1;
			Debug.Log("Player picked up BrambleStone");
			Destroy(itemToPickUp);
			brambleStoneCountTMP.SetText($"{brambleStones}");
			
			persistentSFX.PlayBrambleStoneSFX();
		}
		
		if(itemToPickUp.tag=="Essence")
		{
			essence = essence+1;
			Debug.Log("Player picked up Essence");
			Destroy(itemToPickUp);
			essenceCountTMP.SetText($"{essence}");
			persistentSFX.PlayEssenceSFX();
		}
		
		if(itemToPickUp.tag=="JingleBell")
		{
			jingleBellGameObject = GameObject.FindWithTag("JingleBell");
			jingleBellEquip = jingleBellGameObject.GetComponent<EquipItem>();
			jingleBell = true;
			Debug.Log("Player picked up JingleBell");
			jingleBellEquip.EquipPickup();
			Destroy(itemToPickUp);
			
			persistentSFX.PlayJingleBellSFX();
		}
	}
}
