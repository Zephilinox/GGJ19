using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> sections;

    public GameObject currentSection;
    private GameObject leftSection;
    private GameObject rightSection;

    

    private bool correctDirection;  //True == right, False == left
    private int correctWay = 0; //Number of times passing through correct direction

    // Use this for initialization
	void Start ()
    {
        currentSection = Instantiate(sections[Random.Range(0, sections.Count - 1)]);
        currentSection.transform.position = (Vector3.zero);



        SpawnSection();
    }
	

    void SpawnSection()
    {
        leftSection = Instantiate(sections[Random.Range(0, sections.Count - 1)]);
        rightSection = Instantiate(sections[Random.Range(0, sections.Count - 1)]);

        leftSection.transform.position = currentSection.GetComponent<LevelScript>().leftEOS.NextSpawnPoint.transform.position;
        rightSection.transform.position = currentSection.GetComponent<LevelScript>().rightEOS.NextSpawnPoint.transform.position;

        correctDirection = (Random.value > 0.5f);

        if(correctWay == 5)
        {
            if(correctDirection)
            {
                //Spawn house
            }
            else
            {
                //Dont' spawn house
            }
        }
    }

    public void OnSectionComplete(GameObject nextSpawnPoint, bool isRight)
    {
        //cycle through all stored levels that are available
        //first one thats unused, move to target pos

        if (isRight)
        {
            currentSection = rightSection;
            Destroy(leftSection);
            if(correctDirection)
            {
                correctWay++;
            }
        }
        else
        {
            currentSection = leftSection;
            Destroy(rightSection);
            if (!correctDirection)
            {
                correctWay++;
            }
        }


        //destroy old one if we can yet

        SpawnSection();
    }
}
