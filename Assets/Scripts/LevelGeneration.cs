using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public class Section
    {
        public Section branch1;
        public Section branch2;

        public GameObject obj;
        public GameObject seperator;
    }

    public Section rootSection = new Section();

    public List<GameObject> m_sections;


    // Use this for initialization
    void Start ()
    {
        BuildLevel();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //Build branches of levels
    void BuildRecursive(Section Parent, Section section, int depth)
    {
        //Create branches if depth is less than 7
        if (depth < 5)
        {
            section.branch1 = new Section();
            section.branch2 = new Section();

            section.branch1.obj = Instantiate(m_sections[Random.Range(0, m_sections.Capacity - 1)]);
            section.branch1.obj.transform.parent = section.obj.transform;
            section.branch1.obj.transform.localPosition = new Vector3(-100, 0, 30);

            section.branch2.obj = Instantiate(m_sections[Random.Range(0, m_sections.Capacity - 1)]);
            section.branch2.obj.transform.parent = section.obj.transform;
            section.branch2.obj.transform.localPosition = new Vector3(-100, 0, -30);

            BuildRecursive(section, section.branch1, depth + 1);
            BuildRecursive(section, section.branch2, depth + 1);
        }
    }

    //Build levels
    void BuildLevel()
    {
        rootSection.obj = Instantiate(m_sections[Random.Range(0, m_sections.Capacity - 1)]);

        rootSection.branch1 = new Section();
        rootSection.branch2 = new Section();
        
        rootSection.branch1.obj = Instantiate(m_sections[Random.Range(0, m_sections.Capacity - 1)]);
        rootSection.branch1.obj.transform.parent = rootSection.obj.transform;
        rootSection.branch1.obj.transform.localPosition = new Vector3(-100, 0, 30);

        rootSection.branch2.obj = Instantiate(m_sections[Random.Range(0, m_sections.Capacity - 1)]);
        rootSection.branch2.obj.transform.parent = rootSection.obj.transform;
        rootSection.branch2.obj.transform.localPosition = new Vector3(-100, 0, -30);

        BuildRecursive(rootSection, rootSection.branch1, 0);
        BuildRecursive(rootSection, rootSection.branch2, 0);
    }
}