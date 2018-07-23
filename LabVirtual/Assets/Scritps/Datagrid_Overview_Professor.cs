using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Datagrid_Overview_Professor : MonoBehaviour {

    /*public GameObject prefab_groups;
    public GameObject prefab_groupcode;
    public GameObject prefab_avggrades;
    public int Cant_grupos;*/

    Dictionary<string, Dictionary<string, int>> Groups_Grades;
    int changeCounter = 0;

	// Use this for initialization
	void Start () {
        SetGrades( "ST-QMC-101-T-001","Quimica I", 30);
        SetGrades("ST-QMC-101-T-0012","Quimica I", 40);
        SetGrades("ST-QMC-101-T-003", "Quimica I", 350);
        SetGrades("ST-QMC-101-T-004", "Quimica I", 430);
        Debug.Log(GetGrades("ST-QMC-101-T-001", "Quimica I"));
    }
	
	// Update is called once per frame
	void Update () {        
	}
    void Init()
    {
        if (Groups_Grades != null)
        {
            return;
        }
        Groups_Grades = new Dictionary<string, Dictionary<string, int>>();
    }

    public int GetGrades(string group_code, string group)
    {
        Init();
        if(Groups_Grades.ContainsKey(group_code) == false)
        {
            return 0;
        }
        if (Groups_Grades[group_code].ContainsKey(group) == false)
        {
            return 0;
        }

        return Groups_Grades[group_code][group];
    }

    public void SetGrades(string group_code, string group, int grade)
    {
        Init();

        changeCounter++;

        if(Groups_Grades.ContainsKey(group_code) == false)
        {
            Groups_Grades[group_code] = new Dictionary<string, int>();
        }
        Groups_Grades[group_code][group] = grade;
    }

    public void ChangeGrades(string group_code, string group, int new_grade)
    {
        Init();
        int currGrade = GetGrades(group_code, group);
        SetGrades(group_code, group, currGrade + new_grade);
    }

    public string[] GetGroups_codes()
    {
        Init();
        return Groups_Grades.Keys.ToArray();
    }

    public string[] GetGroups_codes(string SortByGrade)
    {
        Init();

        return Groups_Grades.Keys.OrderByDescending(n => GetGrades(n, SortByGrade)).ToArray();

    }

    public int GetChangeCounter()
    {
        return changeCounter;
    }




    /*void Populate()
    {
        GameObject gameObject;
        for (int i = 0; i < Cant_grupos; i++)
        {
            gameObject = (GameObject)Instantiate(prefab_groups, transform);
            gameObject = (GameObject)Instantiate(prefab_groupcode, transform);
            gameObject = (GameObject)Instantiate(prefab_avggrades, transform);
        }
    }*/

}
