using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTractorBeamSystem : MonoBehaviour
{
    int TractorRange;
    float TractorSpeed;
    
    int StorageSpace;
    int CurrentStorageSpace;

    float PowerConsumption;
    float RotationSpeed;

    bool Activated=false;

    [SerializeField]
    KeyCode ActivateTractorBeam;

    TractorBeamTurretSystem tractorBeamTurretSystem;
    TractorBeamBarrel tractorBeamBarrel;

    ShipUIController shipUIController;

    void Start()
    {
        shipUIController = FindObjectOfType<ShipUIController>();
    }

    void Update()
    {
        if (Activated)
        {
            if (Input.GetKeyDown(ActivateTractorBeam))
                tractorBeamBarrel.Beam(!tractorBeamBarrel.GetStatue());
        }
    }
    
    public void AddItem(int ItemSize)
    {
        if (CheckStorage(ItemSize))
        {
            CurrentStorageSpace += ItemSize;
            shipUIController.ChangeSlider('M', (float)((float)CurrentStorageSpace / (float)StorageSpace));
        }
    }
    public bool CheckStorage(int ItemSize)
    {
        return CurrentStorageSpace + ItemSize < StorageSpace;
    }

    public void config(int TractorRange, int StorageSpace, float PowerConsumption, float RotationSpeed , float TractorSpeed)
    {
        this.TractorRange = TractorRange;
        this.TractorSpeed = TractorSpeed;

        this.StorageSpace = StorageSpace;
        CurrentStorageSpace = 0;
        shipUIController.ChangeSlider('M', (CurrentStorageSpace / StorageSpace));

        this.PowerConsumption = PowerConsumption;
        this.RotationSpeed = RotationSpeed;

        tractorBeamTurretSystem = GetComponentInChildren<TractorBeamTurretSystem>();
        tractorBeamTurretSystem.ConfigTurret(RotationSpeed);

        tractorBeamBarrel = GetComponentInChildren<TractorBeamBarrel>();
        tractorBeamBarrel.CofigureBarrel(PowerConsumption, TractorRange, TractorSpeed);

        Activated = false;
        DisableActivateTractor();
    }

    public void DisableActivateTractor()
    {
        Activated = !Activated;
        tractorBeamTurretSystem.DisableActivateTractor(Activated);
    }

    public GameObject GetCenter()
    {
        return tractorBeamBarrel.gameObject;
    }

    public float GetSpeed()
    {
        return TractorSpeed;
    }

    void OnTriggerEnter2D(Collider2D T)
    {
        if (T.gameObject.tag == "Item")
        {
            AddItem(T.gameObject.GetComponent<ItemManager>().GetItemSize());
            Destroy(T.gameObject);
        }
    }
}
