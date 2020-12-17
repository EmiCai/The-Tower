using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infos : MonoBehaviour
{
	//Informations affichées lors du combat pokémon
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Pokemon _pokemon;
    int fullHP;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;

    	levelText.text = "Niv " + pokemon.level;
    	nameText.text = pokemon._base.GetName();
        fullHP = pokemon.HP;
    	hpBar.SetHP((float) pokemon.HP/fullHP);
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float) _pokemon.HP/fullHP);
    }
}
