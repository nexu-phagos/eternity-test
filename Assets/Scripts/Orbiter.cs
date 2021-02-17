﻿using UnityEngine;
 using System.Collections;
 
 public class Orbiter : MonoBehaviour {
     
     public Transform center;
     public Vector3 axis = Vector3.up;
     public Vector3 desiredPosition;
     public float radius = 2.0f;
     public float radiusSpeed = 0.5f;
     public float rotationSpeed = 80.0f;
 
     void Start () {
     }
     
     void Update () {
         transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
         desiredPosition = (transform.position - center.position).normalized * radius + center.position;
         transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
     }
 }