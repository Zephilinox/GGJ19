using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoin : MonoBehaviour
{
    bool[] connectedPlayers = new bool[4];

    private void Update()
    {
        for (int i = 0; i < 4; ++i)
        {
            if (!connectedPlayers[i] && GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any + i))
            {
                connectedPlayers[i] = true;
            }
        }
    }
}