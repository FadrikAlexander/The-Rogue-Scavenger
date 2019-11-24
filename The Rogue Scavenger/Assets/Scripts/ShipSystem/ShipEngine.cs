using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New ShipEngine", menuName = "New ShipEngine")]
public class ShipEngine : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentArt;

    public float thrustPower;
    public int shipSpeed;

    public float thrustPowerConsumption;

    public string GetAsString()
    {
        string s = "shipSpeed: " + shipSpeed + "\nthrustPower: " + thrustPower + "\nThrustPowerCons.: " + thrustPowerConsumption;
        return s;
    }
}
