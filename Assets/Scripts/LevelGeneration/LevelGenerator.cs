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
    public int winCon = 2;

    private bool correctDirection;  //True == right, False == left
    public int correctWay = 0; //Number of times passing through correct direction

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
        if (correctWay >= winCon)
        {
            if(correctDirection)
            {
                leftSection = Instantiate(sections[Random.Range(1, sections.Count - 2)]);
                rightSection = Instantiate(sections[7]);
                leftSection.transform.position = currentSection.GetComponent<LevelScript>().leftEOS.NextSpawnPoint.transform.position;
                rightSection.transform.position = currentSection.GetComponent<LevelScript>().rightEndGameMarker.transform.position;
            }
            else
            {
                leftSection = Instantiate(sections[7]);
                rightSection = Instantiate(sections[Random.Range(1, sections.Count - 2)]);
                rightSection.transform.position = currentSection.GetComponent<LevelScript>().leftEOS.NextSpawnPoint.transform.position;
                leftSection.transform.position = currentSection.GetComponent<LevelScript>().rightEndGameMarker.transform.position;
            }
        }
        else
        {
            leftSection = Instantiate(sections[Random.Range(1, sections.Count - 2)]);
            rightSection = Instantiate(sections[Random.Range(1, sections.Count - 2)]);
            leftSection.transform.position = currentSection.GetComponent<LevelScript>().leftEOS.NextSpawnPoint.transform.position;
            rightSection.transform.position = currentSection.GetComponent<LevelScript>().rightEOS.NextSpawnPoint.transform.position;
        }

        

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
