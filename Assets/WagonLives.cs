using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class WagonLives : MonoBehaviour
{
    [SerializeField]
    private int max_lives;

    [SerializeField]
    private List<GameObject> Cargo;

    private int current_lives;

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
        current_lives--;
        if (current_lives == 0)
        {
            GetComponent<BasicMove>().speed = 1;
            StartCoroutine(LoseCargo(1.0f));

        }
        else
        {
            StartCoroutine(LoseCargo(2.0f));
        }
    }

    IEnumerator LoseCargo(float delay)
    {
        yield return new WaitForSeconds(delay);

        Debug.Log(current_lives);
        GameObject Object = Cargo[current_lives];

        Object.transform.parent = null;
        Object.GetComponent<Rigidbody>().isKinematic = false;
    }
}
