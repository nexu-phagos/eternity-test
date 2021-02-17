﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
	/*
	public float frequencyMin = 1.0f;
	public float frequencyMax = 2.0f;
	public float magnitude = 0.0025f;
	private float randomInterval;
	*/
	
	// User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
	
	// Position Storage Variables
    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();
	 
	void Start () 
	{
		// randomInterval = Random.Range(frequencyMin, frequencyMax);
		
		// Store the starting position & rotation of the object
        posOffset = transform.position;
	}
	 
	void Update () 
	{
		//this.transform.position.y = this.transform.position.y += (Mathf.Cos(Time.time * randomInterval) * magnitude);
		//this.transform.eulerAngles.x = this.transform.eulerAngles.x += (Mathf.Cos(Time.time * randomInterval) * 2);
		
		// Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
 
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
	}
}
