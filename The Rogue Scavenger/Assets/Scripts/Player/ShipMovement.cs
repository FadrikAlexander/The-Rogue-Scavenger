using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    ThrusterController thrusterController;
    ShipUIController shipUIController;
    ShipSystemManager shipSystemManager;
    ShipCoreSystem shipCoreSystem;

    Vector2 movementVector;

    bool ThrusterVerticalLock;
    bool ThrusterHorizontalLock;
    bool canMove;

    float ShipSpeed;
    float thrustPower;
    float thrustPowerConsumption;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        shipUIController = GetComponent<ShipUIController>();
        shipSystemManager = GetComponent<ShipSystemManager>();
        thrusterController = GetComponentInChildren<ThrusterController>();
        shipCoreSystem = GetComponent<ShipCoreSystem>();

        ThrusterVerticalLock = false ;
        ThrusterHorizontalLock = false;
    }


    public void config(float ShipSpeed, float thrustPower, float thrustPowerConsumption)
    {
        this.ShipSpeed = ShipSpeed;
        this.thrustPower = thrustPower;
        this.thrustPowerConsumption = thrustPowerConsumption;
        canMove = true;
    }


    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (ThrusterVerticalLock)
            {
                if (TimetoModifyPowerY())
                {
                    if (shipCoreSystem.RequestPower(thrustPower * thrustPowerConsumption))
                    {
                        ThrusterVerticalLock = false;
                        thrusterController.StartThrusters('V', Input.GetAxisRaw("Vertical") > 0 ? 1 : -1);
                        ModifyYThrusterPower();
                    }
                }
            }
        }
        else
        {
            ThrusterVerticalLock = true;
            thrusterController.TurnOffAllThrusters('V');
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (ThrusterHorizontalLock)
            {
                if (TimetoModifyPowerX())
                {
                    if (shipCoreSystem.RequestPower(thrustPower * thrustPowerConsumption))
                    {
                        ThrusterHorizontalLock = false;
                        thrusterController.StartThrusters('H', Input.GetAxisRaw("Horizontal") > 0 ? 1 : -1);
                        ModifyXThrusterPower();
                    }
                }
            }
        }
        else
        {
            ThrusterHorizontalLock = true;
            thrusterController.TurnOffAllThrusters('H');
        }
    }

    void FixedUpdate()
    {
        shipUIController.ChangeSpeed(movementVector);
        rigidbody2D.MovePosition(rigidbody2D.position + movementVector * ShipSpeed * Time.fixedDeltaTime);
    }

    #region ThrusterMovement

    void ModifyYThrusterPower()
    {
        float power =0 ;

        power = Input.GetAxisRaw("Vertical") * thrustPower;

        // 2  Because of the big engine in the back 
        movementVector.y = Mathf.Clamp(movementVector.y + power, -1, 2);
        ThrusterVerticalLock = true;
    }

    void ModifyXThrusterPower()
    {
        float power = 0;
        
        power = Input.GetAxisRaw("Horizontal") * thrustPower;

        movementVector.x = Mathf.Clamp(movementVector.x + power, -1, 1);
        ThrusterHorizontalLock = true;
    }

    float timeSinceLastModifyThrustY=0;
    float timeSinceLastModifyThrustX = 0;

    bool TimetoModifyPowerY()
    {
        if (timeSinceLastModifyThrustY < Time.time)
        {
            timeSinceLastModifyThrustY = Time.time + 0.35f;
            return true;
        }
        return false;
    }

    bool TimetoModifyPowerX()
    {
        if (timeSinceLastModifyThrustX < Time.time)
        {
            timeSinceLastModifyThrustX = Time.time + 0.35f;
            return true;
        }
        return false;
    }

    void StopAllThrusters()
    {
        ThrusterHorizontalLock = true;
        thrusterController.TurnOffAllThrusters('H');
        ThrusterVerticalLock = true;
        thrusterController.TurnOffAllThrusters('V');
    }

    #endregion

    float timeToRecharge = 0;
    bool RemovePower()
    {
        if (timeToRecharge < Time.time)
        {
            timeToRecharge = Time.time + 1f;
            return true;
        }
        return false;
    }
    float calculatePower()
    {
        float power = 0;
        power += Mathf.Abs(movementVector.x);
        power += Mathf.Abs(movementVector.y);

        return power * thrustPowerConsumption;
    }
    public void GotHitByEnvironement()
    {
        StopAllThrusters();
        movementVector.x = movementVector.x / 3 * -1;
        movementVector.y = movementVector.y / 3 * -1;
    }
}
