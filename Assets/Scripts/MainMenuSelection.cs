using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelection : MonoBehaviour
{
    public bool mainMenu = true;
    public bool playSelected = false;
    public bool ready = false;
    public bool flipping = false;

    private void Update()
    {
        if (mainMenu)
        {
            if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any).x > 0.0f)
            {
                playSelected = false;
                transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            }
            else if (GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Any).x < 0.0f)
            {
                playSelected = true;
                transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            }

            if (GamePad.GetButton(GamePad.Button.A, GamePad.Index.Any))
            {
                if (!flipping && playSelected)
                {
                    GetComponent<Animator>().Play("MainMenu");
                    flipping = true;
                }
            }
        }
    }

    public void SignFlipComplete()
    {
        flipping = false;

        if (mainMenu)
        {
            mainMenu = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            ready = true;
        }
    }
}
