using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JingleBellEquip : MonoBehaviour
{
	private GameObject player;
	
	private SimpleAnimationStateController animControllerScript;
	
	private GameObject playerUnarmed;
	private GameObject playerEquippedWithStaff;
	
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindWithTag("Player");
		
		playerEquippedWithStaff = player.transform.Find("changeling-staff-equipped").gameObject;
		playerUnarmed = player.transform.Find("changeling-unarmed").gameObject;
		animControllerScript = player.GetComponent<SimpleAnimationStateController>();
		
		if (playerEquippedWithStaff.activeSelf)
		{
			this.enabled = false;
		}
    }
	
	public void EquipJingleBell()
	{
		playerEquippedWithStaff.SetActive(true);
		playerUnarmed.SetActive(false);
		animControllerScript.RefreshAnimatorController();
	}
}
