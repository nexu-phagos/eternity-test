using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
	public GameObject entityDestroyedPrefab;
	private GameObject explosionCloudPrefab;
	
	private GameObject persistentSFXGameObject;
	private PersistentSFX persistentSFX;
	
	private int bombTimer;
	
    void Start()
    {
		persistentSFXGameObject = GameObject.Find("PersistentSFX");
		persistentSFX = persistentSFXGameObject.GetComponent<PersistentSFX>();
        
		bombTimer = 15;
		
		Invoke("Explode", bombTimer);
    }

    void Update()
    {
        
    }
	
	void Explode()
	{
		persistentSFX.PlayContainer1SmashSFX();
		Debug.Log("Bomb exploded");
		Destroy(gameObject);
		
		Vector3 deathPos = this.gameObject.transform.position;
		Quaternion deathRot = this.gameObject.transform.rotation;
		
		GameObject explosionCloudPrefab = Instantiate(entityDestroyedPrefab, deathPos, deathRot);
	}
}
