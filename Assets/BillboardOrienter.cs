using System;
using UnityEngine;
using System.Collections;

public class BillboardOrienter : MonoBehaviour
{
    public GameObject lookAtThis;

    void Awake()
    {
        lookAtThis = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
		transform.LookAt(lookAtThis.transform.position); //Unity's method to look at player
     	transform.forward = lookAtThis.transform.forward; //have billboards look in same direction as player
    }
}