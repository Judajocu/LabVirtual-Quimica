using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Datagrid_Overview_Professor : MonoBehaviour {

    /*public GameObject prefab_groups;
    public GameObject prefab_groupcode;
    public GameObject prefab_avggrades;
    public int Cant_grupos;*/

    Dictionary<string, Dictionary<string, string>> Groups_Grades;
    int changeCounter = 0;

    public Button buttonMenu;

    public GameObject menu;


    // Use this for initialization
    void Start () {
        GameObject.Find("InputFieldSizegroups").GetComponent<InputField>().text = "1";
        SetGrades( "ST-QMC-101-T-001","Quimica101", "C");
        Debug.Log(GetGrades("ST-QMC-101-T-001", "Quimica101"));
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Professor");
    }

    void Init()
    {
        if (Groups_Grades != null)
        {
            return;
        }
        Groups_Grades = new Dictionary<string, Dictionary<string, string>>();
    }

    public string GetGrades(string group_code, string group)
    {
        Init();
        if(Groups_Grades.ContainsKey(group_code) == false)
        {
            //Este debe de retornar para la pantalla la nota que se muestra
            return "A";
        }
        if (Groups_Grades[group_code].ContainsKey(group) == false)
        {
            //Sino es el de arriba es este
            return "A";
        }

        return Groups_Grades[group_code][group];
    }

    public void SetGrades(string group_code, string group, string grade)
    {
        Init();

        changeCounter++;

        if(Groups_Grades.ContainsKey(group_code) == false)
        {
            Groups_Grades[group_code] = new Dictionary<string, string>();
        }
        Groups_Grades[group_code][group] = grade;
    }

    public void ChangeGrades(string group_code, string group, int new_grade)
    {
        Init();
        string currGrade = GetGrades(group_code, group);
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

}
