using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    [SerializeField]
    List<Sprite> ItemSprites;

    PolygonCollider2D PolyCol;
    Rigidbody2D rigidbody2D;

    GameObject TractorBeamCenter;
    bool isBeamed = false;
    float Speed = 0.5f;

    int ItemSize;

    ShipTractorBeamSystem shipTractorBeamSystem;

    bool BeamPlace = false;

    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = ItemSprites[Random.Range(0, ItemSprites.Count)];
        ItemSize = Random.Range(20, 25);

        gameObject.AddComponent<PolygonCollider2D>();
        PolyCol = GetComponent<PolygonCollider2D>();

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * Random.Range(0, 10));

        if (isBeamed)
        {
            if (!BeamPlace)
                if (Vector2.Distance(gameObject.transform.position, TractorBeamCenter.transform.position) > 3)
                {
                    isBeamed = false;
                    PolyCol.isTrigger = false;
                    rigidbody2D.WakeUp();
                }
                else
                    gameObject.transform.parent = TractorBeamCenter.gameObject.transform;

            transform.position = Vector3.LerpUnclamped(transform.position, TractorBeamCenter.transform.position, Speed * Time.fixedDeltaTime);
        }
    }

    public void Beaming(GameObject TractorBeamCenter, float Speed)
    {
        this.TractorBeamCenter = TractorBeamCenter;
        this.Speed = Speed*2;
    }

    void OnTriggerEnter2D(Collider2D T)
    {
        if (T.gameObject.tag == "Beam")
        {
            if (shipTractorBeamSystem == null)
            {
                shipTractorBeamSystem = T.GetComponentInParent<ShipTractorBeamSystem>();
                Beaming(shipTractorBeamSystem.GetCenter(), shipTractorBeamSystem.GetSpeed());
            }

            if (shipTractorBeamSystem.CheckStorage(ItemSize))
            {
                BeamPlace = true;
                PolyCol.isTrigger = true;
                rigidbody2D.Sleep();

                isBeamed = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D T)
    {
        if (T.gameObject.tag == "Beam")
        {
            if (Vector2.Distance(gameObject.transform.position, TractorBeamCenter.transform.position) > 2)
            {
                isBeamed = false;
                PolyCol.isTrigger = false;
                rigidbody2D.WakeUp();
            }
            BeamPlace = false;
        }
    }

    public int GetItemSize()
    {
        return ItemSize;
    }
}
