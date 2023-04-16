using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameState { FreeRoam, Battle}
public class GameController : MonoBehaviour
{
    GameState state;
    [SerializeField] Player playerController;
    [SerializeField] BattleSystem battleController;

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            // give control to player 
        }
        else if (state == GameState.Battle)
        {
            // give control to battle system
        }
    }
}
