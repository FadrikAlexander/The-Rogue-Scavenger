using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystemManager : MonoBehaviour
{
    [SerializeField]
    WeaponBarrel weaponBarrel;

    [SerializeField]
    WeaponCore weaponCore;

    [SerializeField]
    WeaponReactor weaponReactor;

    WeaponTurretSystem weaponTurretSystem;
    WeaponShootingSystem weaponShootingSystem;
    WeaponReactorSystem weaponReactorSystem;

    WeaponColorManager weaponColorManager;

    [SerializeField]
    ShipCoreSystem shipCoreSystem;

    bool Activated;

    void Start()
    {
        weaponTurretSystem = GetComponentInChildren<WeaponTurretSystem>();
        weaponShootingSystem = GetComponentInChildren<WeaponShootingSystem>();
        weaponReactorSystem = GetComponentInChildren<WeaponReactorSystem>();

        weaponColorManager = FindObjectOfType<WeaponColorManager>();

        ConfigureWeapon();

        Activated = true;
    }

    void Update()
    {
        if (Activated)
        {
            if (Input.GetMouseButton(0))
            {
                weaponShootingSystem.StartShooting();
                weaponReactorSystem.Shooting(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                weaponShootingSystem.StopShooting();
                weaponReactorSystem.Shooting(false);
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Over");
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Boom");
        }
    }


    void ConfigureWeapon()
    {
        weaponTurretSystem.CofigureTurret(weaponCore.CoreType, weaponReactor.WeaponRotation, weaponCore.ComponentArt);

        weaponShootingSystem.CofigureBarrel(weaponCore.CoreType,
                                            weaponBarrel.ComponentArt,
                                            weaponBarrel.BulletSpeed,
                                            weaponBarrel.Bullet,
                                            weaponReactor.RateOfFire,
                                            weaponBarrel.PowerConsumptionPerShot,
                                            this
                                            );

        weaponReactorSystem.CofigureReactor(weaponReactor.PowerStorage, weaponReactor.PowerRechargeSpeed, weaponReactor.PowerRechargeAmount,this
                                            );
    }

    public bool CanShoot(float PowerConsumptionPerShot)
    {
        return weaponReactorSystem.CanShoot(PowerConsumptionPerShot);
    }

    public void ShotFired(float PowerConsumptionPerShot)
    {
        weaponReactorSystem.ShotFired(PowerConsumptionPerShot);
    }

    public void DisableActivateWeapon()
    {
        Activated = !Activated;
        weaponTurretSystem.DisableActivateTurret();
    }

    public void SetTarget(bool Target,Vector2 TargetPosition)
    {
        weaponTurretSystem.setTarget(TargetPosition, Target);
    }

    public bool requestPower(float power)
    {
        return shipCoreSystem.RequestPower(power);
    }

    public WeaponBarrel GetWeaponBarrel()
    {
        return weaponBarrel;
    }
    public WeaponCore GetWeaponCore()
    {
        return weaponCore;
    }
    public WeaponReactor GetWeaponReactor()
    {
        return weaponReactor;
    }
}
