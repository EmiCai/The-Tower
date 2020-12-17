using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnjConv : MonoBehaviour
{
	public bool playerInRange;
	private StartAConv myConvo;
	public GameObject dialogBox;
    // Start is called before the first frame update
    void Start()
    {
        myConvo = GetComponent<StartAConv>();
    }

    // Update is called once per frame
    void Update()
    {
    	//Dialogue
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange){
            if(dialogBox.activeInHierarchy){
            	myConvo.ReadNext();
            }else{
                dialogBox.SetActive(true);
                myConvo.StartConvo(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    		playerInRange = true;
    	}
    }
    private void OnTriggerExit2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    		playerInRange = false;
            dialogBox.SetActive(false);
    	}
    }
}
