using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ThrustersLeft;

    [SerializeField]
    List<GameObject> ThrustersRight;

    [SerializeField]
    List<GameObject> ThrustersUp;

    [SerializeField]
    List<GameObject> ThrustersDown;

    void Awake()
    {
        //turn off all Thruster at the start
        TurnOffAllThrusters('V');
        TurnOffAllThrusters('H');
    }

    public void StartThrusters(char Axis, int Dir)
    {
        switch (Axis)
        {
            case 'V' :
                if (Dir > 0)
                    ModifyAllThrusterList(ThrustersDown, true);
                else
                    ModifyAllThrusterList(ThrustersUp, true);
                break;

            case 'H':
                if (Dir > 0)
                    ModifyAllThrusterList(ThrustersLeft, true);
                else
                    ModifyAllThrusterList(ThrustersRight, true);
                break;
        }
    }

    public void TurnOffAllThrusters(char Axis)
    {
        switch (Axis)
        {
            case 'V':
                ModifyAllThrusterList(ThrustersDown, false);
                ModifyAllThrusterList(ThrustersUp, false);
                break;

            case 'H':
                ModifyAllThrusterList(ThrustersRight, false);
                ModifyAllThrusterList(ThrustersLeft, false);
                break;
        }
    }

    void ModifyAllThrusterList(List<GameObject> Thrusters , bool Condition)
    {
        foreach (GameObject Thruster in Thrusters)
        {
            Thruster.SetActive(Condition);
        }
    }
}
