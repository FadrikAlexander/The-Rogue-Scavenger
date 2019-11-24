using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDefenceSystem : MonoBehaviour
{
    //[Add] the shield get hit and recharge effect maybe play with the color

    [SerializeField]
    GameObject Shield;
    float MaxShieldPower;
    float currentShieldPower;

    float ShieldPowerRechargeSpeed;
    float ShieldPowerRechargeAmount;
    float ShieldPowerRechargeSpeedAfterHit;
    bool IsFull = true;
    float timeToRecharge = 0;

    float MaxHullHealth;
    float currentHullHealth;

    ShipMovement shipMovement;
    ShipSystemManager shipSystemManager;
    ShipUIController shipUIController;
    ShipCoreSystem shipCoreSystem;

    bool ShieldPowerSwitch;

    void Awake()
    {
        shipMovement = GetComponent<ShipMovement>();
        shipSystemManager = GetComponent<ShipSystemManager>();
        shipUIController = GetComponent<ShipUIController>();
        shipCoreSystem = GetComponent<ShipCoreSystem>();
    }

    public void config(float MaxHullHealth, float MaxShieldPower,float ShieldPowerRechargeSpeed, float ShieldPowerRechargeAmount,float ShieldPowerRechargeSpeedAfterHit)
    {
        //HullHealth
        this.MaxHullHealth = MaxHullHealth;
        currentHullHealth = MaxHullHealth;
        IsFull = true;

        this.MaxShieldPower = MaxShieldPower;
        currentShieldPower = MaxShieldPower;
        shipUIController.setSliders(MaxHullHealth, MaxShieldPower);

        this.ShieldPowerRechargeSpeed = ShieldPowerRechargeSpeed;
        this.ShieldPowerRechargeAmount = ShieldPowerRechargeAmount;
        this.ShieldPowerRechargeSpeedAfterHit = ShieldPowerRechargeSpeedAfterHit;

        ShieldPowerSwitch = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ShieldPowerSwitch = !ShieldPowerSwitch;

        if (!IsFull && ShieldPowerSwitch)
            if (AddShieldPower())
                if(shipCoreSystem.RequestPower(ShieldPowerRechargeAmount))
                {
                    currentShieldPower += ShieldPowerRechargeAmount;
                    ModifyShield(true);
                    if (currentShieldPower > MaxShieldPower)
                    {
                        currentShieldPower = MaxShieldPower;
                        IsFull = true;
                    }
                    shipUIController.ChangeSlider('S', currentShieldPower);
                }

    }

    bool AddShieldPower()
    {
        if (timeToRecharge < Time.time)
        {
            timeToRecharge = Time.time + ShieldPowerRechargeSpeed;
            return true;
        }
        return false;
    }

    void GetHit(float damageTaken)
    {
        if (currentShieldPower > damageTaken)
            currentShieldPower -= damageTaken;
        else
            if (currentShieldPower == damageTaken)
            {
                currentShieldPower = 0;
                ModifyShield(false);
            }
            else
            {
                currentHullHealth -= damageTaken - currentShieldPower;
                currentShieldPower = 0;
                ModifyShield(false);

                if (currentHullHealth <= 0)
                    shipSystemManager.ShipDestroyed(); //[Modify] Add an EventSystem
            }

        shipUIController.ChangeSlider('H', currentHullHealth);
        shipUIController.ChangeSlider('S', currentShieldPower);

        if (currentShieldPower != MaxShieldPower)
        {

            //Add the Time before Recharging Again
            timeToRecharge = Time.time + ShieldPowerRechargeSpeedAfterHit;

            //StartTheRechargeProcess
            IsFull = false;
        }
    }

    public void ModifyShield(bool statue)
    {
        Shield.SetActive(statue);
    }

    //Hit Collider
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
        {
            shipMovement.GotHitByEnvironement();

            GetHit(2f);
        }
    }


}
