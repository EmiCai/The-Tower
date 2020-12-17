using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pokemon
{
	//On a forcément besoin des informations de base d'un pokémon pour le créer
    public Pokemon_base _base {get; set;}
    //Niveau du pokémon
    public int level {get; set;}

    //Liste des attaques du pokémons
    public List<Move> Moves {get; set;}
    //Point de vie du pokémon
    public int HP {get; set;}
    public Dictionary<Stat, int> Stats {get; private set;}
    public Dictionary<Stat, int> StatBoosts {get; private set;}
    public Queue<string> StatusChanges {get; private set;} = new Queue<string>();

    public Pokemon(Pokemon_base pbase, int plevel)
    {
    	_base = pbase;
    	level = plevel;

    	//Les HP du pokémon sont maximals à a création
    	HP = Mathf.FloorToInt(2*(_base.GetHp() * level) / 100f ) + 10;

    	//Créer une liste d'attaque qui est assigné au pokémon
    	Moves = new List<Move>();
    	//On apprend une nouvelle attaque au pokémon s'il atteint le niveau requis et s'il n'a pas déjà 4 attaques
    	foreach(var move in _base.GetLearnableMoves())
    	{
    		//Si le niveau du pokémon est supérieur au niveau qu'il faut avoir pour une attaque, alrs on lui assigne cette attaque
    		if(move.GetLevel() <= level)
    		{
    			Moves.Add(new Move(move.GetMoveBase()));
    		}
    		//On arrête de lui assigner des attaques s'il a déjà 4 attaques
    		if(Moves.Count >= 4)
    		{
    			break;
    		}
            
    	}
        CalculateStats();

        ResetStats();
    }










//-----------------------------------------------------------Stats-------------------------------------------------//
    public void ResetStats()
    {
        StatBoosts = new Dictionary<Stat, int>()
        {
            {Stat.Attack, 0},
            {Stat.Defense, 0},
            {Stat.SpAttack, 0},
            {Stat.SpDefense, 0},
            {Stat.Speed, 0}
        };
    }

    //Méthodes applicant les changements de stats
    public void ApplyBoost(List<StatBoost> statBoosts)
    {
        foreach(var statBoost in statBoosts)
        {
            var stat = statBoost.stat;
            var boost = statBoost.boost;

            StatBoosts[stat] = Mathf.Clamp(StatBoosts[stat] + boost, -6, 6);
            if(boost == 1)
            StatusChanges.Enqueue($"{stat} de {_base.GetName()} augmente!");
            else if(boost == 2)
            StatusChanges.Enqueue($"{stat} de {_base.GetName()} augmente beaucoup!");
            else if(boost == -1)
            StatusChanges.Enqueue($"{stat} de {_base.GetName()} baisse!");
            else if(boost == -2)
            StatusChanges.Enqueue($"{stat} de {_base.GetName()} baisse beaucoup!");
        }
    }

    public void CalculateStats()
    {
        Stats = new Dictionary<Stat, int>();
        Stats.Add(Stat.Attack, Mathf.FloorToInt(2*(_base.GetAttack() * level) / 100f ) + 5);
        Stats.Add(Stat.Defense, Mathf.FloorToInt(2*(_base.GetDefense() * level) / 100f ) + 5);
        Stats.Add(Stat.SpAttack, Mathf.FloorToInt(2*(_base.GetSpAttack() * level) / 100f ) + 5);
        Stats.Add(Stat.SpDefense, Mathf.FloorToInt(2*(_base.GetSpDefense() * level) / 100f ) + 5);
        Stats.Add(Stat.Speed, Mathf.FloorToInt(2*(_base.GetSpeed() * level) / 100f ) + 5);
    }

    public int GetStat(Stat stat)
    {
        int statVal = Stats[stat];

        //Boost
        int boost = StatBoosts[stat];
        var boostValues = new float[] {1f, 1.5f, 2f, 2.5f, 3f, 3.5f, 4f};

        if(boost >= 0)
        {
            statVal = Mathf.FloorToInt(statVal * boostValues[boost]);
        }
        else
        {
            statVal = Mathf.FloorToInt(statVal / boostValues[-boost]);
        }

        return statVal;
    }

    public void OnBattleOver()
    {
        ResetStats();
    }
//-----------------------------------------------------------Fin Stats-------------------------------------------------//







//-----------------------------------------------------------Getters-------------------------------------------------//
    public int GetAttack()
    {
    	return GetStat(Stat.Attack);
    }
    public int GetDefense()
    {
    	return GetStat(Stat.Defense);
    }
    public int GetspAttack()
    {
    	return GetStat(Stat.SpAttack);
    }
    public int GetspDefense()
    {
    	return GetStat(Stat.SpDefense);
    }
    public int GetSpeed()
    {
    	return GetStat(Stat.Speed);
    }
    public int GetHp()
    {
        return HP;
    }
//-----------------------------------------------------------Fin Getters-------------------------------------------------//




//-----------------------------------------------------------Dommages-------------------------------------------------//
    public DamageDetails TakeDamage(Move move, Pokemon attacker)
    {
        float critical = 1f;

        if(Random.value * 100f <= 6.25f)
            critical = 2f;

        float type = TypeChart.GetEffectiveness(move.Base.GetType1(), this._base.GetType1()) * TypeChart.GetEffectiveness(move.Base.GetType1(), this._base.GetType2()) * TypeChart.GetEffectiveness(move.Base.GetType1(), this._base.GetType3());

        var damageDetails = new DamageDetails()
        {
            TypeEffectiveness = type,
            Critical = critical,
            ko = false
        };

        float modifier = type * critical;
        float a = (float) ((0.4 * attacker.level) + 2);
        float d = 0f;
        if(move.Base.GetCategory() == MoveCategory.Physical)
        d = (float) (a * move.Base.GetPower() * (float)attacker.GetAttack() / (GetDefense() *50)) + 2;
        else if(move.Base.GetCategory() == MoveCategory.Special)
        d = (float) (a * move.Base.GetPower() * (float)attacker.GetspAttack() / (GetspDefense() *50)) + 2;

        int damage = Mathf.FloorToInt(d * modifier);
        HP -= damage;
        if(HP <= 0)
        {
            HP = 0;
            damageDetails.ko = true;

        }
        return damageDetails;
    }

    public Move GetEnnemyMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
//-----------------------------------------------------------Fin Dommages-------------------------------------------------//

}

public class DamageDetails
{
    public bool ko {get; set;}

    public float Critical {get; set;}

    public float TypeEffectiveness {get; set;}
}