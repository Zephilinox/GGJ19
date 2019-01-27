using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wagon")
        {
            GameObject caravan = GameObject.FindGameObjectWithTag("Wagon");
            GameObject[] horses = GameObject.FindGameObjectsWithTag("Horse");

            caravan.GetComponent<CaravanMovement>().canMove = false;
            caravan.GetComponent<BasicMove>().speed = 1;

            foreach (GameObject horse in horses)
            {
                horse.GetComponent<BasicMove>().enabled = false;
                horse.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }

            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        float curTime = Time.time;
        float time = curTime + 1;
        Image img = GameObject.Find("FadeToBlackCanvas").transform.GetChild(0).GetComponent<Image>();

        yield return new WaitForSeconds(5f);

        while (curTime < time)
        {
            yield return null;
            curTime = Time.time;
            Color c = img.color;
            c.a = Mathf.Lerp(0, 1, 1 - (time - curTime));
            img.color = c;
        }


        for (int i = 0; i < 4; i++)
        {
            StaticPlayerCount.connectedPlayers[i] = false;
        }

        AudioManager.instance.StopAll();

        SceneManager.LoadScene("Game");
        

        yield return null;
    }
}
