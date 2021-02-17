using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrowingMachine : MonoBehaviour
{
	private GameObject _bombPrefab;
	public GameObject bombPrefab;
	
	public int whenToStartThrowingBombs;
	public int bombInterval;
	
    // Start is called before the first frame update
    void Start()
    {
		whenToStartThrowingBombs = 0;
		bombInterval = 5;
		
		InvokeRepeating("ThrowBomb", whenToStartThrowingBombs, bombInterval);
    }
	
	void ThrowBomb()
	{
		Vector3 spawnPos = this.gameObject.transform.position;
		Quaternion spawnRot	= this.gameObject.transform.rotation;
		
		GameObject _bombPrefab = Instantiate(bombPrefab, spawnPos, spawnRot);
	}
}
