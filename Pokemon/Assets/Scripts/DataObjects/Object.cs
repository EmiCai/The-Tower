using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Object")]

public class Object : ScriptableObject
{
    //Information de l'objet
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite sprite;
    [SerializeField] int price;

    public string GetName()
    {
    	return name;
    }
    public string GetDescription()
    {
    	return description;
    }
    public Sprite GetSprite()
    {
    	return sprite;
    }
    public int GetPrice()
    {
    	return price;
    }
}
