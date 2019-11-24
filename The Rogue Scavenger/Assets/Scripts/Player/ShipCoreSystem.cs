using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCoreSystem : MonoBehaviour
{
    float MaxShipPower;
    float currentShipPower;
    ShipUIController shipUIController;

    void Awake()
    {
        shipUIController = FindObjectOfType<ShipUIController>();
    }

    public void config(float MaxShipPower)
    {
        this.MaxShipPower = MaxShipPower;
        currentShipPower = MaxShipPower;
        ChangePowerBar();
    }

    public bool RequestPower(float power)
    {
        if (currentShipPower >= power)
        {
            currentShipPower -= power;
            ChangePowerBar();
            return true;
        }
        else
            return false;
    }

    void ChangePowerBar()
    {
        shipUIController.ChangeSlider('P',(currentShipPower / MaxShipPower));
    }
}
