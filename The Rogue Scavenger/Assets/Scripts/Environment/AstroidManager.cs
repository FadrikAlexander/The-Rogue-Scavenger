using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidManager : MonoBehaviour
{

    [SerializeField]
    List<Sprite> AstroidsSprites;

    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = AstroidsSprites[Random.Range(0, AstroidsSprites.Count)];
        gameObject.AddComponent<PolygonCollider2D>();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * Random.Range(0, 10));
    }
}
