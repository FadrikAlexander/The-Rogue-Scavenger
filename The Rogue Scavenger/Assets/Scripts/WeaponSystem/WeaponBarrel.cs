using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New WeaponBarrel", menuName = "New WeaponBarrel")]
public class WeaponBarrel : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentArt;

    public float DamageMultipler;
    public PrefabType Bullet;
    public float BulletSpeed;

    public float PowerConsumptionPerShot;

    public string GetAsString()
    {
        string s = "DamageMultipler: " + DamageMultipler +"\nBulletSpeed: "+ BulletSpeed +"\nPowerCons.: " + PowerConsumptionPerShot;
        return s;
    }
}