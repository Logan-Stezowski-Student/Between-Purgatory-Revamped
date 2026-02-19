using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy_SO : ScriptableObject
{
    public int health;

    public int damage;

    public bool isBasic;

    public bool isProjectile;

    public bool isTank;
}
