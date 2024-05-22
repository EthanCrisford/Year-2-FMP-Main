using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public enum Stats
{
    Life,
    Damage,
    Armour,
    AttackSpeed,
    MoveSpeed
}

public class Character : MonoBehaviour
{
    [SerializeField] AttributeGroup attributes;
    [SerializeField] StatGroup stats;
    public GameObject target;
    public ValuePool lifePool;
    //public AnimationHandler enemyTarget;
    public bool isDead;
    Character character;
    Animator animator;

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

        //Debug.Log("life pool" + lifePool.currentValue.ToString());

        CheckDeath();
    }

    private void CheckDeath()
    {
        if (lifePool.currentValue <= 0)
        {
            isDead = true;
            animator.SetBool("Dead", character.isDead);
        }

        if (lifePool.currentValue > 0 && (gameObject.tag == "Player"))
        {
            SceneManager.LoadScene("Death");
        }
    }

    private int ApplyDefence(int damage)
    {
        damage -= stats.Get(Stats.Armour).integer_value;

        if (damage <= 0)
        {
            damage = 1;
        }

        return damage;
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
        this.currentValue = maxValue.integer_value;
    }
}

[Serializable]
public class StatsValue
{
    public Stats statType;
    public bool typeFloat;
    public int integer_value;
    public float float_value;

    public StatsValue(Stats statType, int value)
    {
        this.statType = statType;
        this.integer_value = value;
    }

    public StatsValue(Stats statType, float float_value)
    {
        this.statType = statType;
        this.float_value = float_value;
        typeFloat = true;
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
        stats.Add(new StatsValue(Stats.AttackSpeed, 1));
        stats.Add(new StatsValue(Stats.MoveSpeed, 1));
    }

    internal StatsValue Get(Stats statToGet)
    {
        int val = (int)statToGet;

        //Debug.Log("list size=" + stats.Count);
        //Debug.Log("stg=" + val);
        return stats[val];
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
