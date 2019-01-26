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

            if (current_lives == 0)
            {
                GetComponent<BasicMove>().speed = 1;
                StartCoroutine(LoseCargo(1.0f));
            }
            else if (current_lives > 0)
            {
                StartCoroutine(LoseCargo(2.0f));
                ModelAnimator.SetTrigger("invulnerability");
            }
        }
    }

    IEnumerator LoseCargo(float delay)
    {
        
        yield return new WaitForSeconds(delay);

        GameObject Object = Cargo[current_lives];

        Object.transform.parent = null;
        Object.GetComponent<Rigidbody>().isKinematic = false;

        yield return new WaitForSeconds(3f);
        invulnerable = false;
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
