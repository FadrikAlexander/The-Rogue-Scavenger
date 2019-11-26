# The Rogue Scavenger

The Rogue Scavenger is a Free Unity Asset that can create an infinite number of ships by changing the parts on each system, also contains a thruster-based movement and central power management.

The bundle contains:

- Thurster-based Movement [ShipMovement.cs and ThrusterController.cs]

- Ship System Manager [ShipSystemManager.cs]
  This manager takes 4 scriptable objects in the start of the game
    1-ShipCore.cs
    2-ShipEngine.cs
    3-ShipDefenceCore.cs
    4-ShipTractorBeam.cs
  
- Ship Weapon System [WeaponSystemManager.cs]
  This manager takes 3 scriptable objects in the start of the game
    1-WeaponCore.cs
    2-WeaponReactor.cs
    3-WeaponBarrel.cs
    
- Ship Tractor System [TractorBeamTurretSystem.cs] with 1 scriptable object [TractorBeamBarrel.cs]
    
Tractor Beam System is controlled by pressing "Space".
The UI can be activated by pressing 1 or 2 for each system.
and also you can target astroids by pressing with the "Right mouse button" on them or disable a gun doing the same.

PS: All scripts and art are free to use with no copyrights.
