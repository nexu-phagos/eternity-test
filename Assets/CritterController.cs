using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterController : MonoBehaviour
{
	public float _randomIdle;
	
	Animator anim;
	
    // Start is called before the first frame update
    void Start()
    {
		_randomIdle = Random.Range(.1f, 1.2f);
		
		anim = gameObject.GetComponent<Animator>();
        
		anim.SetFloat("randomIdle", _randomIdle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
