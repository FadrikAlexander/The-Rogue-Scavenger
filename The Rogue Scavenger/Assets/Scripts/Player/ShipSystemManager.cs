using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystemManager : MonoBehaviour
{
    [SerializeField]
    ShipCore shipCore;

    [SerializeField]
    ShipDefenceCore shipDefenceCore;

    [SerializeField]
    ShipEngine shipEngine;

    [SerializeField]
    ShipTractorBeam shipTractorBeam;

    GameStateController gameStateController;
    ShipDefenceSystem shipDefenceSystem;
    ShipMovement shipMovement;
    ShipCoreSystem shipCoreSystem;
    ShipTractorBeamSystem shipTractorBeamSystem;

    void Awake()
    {
        gameStateController = FindObjectOfType<GameStateController>();

        shipDefenceSystem = GetComponent<ShipDefenceSystem>();
        shipMovement = GetComponent<ShipMovement>();
        shipCoreSystem = GetComponent<ShipCoreSystem>();
        shipTractorBeamSystem = GetComponentInChildren<ShipTractorBeamSystem>();
    }

    void Start()
    {
        ConfigSystems();
    }

    public void ShipDestroyed()
    {
        gameStateController.GameOver();
    }

    void ConfigSystems()
    {
        shipDefenceSystem.config(shipDefenceCore.Hullhealth, shipDefenceCore.ShieldPower, shipDefenceCore.ShieldPowerRechargeSpeed, shipDefenceCore.ShieldPowerRechargeAmount, shipDefenceCore.ShieldPowerRechargeSpeedAfterHit);
        shipMovement.config(shipEngine.shipSpeed, shipEngine.thrustPower, shipEngine.thrustPowerConsumption);
        shipCoreSystem.config(shipCore.ShipPower);
        shipTractorBeamSystem.config(shipTractorBeam.TractorRange, shipTractorBeam.StorageSpace, shipTractorBeam.PowerConsumption, shipTractorBeam.RotationSpeed, shipTractorBeam.TractorSpeed);
    }

    public ShipEngine GetShipEngine()
    {
        return shipEngine;
    }
    public ShipDefenceCore GetShipDefenceCore()
    {
        return shipDefenceCore;
    }
    public ShipCore GetShipCore()
    {
        return shipCore;
    }
    public ShipTractorBeam GetShipTractorBeam()
    {
        return shipTractorBeam;
    }
}
