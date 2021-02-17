using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
	public float lifeTime;
	
    void Start()
    {
		Invoke("DestroySelf", lifeTime);
    }
	
	public void DestroySelf()
	{
		Destroy(gameObject);
	}

}
