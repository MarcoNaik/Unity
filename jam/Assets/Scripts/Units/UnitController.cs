using System;
using DefaultNamespace;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public IUnit unit;
    
    public int hp;
    public int powerLevel;

    public GameObject player;

    private void Awake()
    {
        if(gameObject.CompareTag($"GathererUnit")) unit = new Gatherer(gameObject, player, powerLevel, hp);
        if(gameObject.CompareTag($"AttackUnit")) unit = new AttackUnit(gameObject, player, powerLevel, hp);
    }
}
