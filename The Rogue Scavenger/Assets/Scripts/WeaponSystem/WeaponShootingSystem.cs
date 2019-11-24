using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class WeaponShootingSystem : MonoBehaviour
{
    [SerializeField]
    GameObject bulletHole;

    SpriteRenderer BarrelSprite;
    WeaponColorManager weaponColorManager;
    WeaponSystemManager weaponSystemManager;

    WeaponCoreType CoreType;

    float BulletSpeed;
    Color BulletColor;
    PrefabType Bullet;

    float PowerConsumptionPerShot;

    float RateOfFire;
    bool isShooting = false;

    MasterPool masterPool;

    void Awake()
    {
        BarrelSprite = GetComponent<SpriteRenderer>();

        weaponColorManager = FindObjectOfType<WeaponColorManager>();
        masterPool = FindObjectOfType<MasterPool>();
    }

    void Update()
    {
        if (isShooting)
            if(weaponSystemManager.CanShoot(PowerConsumptionPerShot))
                if (AbleToFire())
                    Shoot();
    }

    public void CofigureBarrel(WeaponCoreType CoreType, Sprite BarrelSprite, float BulletSpeed, PrefabType Bullet, float RateOfFire, float PowerConsumptionPerShot, WeaponSystemManager weaponSystemManager)
    {
        this.BarrelSprite.sprite = BarrelSprite;
        this.CoreType = CoreType;

        this.BulletSpeed = BulletSpeed;
        this.BulletColor = weaponColorManager.GetCoreTypeColor(CoreType);
        this.Bullet = Bullet;

        this.RateOfFire = RateOfFire;
        this.PowerConsumptionPerShot = PowerConsumptionPerShot;

        this.weaponSystemManager = weaponSystemManager;
    }

    public void StartShooting()
    {
        isShooting = true;
    }
    public void StopShooting()
    {
        isShooting = false;
    }

    public void Shoot()
    {
        GameObject bulletGameObject = masterPool.Get(Bullet);
        bulletGameObject.transform.position = bulletHole.transform.position;
        bulletGameObject.transform.rotation = bulletHole.transform.rotation;

        if (bulletGameObject.GetComponent<Bullet>() != null)
            bulletGameObject.GetComponent<Bullet>().StartBullet(CoreType, BulletColor, BulletSpeed);
        else
        {
            Bullet[] bullets = bulletGameObject.GetComponentsInChildren<Bullet>();
            foreach(Bullet b in bullets)
                b.StartBullet(CoreType, BulletColor, BulletSpeed);
        }

        weaponSystemManager.ShotFired(PowerConsumptionPerShot);
    }

    float timeToFire = 0;

    bool AbleToFire()
    {
        if (timeToFire < Time.time)
        {
            timeToFire = Time.time + RateOfFire;
            return true;
        }
        return false;
    }
}
