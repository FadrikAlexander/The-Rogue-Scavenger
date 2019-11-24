using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponReactorSystem : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer PowerBarSprite;

    float maxPower;
    float currentPower;
    float PowerRechargeSpeed;
    float PowerRechargeAmount;
    bool IsFull = true;
    bool IsShooting = false;

    float PowerBarSpriteHeight;

    WeaponSystemManager weaponSystemManager;

    void Awake()
    {
        PowerBarSpriteHeight = PowerBarSprite.size.y;
    }

    void Update()
    {
        if(!IsShooting)
            if(!IsFull)
                if (AddPower())
                    if (weaponSystemManager.requestPower(PowerRechargeAmount))
                    {
                        currentPower += PowerRechargeAmount;
                        ChangePowerBar();
                        if (currentPower > maxPower)
                        {
                            currentPower = maxPower;
                            IsFull = true;
                        }
                    }
    }

    public void CofigureReactor(float maxPower, float PowerRechargeSpeed, float PowerRechargeAmount,WeaponSystemManager weaponSystemManager)
    {
        this.maxPower = maxPower;
        currentPower = maxPower;
        IsFull = true;
        IsShooting = false;

        this.PowerRechargeSpeed = PowerRechargeSpeed;
        this.PowerRechargeAmount = PowerRechargeAmount;

        this.weaponSystemManager = weaponSystemManager;
    }

    public void ShotFired(float PowerConsumptionPerShot)
    {
        currentPower -= PowerConsumptionPerShot;
        ChangePowerBar();
        IsFull = false;
    }

    public bool CanShoot(float PowerConsumptionPerShot)
    {

        if (maxPower < PowerConsumptionPerShot)
            return false;

        if (currentPower >= PowerConsumptionPerShot)       
            return true;
        else
            return false;
    }

    float timeToRecharge = 0;
    bool AddPower()
    {
        if (timeToRecharge < Time.time)
        {
            timeToRecharge = Time.time + PowerRechargeSpeed;
            return true;
        }
        return false;
    }

    void ChangePowerBar()
    {
        PowerBarSprite.size = new Vector2(PowerBarSprite.size.x, (currentPower * PowerBarSpriteHeight / maxPower));
    }

    public void Shooting(bool IsShooting)
    {
        this.IsShooting = IsShooting;
    }
}
