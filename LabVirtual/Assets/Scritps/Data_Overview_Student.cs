using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Data_Overview_Student : MonoBehaviour {

    Dictionary<string,  int> Student_grades;
    int changeCounter = 0;

    public Button buttonMenu;

    public GameObject menu;



    // Use this for initialization
    void Start () {
        SetGrades("Nomenclatura", 3);
        SetGrades("Balance de Ecuaciones", 2);
        SetGrades("Tabla Periodica", 1);
        SetGrades("Conversion de Unidades", 4);
        SetGrades("Estequiometria", 5);
    }
	
	// Update is called once per frame
	void Update () {
        buttonMenu = menu.GetComponent<Button>();
        buttonMenu.onClick.AddListener(ValidateMenu);
    }

    private void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    void Init()
    {
        if (Student_grades != null)
        {
            return;
        }
        Student_grades = new Dictionary<string,  int>();
    }

    public int GetGrades(string subject)
    {
        Init();
        if (Student_grades.ContainsKey(subject) == false)
        {
            return 0;
        }
        

        return Student_grades[subject];
    }

    public void SetGrades(string subject, int grade)
    {
        Init();

        changeCounter++;

        if (Student_grades.ContainsKey(subject) == false)
        {
            Student_grades[subject] = new int();
        }
        Student_grades[subject] = grade;
    }

    public void ChangeGrades(string subject, int new_grade)
    {
        Init();
        int currGrade = GetGrades(subject);
        SetGrades(subject, currGrade + new_grade);
    }

    public string[] GetStudentGrades()
    {
        Init();
        return Student_grades.Keys.ToArray();
    }

    public string[] GetStudentGrades(string SortByGrade)
    {
        Init();
        return Student_grades.Keys.OrderByDescending(n => GetGrades(SortByGrade)).ToArray();

    }

    public int GetChangeCounter()
    {
        return changeCounter;
    }

}
