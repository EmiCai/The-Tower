using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class DialogueManager : MonoBehaviour
{
	public GameObject dialogueBox;
	public Text speakerName, dialogue;

	private int currentIndex;
	private Conversation currentConvo;
	private static DialogueManager instance;
	private Coroutine typing;

	private void Awake(){

		if(instance == null){
			instance = this;
			dialogueBox.SetActive(true);
		}else{
			Destroy(gameObject);
		}
	}

	public static void StartConversation(Conversation convo){

		instance.currentIndex = 0;
		instance.currentConvo = convo;
		instance.speakerName.text ="";
		instance.dialogue.text = "";
		instance.ReadNext();
	}

	public void ReadNext(){

		if(currentIndex > currentConvo.GetLength() ){ //Si on atteint la fin
			dialogueBox.SetActive(false);
			return;
		}
		speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
		
		//obtient une phrase
		if(typing == null){
			typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
		}else{
			instance.StopCoroutine(typing);
			typing = null;
			typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
		}
		currentIndex++;
	}

	//Pour afficher lettre par lettre et non tout d'un coup d'une phrase
	private IEnumerator TypeText(string text){
		dialogue.text = "";
		bool complete = false;
		int index = 0;
		while(!complete){
			dialogue.text += text[index];
			yield return new WaitForSeconds(0.02f);

			if(index == text.Length - 1)
				complete = true;
			index++;
		}
		typing = null;
	}
}
