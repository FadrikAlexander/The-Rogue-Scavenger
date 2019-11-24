using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Bullet : MonoBehaviour
{
    SpriteRenderer bulletRenderer;

    float Speed;
    WeaponCoreType CoreType;

    bool StartMoving = false;

    public void StartBullet(WeaponCoreType CoreType, Color BulletColor, float Speed)
    {
        bulletRenderer = GetComponent<SpriteRenderer>();
        bulletRenderer.color = BulletColor;

        this.Speed = Speed;
        this.CoreType = CoreType;

        StartCoroutine(AcBullet());
        StartMoving = true;

        Invoke("DestroyBullet", 5f);
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (StartMoving)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }

    IEnumerator AcBullet()
    {
        Speed -= 7.5f;
        int i=10;
        while(i>0)
        {
            yield return new WaitForSeconds(0.05f);
            Speed += 0.75f;
            i--;
        }
    }
}
