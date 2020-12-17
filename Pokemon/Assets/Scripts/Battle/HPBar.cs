using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
	//Objet contenant la barre de vie du pokémon
    [SerializeField] GameObject health;

    public void SetHP(float hpNormalized)
    {
    	//La barre de vie diminue selon le paramètre envoyé dans cette fonction
    	health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    public IEnumerator SetHPSmooth(float newHP)
    {
    	float curHP = health.transform.localScale.x;
    	float changeAnt = curHP - newHP;

    	while(curHP - newHP > Mathf.Epsilon)
    	{
    		curHP -= changeAnt * Time.deltaTime;
    		health.transform.localScale = new Vector3(curHP, 1f);
    		yield return null;
    	}
    	health.transform.localScale = new Vector3(newHP, 1f);
    }
}
