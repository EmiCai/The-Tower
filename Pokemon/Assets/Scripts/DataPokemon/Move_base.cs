using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Move")]

public class Move_base : ScriptableObject
{
    //Informations sur l'attaque
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;
    [SerializeField] int status;
    [SerializeField] MoveCategory category;
    [SerializeField] MoveEffects effects;
    [SerializeField] Target target;

    //Getter permettant de récupérer les informations sur l'attaque 
    public string GetName()
    {
    	return name;
    }
    public string GetDescription()
    {
    	return description;
    }
    public PokemonType GetType1()
    {
    	return type1;
    }
    public PokemonType GetType2()
    {
    	return type2;
    }
    public int GetPower()
    {
    	return power;
    }
    public int GetAccuracy()
    {
    	return accuracy;
    }
    public int GetPP()
    {
    	return pp;
    }
    public int GetStatus()
    {
    	return status;
    }
    public MoveCategory GetCategory()
    {
        return category;
    }
    public MoveEffects GetEffect()
    {
        return effects;
    }
    public Target GetTarget()
    {
        return target;
    }
}

[System.Serializable]
public class MoveEffects
{
    [SerializeField] List<StatBoost> boosts;

    public List<StatBoost> Boosts {get {return boosts;}} 
}

[System.Serializable]
public class StatBoost
{
    public Stat stat;
    public int boost;
}

public enum MoveCategory
{
    Physical, Special, Status
}

public enum Target
{
    Lanceur, Cible
}
