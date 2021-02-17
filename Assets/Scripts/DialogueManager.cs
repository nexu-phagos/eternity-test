using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
	private Queue<string> sentences;
	
	public Text nameText;
	public Text dialogueText;
	
	//public TextMeshProUGUI nameText;
	//public TextMeshProUGUI dialogueText;
	
	
	private GameObject openDialogueTweenContainer;
	private DOTweenVisualManager openDialogue;
	
	private GameObject closeDialogueTweenContainer;
	private DOTweenVisualManager closeDialogue;
	
	//private DialogueTrigger dialogueTrigger;
	
    void Start()
    {
		//dialogueTrigger = GameObject
		
		sentences = new Queue<string>();
		
		openDialogueTweenContainer = GameObject.FindWithTag("DialogueOpen");
		openDialogue = openDialogueTweenContainer.GetComponent<DOTweenVisualManager>();
		
		closeDialogueTweenContainer = GameObject.FindWithTag("DialogueClose");
		closeDialogue = closeDialogueTweenContainer.GetComponent<DOTweenVisualManager>();
		
		closeDialogue.enabled = true;
		closeDialogue.enabled = false;
    }
	
	public void StartDialogue(Dialogue dialogue)
	{
		
		nameText.text = dialogue.name;
		
		sentences.Clear();
		
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		
		openDialogue.enabled = true;
		
		//openDialogue.enabled = false;
		
		
		DisplayNextSentence();
	}
	
	public void DisplayNextSentence()
	{
		if (sentences.Count==0)
		{
			EndDialogue();
			return;
		}
		
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}
	
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
	
	public void EndDialogue()
	{
		Debug.Log("End of conversation");
		
		closeDialogue.enabled = true;
		openDialogue.enabled = false;
		FindObjectOfType<DialogueTrigger>().EndDialogueAnimation();
		
		sentences.Clear();
		return;
	}
}
