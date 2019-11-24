using Enums;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterPool : MonoBehaviour {

    [SerializeField]
    Enums.PrefabType[] PrefabTypesArray;
    [SerializeField]
    GameObject[] PrefabsArray;

    //to add all the objects to the main gameObject
    static Transform MasterPoolTransform;

    //Prepare the Dictionaries for easy pooling
    Dictionary<Enums.PrefabType, GameObject> PrefabsReference = new Dictionary<Enums.PrefabType, GameObject>();
    Dictionary<Enums.PrefabType, List<GameObject>> PrefabsDictionary = new Dictionary<Enums.PrefabType, List<GameObject>>();


    void Awake()
    {
        MasterPoolTransform = transform;
        for (int x = 0; x < PrefabTypesArray.Length; x++)
        {
            PrefabsReference.Add(PrefabTypesArray[x], PrefabsArray[x]);
            PrefabsDictionary.Add(PrefabTypesArray[x], new List<GameObject>());
        }
    }


    public GameObject Get(Enums.PrefabType prefabType)
    {
        // find unactive one
        foreach (GameObject obj in PrefabsDictionary[prefabType])
        {
            if (obj.activeSelf == false)
            {
                obj.SetActiveRecursively(true);

                return obj;
            }
        }

        // or create and list it
        GameObject tempObj = Instantiate(PrefabsReference[prefabType]);

        PrefabsDictionary[prefabType].Add(tempObj);

        tempObj.transform.SetParent(MasterPoolTransform);

        return tempObj;

    }
}
