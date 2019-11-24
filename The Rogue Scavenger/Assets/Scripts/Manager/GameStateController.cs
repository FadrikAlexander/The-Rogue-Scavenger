using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStateController : MonoBehaviour
{
    // PlaceHolder
    [SerializeField]
    GameObject GameOverText;

    //Get Called when Player Die
    public void GameOver()
    {
        GameOverText.SetActive(true);
    }
}
