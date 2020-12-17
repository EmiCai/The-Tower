using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]

public class Pokemon_base : ScriptableObject
{
	//Information du pokémon
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;
    [SerializeField] PokemonType type3;

    [SerializeField] int hp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    //Liste des attques pouvant être apprises par le pokémon
    [SerializeField] List<LearnableMove> learnableMoves;

    //Getter des attributs de la classe Pokemon_Base
	public string GetName()
	{
		return name;
	}
	public string GetDescription()
	{
		return description;
	}
	public Sprite GetfrontSprite()
	{
		return frontSprite;
	}
	public Sprite GetbackSprite()
	{
		return backSprite;
	}
	public PokemonType GetType1()
	{
		return type1;
	}
	public PokemonType GetType2()
	{
		return type2;
	}
	public PokemonType GetType3()
	{
		return type3;
	}
	public int GetHp()
	{
		return hp;
	}
	public int GetAttack()
	{
		return attack;
	}
	public int GetDefense()
	{
		return defense;
	}
	public int GetSpAttack()
	{
		return spAttack;
	}
	public int GetSpDefense()
	{
		return spDefense;
	}
	public int GetSpeed()
	{
		return speed;
	}
	public List<LearnableMove> GetLearnableMoves()
	{
		return learnableMoves;
	}

}

//Classe permettant d'apprendre une nouvelle attaque au niveau voulu
[System.Serializable]
public class LearnableMove
{
	[SerializeField] Move_base moveBase;
	[SerializeField] int level;

	public Move_base GetMoveBase()
    {
   		return moveBase;
   	}
   	public int GetLevel()
    {
   		return level;
   	}
}

//Enumération des types de pokémon
public enum PokemonType
{
	None,
	Normal,
	Combat,
	Dark,
	Spectr,
	Psy,
	Fée,
	Feu,
	Eau,
	Plante,
	Roche,
	Acier,
	Sol,
	Vol,
	Electrik,
	Light,
	Cristal,
	Bug,
	Ice,
	Dragon,
	Poison
}

public enum Stat
{
	Attack,
	Defense,
	SpAttack,
	SpDefense,
	Speed
}

public class TypeChart
{
	static float[][] chart =
	{
		//					NOR COM DAR SPE PSY FEE FEU EAU PLA ROC ACI SOL VOL ELE LIG CRI BUG ICE DRA POI
		/*NOR*/new float[] { 1f, 2f, 1f, 0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f},
		/*COM*/new float[] { 1f, 1f, 0.5f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f},
		/*DAR*/new float[] { 0f, 2f, 0.5f, 0.5f, 0f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 1f, 1f, 1f, 1f},
		/*SPE*/new float[] { 0f, 0f, 2f, 2f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 0.5f, 1f, 1f, 0.5f},
		/*PSY*/new float[] { 1f, 0.5f, 2f, 2f, 0.5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f},
		/*FEE*/new float[] { 1f, 0.5f, 0.5f, 1f, 1f, 0.5f, 0.5f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 0f, 2f},
		/*FEU*/new float[] { 1f, 1f, 1f, 1f, 1f, 0.5f, 0.5f, 2f, 0.5f, 2f, 0.5f, 2f, 1f, 1f, 1f, 1f, 0.5f, 0.5f, 1f, 1f},
		/*EAU*/new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 0.5f, 2f, 1f, 0.5f, 1f, 1f, 2f, 1f, 1f, 1f, 0.5f, 1f, 1f},
		/*PLA*/new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 2f, 0.5f, 0.5f, 1f, 1f, 1f, 2f, 1f, 1f, 0.5f, 2f, 2f, 1f, 2f},
		/*ROC*/new float[] { 0.5f, 2f, 1f, 1f, 1f, 1f, 0.5f, 2f, 2f, 0.5f, 2f, 2f, 1f, 0f, 1f, 1f, 1f, 2f, 1f, 0.5f},
		/*ACI*/new float[] { 0.5f, 2f, 0.5f, 1f, 0.5f, 0.5f, 2f, 1f, 0.5f, 0.5f, 0.5f, 2f, 0.5f, 1f, 0f, 1f, 0.5f, 0.5f, 0.5f, 0f},
		/*SOL*/new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 0.5f, 1f, 1f, 1f, 0f, 1f, 1f, 1f, 2f, 1f, 0.5f},
		/*VOL*/new float[] { 1f, 0.5f, 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 2f, 1f, 0f, 1f, 2f, 1f, 1f, 0.5f, 2f, 1f, 1f},
		/*ELE*/new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 2f, 0.5f, 0.5f, 1f, 1f, 1f, 1f, 1f, 1f},
		/*LIG*/new float[] { 1f, 1f, 2f, 2f, 1f, 0.5f, 0.5f, 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 0.5f, 1f, 1f, 1f, 1f, 1f},
		/*CRI*/new float[] { 0.5f, 1f, 0f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 1f},
		/*BUG*/new float[] { 1f, 0.5f, 1f, 1f, 1f, 1f, 2f, 1f, 0.5f, 2f, 1f, 0.5f, 2f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f},
		/*ICE*/new float[] { 1f, 2f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f},
		/*DRA*/new float[] { 1f, 1f, 1f, 1f, 1f, 2f, 0.5f, 0.5f, 0.5f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f, 2f, 2f, 1f},
		/*POI*/new float[] { 1f, 0.5f, 1f, 1f, 2f, 0.5f, 1f, 1f, 0.5f, 1f, 1f, 2f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f, 0.5f},
	};

	public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
	{
		if(attackType == PokemonType.None || defenseType == PokemonType.None)
		{
			return 1;
		}

		int row = (int)defenseType - 1;
		int col = (int)attackType - 1;

		return chart[row][col];
	}
}