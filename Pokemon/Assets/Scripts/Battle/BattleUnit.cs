using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
 	//Variable contenant les information de base du pokemon ciblé   
    [SerializeField] Pokemon_base _base;
    //Variable contenant le niveau du pokémon ciblé
    [SerializeField] int level;
    //Variable permettant de savoir si le pokémon est celui du joueur ou non, et donc d'afficher son sprite de dos ou de face
    [SerializeField] bool isPlayer;
    Image image;
    Vector3 originalPos;
    Color originalColor;
    //Variable contenant le pokémon ciblé
    public Pokemon pokemon {get; set;}

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
        originalColor = image.color;
    }

    //Méthode permettant d'afficher le sprite de dos ou de face selon si celui-ci est celui du joueur ou non
    public void Setup()
    {
        pokemon = new Pokemon(_base, level);
        
    	if(isPlayer)
    	{
    		image.sprite = pokemon._base.GetbackSprite();
    	}
    	else
    	{
    		image.sprite = pokemon._base.GetfrontSprite();
    	}
        EnterAnimation();

    }







//-----------------------------------------------------------Animationtions-------------------------------------------------//
    //Animation lorsque le pokemon est touché
    public void HitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.gray, 0.1f));
        sequence.Append(image.DOColor(originalColor, 0.1f));
    }

    //Animation lorsque le pokemon attaque
    public void AttackAnimation()
    {
        var sequence = DOTween.Sequence();
        if(isPlayer)
        {
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x + 50f, 0.25f));
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x, 0.25f));
        }
        else
        {
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x - 50f, 0.25f));
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x, 0.25f));
        }
        
    }

    //Animation lorsque le pokémon est KO
    public void FaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originalPos.y - 150f, 0.5f));
        sequence.Join(image.DOFade(0f, 0.5f));
    }

    //Animation de début de combat
    public void EnterAnimation()
    {
        if(isPlayer)
        {
            image.transform.localPosition = new Vector3(-600f, originalPos.y);
        }
        else
        {
            image.transform.localPosition = new Vector3(500f, originalPos.y);
        }
        image.transform.DOLocalMoveX(originalPos.x, 1f);
    }
//-----------------------------------------------------------Fin Animationtions---------------------------------------------//

}
