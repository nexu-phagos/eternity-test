using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
	public bool withinTalkingDistance = false;
	
	private DialogueManager dialogueManager;
	
	private GameObject openDialogueTweenContainer;
	private DOTweenVisualManager openDialogue;
	
	private GameObject closeDialogueTweenContainer;
	private DOTweenVisualManager closeDialogue;
	
	private bool conversing;
	
	private Animator anim;
	
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		
		dialogueManager = FindObjectOfType<DialogueManager>();
		
		openDialogueTweenContainer = GameObject.FindWithTag("DialogueOpen");
		openDialogue = openDialogueTweenContainer.GetComponent<DOTweenVisualManager>();
		
		closeDialogueTweenContainer = GameObject.FindWithTag("DialogueClose");
		closeDialogue = closeDialogueTweenContainer.GetComponent<DOTweenVisualManager>();
		
		conversing = false;
	}
	
	public void TriggerDialogue()
	{
		dialogueManager.StartDialogue(dialogue);
		Debug.Log("TriggerDialogue popped");
		//openDialogue.enabled = true;
		//closeDialogue.enabled = false;
	}
	
	void OnTriggerEnter(Collider other)
	{			
		if(other.tag == "Player")
		{
			withinTalkingDistance = true;
		}
	}
	 
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			withinTalkingDistance = false;
			FindObjectOfType<DialogueManager>().EndDialogue();	
			closeDialogue.enabled = false;
			
		}
	}
	
	public void EndDialogueAnimation()
	{
		anim.SetBool("isTalking", false);
	}
	
	void Update()
	{
		if (withinTalkingDistance == true)
		{
			if (conversing == false && Input.GetButtonDown("Interact"))
			{
				Debug.Log("Started conversation");
				TriggerDialogue();
				conversing = true;
				anim.SetBool("isTalking", true);
			}
			
			if (conversing == true && Input.GetButtonDown("Interact"))
			{
				Debug.Log("continuing convo...");
				dialogueManager.DisplayNextSentence();
			}
		}
			
	}
}
