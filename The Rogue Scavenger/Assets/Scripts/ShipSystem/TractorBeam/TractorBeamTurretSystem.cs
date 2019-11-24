using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeamTurretSystem : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    float RotationSpeed = 0.5f;

    Vector2 StartPostion;
    bool Activated;
    bool isTargeting;

    void Awake()
    {
        StartPostion = transform.up;
        Activated = false;
    }

    void FixedUpdate()
    {
        if (Activated)
        {
            Vector2 MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 LookDir = new Vector2(MousePos.x - transform.position.x, MousePos.y - transform.position.y);
            transform.up = Vector2.LerpUnclamped(transform.up, LookDir, RotationSpeed * Time.deltaTime);
        }
        else
            transform.up = Vector2.LerpUnclamped(transform.up, StartPostion, RotationSpeed * 2 * Time.deltaTime);
    }

    public void ConfigTurret(float RotationSpeed)
    {
        this.RotationSpeed = RotationSpeed;
        Activated = true;
    }

    public void DisableActivateTractor(bool Activated)
    {
        this.Activated = Activated;
    }
}
