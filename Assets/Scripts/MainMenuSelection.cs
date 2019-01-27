using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelection : MonoBehaviour
{
    public bool mainMenu = true;
    public bool playSelected = false;
    public bool ready = false;
    public bool flipping = false;
    public bool mainMenu2 = false;

    public GameObject[] horses;
    public GameObject[] lineRenders;

    

    //private void Start()
    //{
    //    horses = GameObject.FindGameObjectsWithTag("Horse");
    //}

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            horses[i].SetActive(StaticPlayerCount.connectedPlayers[i]);
            lineRenders[i].SetActive(StaticPlayerCount.connectedPlayers[i]);


        }

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
                AudioManager.instance.Play("GunShot1");

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
                    AudioManager.instance.Play("Neigh1");

                    transform.GetChild(2).GetChild(i).GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(2).GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                    StaticPlayerCount.connectedPlayers[i] = true;

                }
            }

            if (!mainMenu2 && StaticPlayerCount.connectedPlayers[0] && StaticPlayerCount.connectedPlayers[1])
            {
                //out of bounds due to deletion below, cba
                if (transform.childCount > 3)
                {
                    transform.GetChild(3).gameObject.SetActive(true);
                    if (GamePad.GetButton(GamePad.Button.Start, GamePad.Index.Any))
                    {
                        AudioManager.instance.Play("GunShot2");

                        Camera.main.GetComponent<CameraMovement>().enabled = true;

                        AudioManager.instance.Play("CartWheelMoving");
                        AudioManager.instance.Play("GallopingFullSpeed");
                        AudioManager.instance.Play("Wind");

                        Destroy(transform.GetChild(3).gameObject);
                        if (!flipping)
                        {
                            GetComponent<Animator>().Play("MainMenu");
                            flipping = true;

                            foreach(GameObject horse in horses)
                            {
                                horse.GetComponent<BasicMove>().enabled = true;
                                if (horse.activeSelf)
                                {
                                    GameObject.FindGameObjectWithTag("Wagon").GetComponent<CaravanMovement>().Horses.Add(horse);
                                }
                            }
                            GameObject.FindGameObjectWithTag("Wagon").GetComponent<BasicMove>().enabled = true;
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
                StaticPlayerCount.connectedPlayers[i] = false;
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
