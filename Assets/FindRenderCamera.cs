using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRenderCamera : MonoBehaviour
{
	private GameObject player;
	private GameObject mainCameraContainer;
	
	private Camera mainCamera;
	
	private GameObject mainCanvasContainer;
	private Canvas mainCanvas;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
		mainCameraContainer = GameObject.FindWithTag("MainCamera");
		mainCanvasContainer = GameObject.FindWithTag("Canvas");
		
		mainCamera = mainCameraContainer.GetComponent<Camera>();
		mainCanvas = mainCanvasContainer.GetComponent<Canvas>();
		
		mainCanvas.worldCamera = mainCamera;
    }

	  public void FindRenderCamOnDemand()
	  {
			player = GameObject.FindWithTag("Player");
			mainCameraContainer = GameObject.FindWithTag("MainCamera");
			mainCanvasContainer = GameObject.FindWithTag("Canvas");
			
			mainCamera = mainCameraContainer.GetComponent<Camera>();
			mainCanvas = mainCanvasContainer.GetComponent<Canvas>();
			
			mainCanvas.worldCamera = mainCamera;
	  }
	
	void OnLevelWasLoaded()
	{
		player = GameObject.FindWithTag("Player");
		mainCameraContainer = GameObject.FindWithTag("MainCamera");
		mainCanvasContainer = GameObject.FindWithTag("Canvas");
		
		mainCamera = mainCameraContainer.GetComponent<Camera>();
		mainCanvas = mainCanvasContainer.GetComponent<Canvas>();
		
		mainCanvas.worldCamera = mainCamera;
	}
	
	void OnTriggerEnter()
	{
		player = GameObject.FindWithTag("Player");
		mainCameraContainer = GameObject.FindWithTag("MainCamera");
		mainCanvasContainer = GameObject.FindWithTag("Canvas");
		
		mainCamera = mainCameraContainer.GetComponent<Camera>();
		mainCanvas = mainCanvasContainer.GetComponent<Canvas>();
		
		mainCanvas.worldCamera = mainCamera;
	}
	
}
