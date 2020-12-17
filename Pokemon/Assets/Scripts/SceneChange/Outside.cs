using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outside :
SceneController {
	//Variable qui va récupérer le GameObject du joueur
    GameObject player;

    public override void Start()
    {
    	Debug.Log(sceneBefore);
    	Debug.Log("Current scene" + currentScene);
        base.Start();
        //On récupère le GameObject du joueur grâce à son nom
        player = GameObject.Find("Main_Character");
        //Selon les différentes scène depuis lesquelles le joueur part, sa position attribuée va changer pour qu'il apparaisse devant la porte de la bonne maison
        if(currentScene == "Outside")
        {
        	if(sceneBefore == "forest")
        	player.transform.position = new Vector2(-63.5f, -7.5f);

        	else
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("Pos x Outside"), PlayerPrefs.GetFloat("Pos y Outside") - 1);
        }

        else if(currentScene == "forest")
        {
        	if(sceneBefore == "Outside")
        	player.transform.position = new Vector2(19.5f, -26.5f);

        	else if(sceneBefore == "city")
        	player.transform.position = new Vector2(-28.5f, 2.5f);

        }

        else if(currentScene == "city")
        {
            if(sceneBefore == "forest")
        	player.transform.position = new Vector2(50.5f, -1.5f);

        	else if(sceneBefore == "tower")
        	player.transform.position = new Vector2(-20.5f, -1.5f);

        	else
        	player.transform.position = new Vector2(PlayerPrefs.GetFloat("Pos x city"), PlayerPrefs.GetFloat("Pos y city") - 1  );
        }
        else if(currentScene == "tower"){
            if(sceneBefore == "city")
        	player.transform.position = new Vector2(22.5f, -0.5f);

        	else if(sceneBefore == "floor_1")
        	player.transform.position = new Vector2(9.5f, 9.5f);

        }
        else if(currentScene == "floor_1"){
            if(sceneBefore == "tower")
        	player.transform.position = new Vector2(24.5f, -52.5f);
        }
            
    }
}
