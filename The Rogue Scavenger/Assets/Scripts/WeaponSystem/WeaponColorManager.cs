using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class WeaponColorManager : MonoBehaviour
{
    //This Class will take the colors of the weapon core
    [SerializeField]
    List<Color> CoreTypeColor;

    public Color GetCoreTypeColor(WeaponCoreType WCT)
    {
        return CoreTypeColor[(int)WCT];
    }

}
