using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSystemUI : MonoBehaviour
{
    [SerializeField]
    WeaponSystemManager[] weaponSystemManagers;

    [SerializeField]
    List<TextMeshProUGUI> WeaponBarrelName;
    [SerializeField]
    List<TextMeshProUGUI> WeaponBarrelDetails;
    [SerializeField]
    List<Image> WeaponBulletsDetails;
    [SerializeField]
    List<TextMeshProUGUI> WeaponCoreName;
    [SerializeField]
    List<TextMeshProUGUI> WeaponCoreDetails;
    [SerializeField]
    List<Image> WeaponCoreType;
    [SerializeField]
    List<TextMeshProUGUI> WeaponReactorName;
    [SerializeField]
    List<TextMeshProUGUI> WeaponReactorDetails;

    WeaponColorManager weaponColorManager;

    [SerializeField]
    GameObject WeaponUIPanel;

    void Start()
    {
        weaponSystemManagers = FindObjectsOfType<WeaponSystemManager>();
        weaponColorManager = FindObjectOfType<WeaponColorManager>();
        WeaponUIPanel.SetActive(true);
        SetWeaponsUI();
        WeaponUIPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponUIPanel.SetActive(!WeaponUIPanel.active);
        }
    }

    public void SetWeaponsUI()
    {
        int index = 0;
        foreach (WeaponSystemManager WSM in weaponSystemManagers)
        {
            WeaponBarrel weaponBarrel = WSM.GetWeaponBarrel();
            WeaponCore weaponCore = WSM.GetWeaponCore();
            WeaponReactor weaponReactor = WSM.GetWeaponReactor() ;

            WeaponBarrelName[index].text = weaponBarrel.ComponentName;
            WeaponBarrelDetails[index].text = weaponBarrel.GetAsString();
            WeaponBulletsDetails[index].sprite = weaponBarrel.ComponentArt;

            WeaponCoreName[index].text = weaponCore.ComponentName;
            WeaponCoreDetails[index].text = weaponCore.GetAsString();
            WeaponCoreType[index].color = weaponColorManager.GetCoreTypeColor(weaponCore.CoreType);

            WeaponReactorName[index].text = weaponReactor.ComponentName;
            WeaponReactorDetails[index].text = weaponReactor.GetAsString();

            index++;
        }
    }
}
