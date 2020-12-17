using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
	//Variable contenant le nom de la scène sur laquelle on va 
	public static string currentScene = "";
    public static string sceneBefore = "";

    // Start is called before the first frame update
    //La méthode Start est implémentée dans Outside.cs
    public virtual void Start()
    {	
    	//Dans la méthode Start virtuelle, assigne le nom de la scène sur laquelle on est
    	//Dans un premier temps, c'est le nom de la scène depuis laquelle on part, puis ça devient le nom de la scène sur laquelle on attérrit
        currentScene = SceneManager.GetActiveScene().name;  
    }

    public void Scene(string sceneName)
    {
        if(currentScene == "Outside")
        {
            PlayerPrefs.SetFloat("Pos x Outside", GameObject.Find("Main_Character").transform.position.x);
            PlayerPrefs.SetFloat("Pos y Outside", GameObject.Find("Main_Character").transform.position.y);
        }
        else if(currentScene == "forest")
        {
            PlayerPrefs.SetFloat("Pos x forest", GameObject.Find("Main_Character").transform.position.x);
            PlayerPrefs.SetFloat("Pos y forest", GameObject.Find("Main_Character").transform.position.y);
        }
        else if(currentScene == "city")
        {
            PlayerPrefs.SetFloat("Pos x city", GameObject.Find("Main_Character").transform.position.x);
            PlayerPrefs.SetFloat("Pos y city", GameObject.Find("Main_Character").transform.position.y);
        }
        else if(currentScene == "tower")
        {
            PlayerPrefs.SetFloat("Pos x tower", GameObject.Find("Main_Character").transform.position.x);
            PlayerPrefs.SetFloat("Pos y tower", GameObject.Find("Main_Character").transform.position.y);
        }
        else if(currentScene == "floor_1")
        {
            PlayerPrefs.SetFloat("Pos x floor_1", GameObject.Find("Main_Character").transform.position.x);
            PlayerPrefs.SetFloat("Pos y floor_1", GameObject.Find("Main_Character").transform.position.y);
        }
    	//On assigne a prevScene le nom de la scène de laquelle on part avant de changer de scène
    	SceneManager.LoadScene(sceneName);
        sceneBefore = currentScene;
    }
}
