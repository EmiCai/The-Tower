using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
	//On a forcément besoin des informations d'une attaque pour créer cette attaque
    public Move_base Base{get; set;}
    //PP de l'attaque durant le jeu
    public int PP{get; set;}

    public Move(Move_base pBase)
    {
    	//L'attaque est assignée avec le maximum de PP
    	Base = pBase;
    	PP = pBase.GetPP();
    }
}
