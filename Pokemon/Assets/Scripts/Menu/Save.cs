using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.X))
    	{
    		PlayerPrefs.SetFloat("Pos x Outside", GameObject.Find("Main_Character").transform.position.x);
        	PlayerPrefs.SetFloat("Pos y Outside", GameObject.Find("Main_Character").transform.position.y);
        	PlayerPrefs.SetFloat("Pos x forest", GameObject.Find("Main_Character").transform.position.x);
        	PlayerPrefs.SetFloat("Pos y forest", GameObject.Find("Main_Character").transform.position.y);
        	PlayerPrefs.SetFloat("Pos x city", GameObject.Find("Main_Character").transform.position.x);
        	PlayerPrefs.SetFloat("Pos y city", GameObject.Find("Main_Character").transform.position.y);
        	PlayerPrefs.SetFloat("Pos x tower", GameObject.Find("Main_Character").transform.position.x);
        	PlayerPrefs.SetFloat("Pos y tower", GameObject.Find("Main_Character").transform.position.y);
        	PlayerPrefs.SetFloat("Pos x floor_1", GameObject.Find("Main_Character").transform.position.x);
        	PlayerPrefs.SetFloat("Pos y floor_1", GameObject.Find("Main_Character").transform.position.y);
    	}
    }
}
