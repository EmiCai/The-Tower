using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{  
    // commencer le jeu 
    public void Jouer ()
    {
        SceneManager.LoadScene("Outside");
    }
    //quitter le jeu 
    public void Quitter()
    {
        Application.Quit();
    }
}
