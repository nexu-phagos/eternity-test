using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningFlicker : MonoBehaviour
{
	public LightningSounds lightningSounds;
	
	bool lightOn = false;
	float randomLightningInterval = 20;
	float flashDuration;
	
	private MeshRenderer m;
    
	void Start()
    {	
		lightningSounds = FindObjectOfType<LightningSounds>();
		m = this.GetComponent<MeshRenderer>();
		
		// randomLightningInterval = Random.Range((randomLightningInterval + 2.0f), (randomLightningInterval + 10.0f));
		
		// starting in 1 seconds, repeating every randomLightningInterval
        InvokeRepeating("LightningStrike", 1.0f, randomLightningInterval);
		
		// Debug.Log("START: randomLightningInterval = " + randomLightningInterval);
		// Debug.Log("START: lightOn = " + lightOn);
    }

    void Update()
    {
        
    }
	
	void LightningStrike()
	{
		// Debug.Log("begin LightSwitch");
		
		// randomLightningInterval = Random.Range((randomLightningInterval + 0.5f), 10.0f);
		randomLightningInterval = Random.Range((randomLightningInterval + 10.0f), (randomLightningInterval + 100.0f));
		flashDuration = Random.Range(0.1f, 2.0f);
		// Debug.Log("randomLightningInterval = " + randomLightningInterval);
		// Debug.Log("flashDuration = " + flashDuration);
		
		lightOn = !lightOn;
		m.enabled = lightOn;
		// Debug.Log("lightOn = " + lightOn);
		
		lightningSounds.PlayLightningSFX();
		
		Invoke("LightningHold", flashDuration);
		
		// Debug.Log("end LightSwitch");
	}
	
	void LightningHold()
	{
		// Debug.Log("begin HOLD");
		
		lightOn = !lightOn;
		m.enabled = lightOn;
		Debug.Log("HOLD: lightOn = " + lightOn);
		
		// Debug.Log("end HOLD");
	}
}
