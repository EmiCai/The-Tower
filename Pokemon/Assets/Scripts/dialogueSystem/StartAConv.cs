using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAConv : MonoBehaviour
{
	public DialogueManager DialogueBox;
	public Conversation convo1;
	public Conversation convo2;
	public void StartConvo(int choix){
		if (choix == 1)
			DialogueManager.StartConversation(convo1);
		if(choix == 2)
			DialogueManager.StartConversation(convo2);
	}

	public void ReadNext(){
		DialogueBox.ReadNext();
	}
}
