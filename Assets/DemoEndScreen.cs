using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DemoEndScreen : MonoBehaviour
{
	private GameObject openEndScreenTweenContainer;
	private DOTweenVisualManager openEndScreenTweenManager;
    // Start is called before the first frame update
    void Start()
    {
		openEndScreenTweenContainer = GameObject.FindWithTag("EndScreenOpen");
		openEndScreenTweenManager = openEndScreenTweenContainer.GetComponent<DOTweenVisualManager>();
		
		Invoke("EndDemo", 60);
		
    }

	void EndDemo()
	{
		openEndScreenTweenManager.enabled = true;
	}
}
