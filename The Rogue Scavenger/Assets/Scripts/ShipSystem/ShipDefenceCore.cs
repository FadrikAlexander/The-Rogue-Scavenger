using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New ShipDefenceCore", menuName = "New ShipDefenceCore")]
public class ShipDefenceCore : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentArt;

    public float Hullhealth;
    public float ShieldPower;

    public float ShieldPowerRechargeSpeed;
    public float ShieldPowerRechargeSpeedAfterHit;
    public float ShieldPowerRechargeAmount;

    public string GetAsString()
    {
        string s = "Hullhealth: " + Hullhealth + "\nShieldPower: " + ShieldPower + "\n";
        s += "Recharge Speed: " + ShieldPowerRechargeSpeed + "\nRecharge Speed AfterHit: " + ShieldPowerRechargeSpeedAfterHit + "\nRecharge Amount: " + ShieldPowerRechargeAmount;
        return s;
    }
}
