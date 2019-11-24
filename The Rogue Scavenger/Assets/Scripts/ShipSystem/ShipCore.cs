using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New ShipCore", menuName = "New ShipCore")]
public class ShipCore : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentArt;

    public float ShipPower;

    public string GetAsString()
    {
        string s = "ShipPower: " + ShipPower;
        return s;
    }
}
