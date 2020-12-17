using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
	//Variable permettant d'afficher les lettres du messages de début de combat au fur et à mesure
	[SerializeField] int letterPerSecond;
	//Variable permettant d'afficher le texte de début de combat
	[SerializeField] Text dialogText;
	//Objets représentant les objets ActionSelector, MoveSelector et MoveDetails pour permettre de les afficher ou non
	[SerializeField] GameObject actionSelector;
	[SerializeField] GameObject moveSelector;
	[SerializeField] GameObject moveDetails;

	//Textes contenant les actions possibles et les attaques d'un pokémon
	[SerializeField] List<Text> actionTexts;
	[SerializeField] List<Text> moveTexts;

	//Textes contenant les PP et le type d'une attaque
	[SerializeField] Text ppText;
	[SerializeField] Text typeText;

	//Méthode permettant d'assigner un dialogue au début du combat
 	public void SetDialog(string dialog)
 	{
 		dialogText.text = dialog;
 	}   

 	//Méthode permettant de faire apparaître les lettres du dialogue de début de combat en plusieurs fois et non d'un seul coup
 	public IEnumerator TypeDialog(string dialog)
 	{
 		dialogText.text = "";
 		foreach(var letter in dialog.ToCharArray())
 		{
 			dialogText.text += letter;
 			yield return new WaitForSeconds(1f/letterPerSecond);
 		}

 		yield return new WaitForSeconds(1f);
 	}

 	//Méthode permettant d'afficher ou non le dialogue du début de combat
 	public void EnableDialogText(bool enable)
 	{
 		dialogText.enabled = enable;
 	}
 	//Méthode permettant d'afficher ou non les actions sélectionnables
 	public void EnableActionSelector(bool enable)
 	{
 		actionSelector.SetActive(enable);
 	}
 	//Méthode permettant d'afficher ou non les attaques ainsi que leurs caractéristiques
 	public void EnableMoveSelector(bool enable)
 	{
 		moveSelector.SetActive(enable);
 		moveDetails.SetActive(enable);
 	}

 	//Méthode permettant de sélectionner une action
 	public void UpdateActionSelection(int selectedAction)
 	{
 		for(int i = 0; i < actionTexts.Count; ++i)
 		{
 			//Si l'on sélectionne une action, le texte passe en bleu
 			if(i == selectedAction)
 			{
 				actionTexts[i].color = Color.blue;
 			}
 			else
 			{
 				actionTexts[i].color = Color.black;
 			}
 		}
 	}

 	//Méthode permettant de sélectionner une attaque
 	public void UpdateMoveSelection(int selectedMove, Move move)
 	{
 		for(int i = 0; i < moveTexts.Count; ++i)
 		{
 			//Si l'on sélectionne une attaque, le texte passe en bleu
 			if(i == selectedMove)
 			{
 				moveTexts[i].color = Color.blue;
 			}
 			else
 			{
 				moveTexts[i].color = Color.black;
 			}
 		}
 		//On affiche les caractéristiques de l'attaque sélectionnée
 		ppText.text = $"PP {move.PP}/{move.Base.GetPP()}";
 		typeText.text = $"TYPE {move.Base.GetType1().ToString()}";
 	}

 	//Méthode permettant d'afficher les attques assignées à un pokémon
 	public void SetMoveNames(List<Move> moves)
 	{
 		for(int i = 0; i < moveTexts.Count; ++i)
 		{
 			if(i < moves.Count)
 			moveTexts[i].text = moves[i].Base.GetName();

 			else
 			moveTexts[i].text = "-";
 		}
 	}
}
