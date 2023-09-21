using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Character
{
    public string Name;
    public CharacterType Type;
    public int Level;
    public float CurrentExpPercentage;
    public List<Item> Inventory;

    public Character(string name, CharacterType type, int level, float currentExpPercentage, List<Item> inventory)
    {
        Name = name;
        Type = type;
        Level = level;
        CurrentExpPercentage = currentExpPercentage;
        Inventory = inventory;
    }
}

public enum CharacterType
{
    Warrior,
    Mage,
    Rogue
}

[Serializable]
public class Item
{
    public string Name;
    public string Type;

    public Item(string name, string type)
    {
        Name = name;
        Type = type;
    }
}