using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Camera2 : MonoBehaviour
{
    public GameObject[] tombstones;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    float shakeDuration = 0;
    [SerializeField]
    float shakeAmount = 0.1f;
    [SerializeField]
    Vector3 startPos;

    [SerializeField]
    GameObject lowest;
    [SerializeField]
    float lowest_y = 999;

    public GameObject n;

    int shakeCount = 0;

    private void Start()
    {
        startPos = transform.position;

        GameObject[] horses = GameObject.FindGameObjectsWithTag("Horse");
        for (int i = 0; i < horses.Length; ++i)
        {
            GameObject go = tombstones[i];
            Vector3 pos = go.transform.position;
            pos.y -= horses[i].GetComponent<HorseMovement>().deathCount * 0.5f;
            go.transform.position = pos;
            tombstones[i].SetActive(true);
            go.transform.GetChild(1).GetComponent<TextMesh>().text = horses[i].GetComponent<HorseMovement>().deathCount.ToString() + " Deaths";
        }
    }

    private void Update()
    {
        for (int i = 0; i < 4; ++i)
        {
            GameObject go = tombstones[i];
            if (go.activeInHierarchy)
            {
                if (go.transform.position.y < lowest_y)
                {
                    lowest = go;
                }
            }
        }

        if (lowest)
        {
            n.transform.rotation = transform.rotation;
            n.transform.position = transform.position;
            n.transform.LookAt(lowest.transform);
            transform.rotation = Quaternion.Euler(n.transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (shakeDuration > 0.0f)
        {
            Debug.Log("offset " + offset);
            shakeDuration -= Time.deltaTime;
            offset += Random.insideUnitSphere * shakeAmount;
        }

        if (shakeDuration < 0.2f)
        {
            offset *= 0.9f;
        }

        transform.position = startPos + offset;

        GameObject[] horses = GameObject.FindGameObjectsWithTag("Horse");
        if (shakeCount == horses.Length && GamePad.GetButton(GamePad.Button.A, GamePad.Index.Any))
        {
            StartCoroutine(Reload());
        }
    }

    public void Shake()
    {
        shakeDuration += Random.Range(Time.fixedDeltaTime * 4, Time.fixedDeltaTime * 8);
        shakeCount++;
    }

    IEnumerator Reload()
    {
        float curTime = Time.time;
        float time = curTime + 3;
        Image img = GameObject.Find("FadeToBlackCanvas").transform.GetChild(0).GetComponent<Image>();
        while (curTime < time)
        {
            AudioManager.instance.StopAll();
            yield return null;
            curTime = Time.time;
            Color c = img.color;
            c.a = Mathf.Lerp(0, 1, (2 - (time - curTime)));
            img.color = c;
        }

        for (int i = 0; i < 4; i++)
        {
            StaticPlayerCount.connectedPlayers[i] = false;
        }

        AudioManager.instance.StopAll();

        SceneManager.LoadScene("Game");
    }
}
