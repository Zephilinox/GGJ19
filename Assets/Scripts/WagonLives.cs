using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WagonLives : MonoBehaviour
{
    [SerializeField]
    private int max_lives;

    [SerializeField]
    private List<GameObject> Cargo;

    [SerializeField]
    private Animator ModelAnimator;

    private int current_lives;

    private bool invulnerable = false;

    void Start()
    {
        current_lives = max_lives;

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseLife();
        }
    }

    public void LoseLife()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            current_lives--;

            if (current_lives <= 0)
            {
                GetComponent<BasicMove>().enabled = false;
                
                GameObject caravan = GameObject.FindGameObjectWithTag("Wagon");
                GameObject[] horses = GameObject.FindGameObjectsWithTag("Horse");

                caravan.GetComponent<CaravanMovement>().canMove = false;

                foreach(GameObject horse in horses)
                {
                    horse.GetComponent<BasicMove>().enabled = false;
                }
                StartCoroutine(LoseCargo(5f));
            }
            else if (current_lives > 0)
            {
                StartCoroutine(LoseCargo(3f));
                ModelAnimator.SetTrigger("invulnerability");
            }
        }
    }

    IEnumerator LoseCargo(float delay)
    {
        GameObject Object = Cargo[current_lives];

        Object.transform.parent = null;
        Object.GetComponent<Rigidbody>().isKinematic = false;

        Debug.Log("Fucking work");

        yield return new WaitForSeconds(delay);
        invulnerable = false;

        Debug.Log("Fucking work");

        if (current_lives <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                StaticPlayerCount.connectedPlayers[i] = false;
            }
            SceneManager.LoadScene("Game");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Obstacle"))
        {
            LoseLife();
            Debug.Log(collider.gameObject.name);
        }
    }
}
