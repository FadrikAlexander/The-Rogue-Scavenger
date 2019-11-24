using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponReactor", menuName = "New WeaponReactor")]
public class WeaponReactor : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentArt;

    public float Damage;
    public float RateOfFire;

    public float PowerStorage;
    public float PowerRechargeSpeed;
    public float PowerRechargeAmount;

    public float WeaponRotation;

    public string GetAsString()
    {
        string s = "Damage: " + Damage + "\nRateOfFire: " + RateOfFire + "\nWeaponRotation: " + WeaponRotation + "\n";
        s += "Power Storage: " + PowerStorage + "\nRecharge Speed: " + PowerRechargeSpeed + "\nRecharge Amount: " + PowerRechargeAmount;
        return s;
    }
}