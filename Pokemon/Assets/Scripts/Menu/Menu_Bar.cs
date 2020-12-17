using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Bar : MonoBehaviour
{
	[SerializeField] List<Text> menuTexts;
	[SerializeField] GameObject save;

	int currentMenu;

	void Start()
	{
		save = GameObject.Find("Save");
	}

	void HandleMenuSelection()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentMenu < 1)
                ++currentMenu;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentMenu > 0)
            {
                --currentMenu;
            }
        }
        UpdateMenuSelection(currentMenu);
	}

    void UpdateMenuSelection(int selectedMenu)
    {
        for(int i = 0; i < menuTexts.Count; ++i)
 		{
 			//Si l'on sélectionne une action, le texte passe en bleu
 			if(i == selectedMenu)
 			{
 				menuTexts[i].color = Color.blue;
 			}
 			else
 			{
 				menuTexts[i].color = Color.black;
 			}
 		}
    }
}
