using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;
using System.IO;
using System.ServiceModel;

public class Groups_Professor : MonoBehaviour {

    /*public GameObject prefab_groups;
    public GameObject prefab_groupcode;
    public GameObject prefab_avggrades;
    public int Cant_grupos;*/

    Dictionary<string, Dictionary<string, string>> Groups_Grades;
    int changeCounter = 0;

    public Button buttonMenu;
    public Button buttonReport;
    public Button buttonSelect;

    public GameObject menu;
    public GameObject report;
    public GameObject select;

    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:21826/ServiceLab.svc"));
    public Dropdown opciones;
    public Text nombre;
    private string[] nombres;
    List<string> esto = new List<string>();
    private string actual, ayu;
    private string defecto = "Grupo";
    private UserSession Usuario;
    private string ID;


    // Use this for initialization
    void Start () {
        Usuario = GameObject.FindObjectOfType<UserSession>();
        ID = Usuario.darID();

        string[] resultados = servicioWCF.DarListagruposProfesor(ID);
        nombres = new string[resultados.Length];
        
        opciones.ClearOptions();
        for (int j = 0; j < resultados.Length; j++)
        {
            nombres[j] = resultados[j];
            int n = j + 1;
            esto.Add(defecto + " " + n.ToString());
        }

        opciones.AddOptions(esto);

        /*
        SetGrades("ST-QMC-101-T-0012","Quimica I", 40);
        SetGrades("ST-QMC-101-T-003", "Quimica I", 350);
        SetGrades("ST-QMC-101-T-004", "Quimica I", 430);
        Debug.Log(GetGrades("ST-QMC-101-T-001", "Quimica I"));
        Load();*/
        SetGrades("ST-QMC-101-T-001", "Quimica I", "A");
    }
	
	// Update is called once per frame
	void Update () {
        GetNivel();
        int b = 0;
        foreach (string a in esto)
        {
            if (ayu.Equals(a))
            {
                nombre.text = nombres[b];
                actual = nombres[b];

            }
            b++;
        }
    }

    public void GetNivel()
    {
        ayu = opciones.options[opciones.value].text;
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
            return "0";
        }
        if (Groups_Grades[group_code].ContainsKey(group) == false)
        {
            return "0";
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

    /*public void ChangeGrades(string group_code, string group, string new_grade)
    {
        Init();
        int currGrade = GetGrades(group_code, group);
        SetGrades(group_code, group, currGrade + new_grade);
    }*/

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
    
    void Load()
    {
        
    }

    public void go()
    {
        //prueba reporte
        string esto = servicioWCF.GenerarReporteProfesor(actual, ID);
        //print("Resultado intento reporte" + esto);
    }
}
