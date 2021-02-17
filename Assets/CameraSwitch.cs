using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
	public GameObject activeCamera;
	
	private int cameraCount;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("CinemachineCameras");
 
			foreach(GameObject go in gameObjectArray)
			{
				go.SetActive (false);
			}
			
			activeCamera.SetActive(true);
		}
	}
}
