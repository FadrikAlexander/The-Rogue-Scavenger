using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New ShipTractorBeam", menuName = "New ShipTractorBeam")]
public class ShipTractorBeam : ScriptableObject
{
    public string ComponentName;
    public Sprite ComponentArt;

    public int TractorRange;
    public float TractorSpeed;
    public int StorageSpace;

    public float PowerConsumption;
    public float RotationSpeed;


    public string GetAsString()
    {
        string s = "Tractor Range: " + TractorRange + "\nTractor Speed: " + TractorSpeed + "\nStorage Space: " + StorageSpace + "\n";
        s += "PowerCons.: " + PowerConsumption + "\nRotation Speed: " + RotationSpeed;
        return s;
    }
}

