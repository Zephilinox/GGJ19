using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> sections;

    public GameObject currentSection;
    private GameObject leftSection;
    private GameObject rightSection;

    public GameManager gameManager;

    public static string home;

    private bool correctDirection;  //True == right, False == left
    private int correctWay = 0; //Number of times passing through correct direction

    // Use this for initialization
	void Start ()
    {
        currentSection = Instantiate(sections[0]);
        currentSection.transform.position = (Vector3.zero);

        NameGenerator nameGenerator = new NameGenerator("/TownNames.txt");

        home = nameGenerator.GenerateRandomWord();

        SpawnSection(currentSection);
    }
	

    void SpawnSection(GameObject oldSection)
    {
        leftSection = Instantiate(sections[Random.Range(1, sections.Count - 1)]);
        rightSection = Instantiate(sections[Random.Range(1, sections.Count - 1)]);

        leftSection.transform.position = currentSection.GetComponent<LevelScript>().leftEOS.NextSpawnPoint.transform.position;
        rightSection.transform.position = currentSection.GetComponent<LevelScript>().rightEOS.NextSpawnPoint.transform.position;

        correctDirection = (Random.value > 0.5f);

        string correctArrow;
        if (correctDirection)
        {
            correctArrow = " ->";
        }
        else
        {
            correctArrow = " <-";
        }

        oldSection.GetComponent<LevelScript>().rightSign.text = home + correctArrow;
        oldSection.GetComponent<LevelScript>().leftSign.text = home + correctArrow;

        if (correctWay == 5)
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

        GameObject oldSection = currentSection;

        if (isRight)
        {
            currentSection = rightSection;
            Destroy(leftSection);
            if(correctDirection)
            {
                gameManager.IncrementBaseSpeed(5f);
                correctWay++;
            }
            else
            {
                gameManager.IncrementBaseSpeed(2.5f);
            }
        }
        else
        {
            currentSection = leftSection;
            Destroy(rightSection);
            if (!correctDirection)
            {
                gameManager.IncrementBaseSpeed(5f);
                correctWay++;
            }
            else
            {
                gameManager.IncrementBaseSpeed(2.5f);
            }
        }


        //destroy old one if we can yet

        SpawnSection(oldSection);
    }
}
