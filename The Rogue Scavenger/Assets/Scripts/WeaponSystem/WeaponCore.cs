using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New WeaponCore", menuName = "New WeaponCore")]
public class WeaponCore : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentArt;

    public WeaponCoreType CoreType;
    public int CoreLevel;

    //public float Damage;

    public string GetAsString()
    {
        string s = "CoreType: " + CoreType + "\nCoreLevel: " + CoreLevel;
        return s;
    }
}