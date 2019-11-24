using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    LayerMask layerMaskTractor;

    [SerializeField]
    LayerMask layerMaskWeapon;

    [SerializeField]
    LayerMask layerMaskTarget;

    [SerializeField]
    WeaponSystemManager[] weaponSystemManagers;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Detect Weapons
            GameObject Object = MouseOver(layerMaskWeapon);
            if (Object != null)
            {
                DisableActivateWeapon(Object);
                return;
            }

            //Detect Tractor
            Object = MouseOver(layerMaskTractor);
            if (Object != null)
            {
                DisableActivateTractor(Object);
                return;
            }

            //Detect Targets
            GameObject Target = MouseOver(layerMaskTarget);
            setTargets(Target);
        }
    }

    GameObject MouseOver(LayerMask layerMask)
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);

        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        else
            return null;
    }

    void DisableActivateWeapon(GameObject weapon)
    {
        WeaponSystemManager weaponSystemManager = weapon.GetComponent<WeaponSystemManager>();
        if (weaponSystemManager == null)
            return;
        else
        {
            weaponSystemManager.DisableActivateWeapon();
        }
    }

    void DisableActivateTractor(GameObject Tractor)
    {
        ShipTractorBeamSystem shipTractorBeamSystem = Tractor.GetComponent<ShipTractorBeamSystem>();
        if (shipTractorBeamSystem == null)
            return;
        else
        {
            shipTractorBeamSystem.DisableActivateTractor();
        }
    }

    void setTargets(GameObject Target)
    {
        foreach (WeaponSystemManager WSM in weaponSystemManagers)
        {
            if (Target == null)
                WSM.SetTarget(false, Vector2.zero);
            else
                WSM.SetTarget(true, cam.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
