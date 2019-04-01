using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using SimpleJSON;
using System.IO;
using System.ServiceModel;

public class Data_Overview_Student : MonoBehaviour {

    Dictionary<string,  string> Student_grades;
    int changeCounter = 0;

    public Button buttonMenu;

    public GameObject menu;
    private UserSession Usuario;
    private string ID;



    // Use this for initialization
    void Start () {
        Usuario = GameObject.FindObjectOfType<UserSession>();
        ID = Usuario.darID();
        //Load();
        //SetGrades("Nomenclatura", "3");
        
        //SetGrades("Tabla Periodica", "1");
        //SetGrades("Conversion de Unidades", "4");
        //SetGrades("Estequiometria", "5");


    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    void Init()
    {
        if (Student_grades != null)
        {
            return;
        }
        Student_grades = new Dictionary<string,  string>();
    }

    public string GetGrades(string subject)
    {
        Init();
        if (Student_grades.ContainsKey(subject) == false)
        {
            return "";
        }
        

        return Student_grades[subject];
    }

    public void SetGrades(string subject, string grade)
    {
        Init();

        changeCounter++;

        if (Student_grades.ContainsKey(subject) == false)
        {
            Student_grades[subject] = "0";
        }
        Student_grades[subject] = grade;
    }

    public void ChangeGrades(string subject, string new_grade)
    {
        Init();
        string currGrade = GetGrades(subject);
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
    /*
    void Load()
    {
        string path = Application.persistentDataPath + "/Nota Simulation.json";
        string jsonString = File.ReadAllText(path);
        JSONObject GradeJSON = (JSONObject)JSON.Parse(jsonString);
        SetGrades("Balance de Ecuaciones", GradeJSON["Balanceo de Ecuaciones"]);
        SetGrades("Nomenclatura", GradeJSON["Nomenclatura"]);
        SetGrades("Tabla Periodica", GradeJSON["Tabla Periodica"]);
        SetGrades("Conversion de Unidades", GradeJSON["Conversion de Unidades"]);
        SetGrades("Estequiometria", GradeJSON["Estequiometria"]);
    }
    */
    public void GenerateReport()
    {
        string problem = "no se hizo la coneccion";

            ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));
            
            string esto=servicioWCF.GenerarReporteEstudiante(ID,ID);
            print(esto);
            
    }

}
