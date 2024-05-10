using System;
using System.Collections.Generic;
using UnityEngine;

public enum Stats
{
    Life,
    Damage,
    Armour
}
public class Character : MonoBehaviour
{
    [SerializeField] AttributeGroup attributes;
    [SerializeField] StatGroup stats;

    private void Start()
    {
        attributes = new AttributeGroup();
        attributes.Initialisation();

        stats = new StatGroup();
        stats.Initisialisation();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Ouch :" +  damage);
    }

    public StatsValue TakeStats(Stats statToGet)
    {
        return stats.Get(statToGet);
    }
}

[Serializable]
public class StatsValue
{
    public Stats statType;
    public int value;

    public StatsValue(Stats statType, int value)
    {
        this.statType = statType;
        this.value = value;
    }
}

[Serializable]
public class StatGroup
{
    public List<StatsValue> stats;

    public StatGroup()
    {
        stats = new List<StatsValue>();
    }

    public void Initisialisation()
    {
        stats.Add(new StatsValue(Stats.Life, 100));
        stats.Add(new StatsValue(Stats.Damage, 25));
        stats.Add(new StatsValue(Stats.Armour, 5));
    }

    internal StatsValue Get(Stats statToGet)
    {
        return stats[(int)statToGet]; 
    }
}

public enum Attribute
{
    Strength,
    Dexterity,
    Intelligence
}

[Serializable]
public class AttributeValue
{
    public Attribute attributeType;
    public int value;

    public AttributeValue(Attribute attributeType, int value = 0)
    {
        this.attributeType = attributeType; 
        this.value = value;
    }
}

[Serializable]
public class AttributeGroup
{
    public List<AttributeValue> attributeValues;

    public AttributeGroup()
    {
        attributeValues = new List<AttributeValue>();
    }

    public void Initialisation()
    {
        attributeValues.Add(new AttributeValue(Attribute.Strength));
        attributeValues.Add(new AttributeValue(Attribute.Dexterity));
        attributeValues.Add(new AttributeValue(Attribute.Intelligence));
    }
}
