using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
	//Variable que l'on assigne dans Unity contenant le nom de la scène vers laquelle le joueur va
	string toScene;
	GameObject animation;
	//On créé un objet SceneController dont la classe est définie dans SceneController.cs et Outside.cs
	private SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    { 
        sceneController = this.GetComponent<SceneController>();
        toScene = this.name;
    }

    //Lorsque le joueur entre en collision avec le GameObject portant le script, on change de scène
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	StartCoroutine(Change(collision));
    }

    IEnumerator Change(Collider2D collision)
    {
    	if(collision.CompareTag("Player"))
    	{
    		animation = GameObject.Find("FollowCamera");
    		animation.GetComponent<Animator>().SetTrigger("Start");
    		yield return new WaitForSeconds(1);
    		sceneController.Scene(toScene);
    	} 
    }
}
