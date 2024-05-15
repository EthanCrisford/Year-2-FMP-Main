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
    [SerializeField] ValuePool lifePool;

    private void Start()
    {
        attributes = new AttributeGroup();
        attributes.Initialisation();

        stats = new StatGroup();
        stats.Initisialisation();

        lifePool = new ValuePool(stats.Get(Stats.Life));
    }

    public void TakeDamage(int damage)
    {
        damage = ApplyDefence(damage);

        lifePool.currentValue -= damage;

        Debug.Log("life pool" + lifePool.currentValue.ToString());

        CheckDeath();
    }

    private int ApplyDefence(int damage)
    {
        damage -= stats.Get(Stats.Armour).value;

        if (damage <= 0)
        {
            damage = 1;
        }

        return damage;
    }

    private void CheckDeath()
    {
        if (lifePool.currentValue <= 0)
        {
            Debug.Log("Enemy is dead");
        }
    }

    public StatsValue TakeStats(Stats statToGet)
    {
        return stats.Get(statToGet);
    }
}

public class ValuePool
{
    public int currentValue;
    public StatsValue maxValue;

    public ValuePool(StatsValue maxValue)
    {
        this.maxValue = maxValue;
        this.currentValue = maxValue.value;
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
