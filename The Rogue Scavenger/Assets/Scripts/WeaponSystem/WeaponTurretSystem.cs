using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class WeaponTurretSystem : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    float RotationSpeed = 0.5f;
    WeaponCoreType CoreType;

    [SerializeField]
    SpriteRenderer turretSpriteRenderer;
    WeaponColorManager weaponColorManager;

    Vector2 StartPostion;
    bool Activated;
    bool isTargeting;
    Vector2 TargetPosition;

    void Awake()
    {
        weaponColorManager = FindObjectOfType<WeaponColorManager>();

        StartPostion = transform.up;
        Activated = true;
        isTargeting = false;
    }

    void FixedUpdate()
    {
        if (Activated)
        {
            if(!isTargeting)
            {
                Vector2 MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector2 LookDir = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);

                transform.up = Vector2.LerpUnclamped(transform.up, LookDir, RotationSpeed * Time.deltaTime);
            }
            else
            {
                Vector2 LookDir = new Vector2(TargetPosition.x - transform.position.x, TargetPosition.y - transform.position.y);

                transform.up = Vector2.LerpUnclamped(transform.up, LookDir, RotationSpeed * Time.deltaTime);
            }
        }
        else
            transform.up = Vector2.LerpUnclamped(transform.up, StartPostion, RotationSpeed * 2 * Time.deltaTime);
    }

    public void DisableActivateTurret()
    {
        Activated = !Activated;
    }

    public void CofigureTurret(WeaponCoreType CoreType, float RotationSpeed,Sprite TurretSprite)
    {
        this.RotationSpeed = RotationSpeed;
        this.CoreType = CoreType;

        turretSpriteRenderer.color = weaponColorManager.GetCoreTypeColor(CoreType);
    }

    public void setTarget(Vector2 TargetPosition, bool isTarget)
    {
            if (isTarget)
            {
                isTargeting = true;
                this.TargetPosition = TargetPosition;
            }
            else
                isTargeting = false;
    }
}
