using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelection : MonoBehaviour
{
    public bool mainMenu = true;
    public bool playSelected = false;
    public bool ready = false;
    public bool flipping = false;
    public bool[] connectedPlayers = new bool[4];
    public bool mainMenu2 = false;

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
                else if (!flipping && !playSelected)
                {
                    Application.Quit();
                }
            }
        }
        else
        {
            if (GamePad.GetButton(GamePad.Button.B, GamePad.Index.Any))
            {
                GetComponent<Animator>().Play("MainMenu");
                flipping = true;
                mainMenu2 = true;
                transform.GetChild(3).gameObject.SetActive(false);
                return;
            }

            for (int i = 0; i < 4; ++i)
            {
                if (GamePad.GetButton(GamePad.Button.A, GamePad.Index.One + i))
                {
                    transform.GetChild(2).GetChild(i).GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(2).GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                    connectedPlayers[i] = true;
                }
            }

            if (!mainMenu2 && connectedPlayers[0] && connectedPlayers[1])
            {
                //out of bounds due to deletion below, cba
                if (transform.childCount > 3)
                {
                    transform.GetChild(3).gameObject.SetActive(true);
                    if (GamePad.GetButton(GamePad.Button.Start, GamePad.Index.Any))
                    {
                        Destroy(transform.GetChild(3).gameObject);
                        Debug.Log(flipping);
                        if (!flipping)
                        {
                            GetComponent<Animator>().Play("MainMenu");
                            flipping = true;
                        }
                    }
                }
            }
        }
    }

    public void SignFlipComplete()
    {
        flipping = false;

        if (mainMenu2)
        {
            mainMenu = true;
            mainMenu2 = false;

            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);

            for (int i = 0; i < 4; ++i)
            {
                transform.GetChild(2).GetChild(i).GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
                connectedPlayers[i] = false;
            }

            transform.GetChild(3).gameObject.SetActive(false);
            return;
        }
            
        if (mainMenu)
        {
            mainMenu = false;
            mainMenu2 = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (!mainMenu)
        {
            ready = true;
            Rigidbody rg = gameObject.AddComponent<Rigidbody>();
            //rg.AddForce(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100), ForceMode.Impulse);
            //rg.AddTorque(Random.Range(-1000, 1000), Random.Range(-1000, 1000), Random.Range(-1000, 1000), ForceMode.Impulse);
            Destroy(gameObject, 3);
        }
    }
}
