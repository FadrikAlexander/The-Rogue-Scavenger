using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipSystemUI : MonoBehaviour
{
    [SerializeField]
    ShipSystemManager shipSystemManager;

    [SerializeField]
    List<TextMeshProUGUI> Titles;
    [SerializeField]
    List<TextMeshProUGUI> Details;

    [SerializeField]
    GameObject shipSystemUIPanel;
    
    void Start()
    {
        shipSystemUIPanel.SetActive(true);
        setSystemUI();
        shipSystemUIPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shipSystemUIPanel.SetActive(!shipSystemUIPanel.active);
        }
    }

    void setSystemUI()
    {
        ShipCore shipCore = shipSystemManager.GetShipCore();
        ShipEngine shipEngine = shipSystemManager.GetShipEngine();
        ShipDefenceCore shipDefenceCore = shipSystemManager.GetShipDefenceCore();
        ShipTractorBeam shipTractorBeam = shipSystemManager.GetShipTractorBeam();
        

        //DefenceSystem
        Titles[0].text = shipDefenceCore.ComponentName;
        Details[0].text = shipDefenceCore.GetAsString();

        //Engine
        Titles[1].text = shipEngine.ComponentName;
        Details[1].text = shipEngine.GetAsString();

        //Core
        Titles[2].text = shipCore.ComponentName;
        Details[2].text = shipCore.GetAsString();

        //Tractor Beam
        Titles[3].text = shipTractorBeam.ComponentName;
        Details[3].text = shipTractorBeam.GetAsString(); 
    }
}
