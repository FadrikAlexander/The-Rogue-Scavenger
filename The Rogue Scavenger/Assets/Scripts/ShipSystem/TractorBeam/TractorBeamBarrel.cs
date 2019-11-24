using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class TractorBeamBarrel : MonoBehaviour
{
    //BeamCollider
    [SerializeField]
    GameObject bulletHole;

    BoxCollider2D BeamCollider;

    [SerializeField]
    GameObject BeamObject;

    List<GameObject> Beams;
    int BeamsIndex = 0;

    float PowerConsumption;
    int Range;
    float BeamSpeed;

    bool isBeaming = false;

    ShipCoreSystem shipCoreSystem;

    void Awake()
    {
        shipCoreSystem = GetComponentInParent<ShipCoreSystem>();
        BeamCollider = bulletHole.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(isBeaming)
            if (!AbleToOperate())
            {
                Beam(false);
            }
    }

    public void Beam(bool BeamActive)
    {
        StopAllCoroutines();

        if (BeamActive)
            StartCoroutine(StartBeaming());
        else
            StartCoroutine(StopBeaming());

        isBeaming = BeamActive;
    }

    IEnumerator StartBeaming()
    {
        if (BeamsIndex < 0)
            BeamsIndex = 0;

        while (BeamsIndex < Beams.Count)
        {
            Beams[BeamsIndex].SetActive(true);
            ConfigureBeamCollider(BeamsIndex);
            BeamsIndex++;

            yield return new WaitForSeconds(BeamSpeed);
        }
    }
    IEnumerator StopBeaming()
    {
        if (BeamsIndex >= Beams.Count)
            BeamsIndex = Beams.Count - 1;

        while (BeamsIndex >= 0)
        {
            Beams[BeamsIndex].SetActive(false);
            ConfigureBeamCollider(BeamsIndex);
            BeamsIndex--;


            yield return new WaitForSeconds(BeamSpeed);
        }
    }

    void ConfigureBeamCollider(int index)
    {
        BeamCollider.offset = new Vector2(0, index * 2f);
        BeamCollider.size = new Vector2(2, index * 4f);
    }

    public void CofigureBarrel(float PowerConsumption, int Range, float BeamSpeed)
    {
        this.PowerConsumption = PowerConsumption;
        this.Range = Range;
        this.BeamSpeed = BeamSpeed;

        Beams = new List<GameObject>();
        CreateBeam();
    }

    public bool GetStatue()
    {
        return isBeaming;
    }

    void CreateBeam()
    {
        int numOfBeams = (int)(Range / 10);

        for (int i = 0; i < numOfBeams; i++)
        {
            GameObject beam = Instantiate(BeamObject, bulletHole.transform);

            beam.transform.position += new Vector3(0, i * 1f, 0);
            beam.transform.localScale += new Vector3(i * 0.2f, i * 0.2f, 0);

            Beams.Add(beam);
            beam.SetActive(false);
        }

    }
    
    float timeToOperate;

    bool AbleToOperate()
    {
        if (timeToOperate < Time.time)
        {
            timeToOperate = Time.time + 1f;
            return shipCoreSystem.RequestPower(PowerConsumption);
        }
        return true;
    }
}
