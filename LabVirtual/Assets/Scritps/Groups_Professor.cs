using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine.SceneManagement;
using System.IO;
using System.ServiceModel;
using System;
using System.Globalization;

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

    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));
    public Dropdown opciones;
    public Dropdown Dyear;
    public Dropdown Dmes;
    public Dropdown Ddia;
    public Text nombre;
    private string[] nombres;
    private int[] gId;
    List<string> esto = new List<string>();
    List<string> LYear = new List<string>();
    List<string> LMes = new List<string>();
    List<string> LDia = new List<string>();
    private string[] numeros = new string[31] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
    private string[] conTreinta = new string[] { "04", "06", "09", "11" };
    private string[] conTreintaUno = new string[] { "01", "03", "05", "07","08","10","12"};
    private string conVeintiocho = "02";
    private string ayu, auxYear, auxMes, auxDia, actualFecha;
    private int actual;
    private string defecto = "Grupo";
    private UserSession Usuario;
    private string ID, actualMes = "01";
    private DateTime FechaS;


    // Use this for initialization
    void Start () {

        //string name = "Balanceo";
        //servicioWCF.RegistrarSimulacionEst(name, "juandanieljoa@gmail.com", "A");

        Usuario = GameObject.FindObjectOfType<UserSession>();
        ID = Usuario.darID();

        string[] resultados = servicioWCF.DarListagruposProfesor(ID);
        //string[] resultados = servicioWCF.DarListagruposProfesor("eliassantiago177@gmail.com");

        nombres = new string[resultados.Length];
        gId = new int[resultados.Length];
        opciones.ClearOptions();

        Ddia.ClearOptions();
        Dyear.ClearOptions();
        Dmes.ClearOptions();

        //rellena con los cursos
        for (int j = 0; j < resultados.Length; j++)
        {
            string[] ayuda = resultados[j].Split('@');
            nombres[j] = ayuda[0];
            gId[j] = Int32.Parse(ayuda[1]);
            int n = j + 1;
            esto.Add(defecto + " " + n.ToString());
        }

        //rellena dropdown de año
        DateTime date= DateTime.Now;
        int year = date.Year;
        LYear.Add(year.ToString());
        for (int j=0; j < 20; j++)
        {
            year--;
            LYear.Add(year.ToString());
        }

        //rellenado el mes
        for (int j = 0; j < 12; j++)
        {
            LMes.Add(numeros[j]);
        }

        //rellenando los dias
        for (int j = 0; j < numeros.Length; j++)
        {
            LDia.Add(numeros[j]);
        }
        //DateTime date = DateTime.ParseExact("2019-03-26 23:59:24", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        //FechaS =  DateTime.Now;
        //int year = date.Year;
        //print(FechaS + " y otra " + date+" |año:"+year+"| año antes:"+(year-1));

        opciones.AddOptions(esto);
        Dyear.AddOptions(LYear);
        Dmes.AddOptions(LMes);
        Ddia.AddOptions(LDia);

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
        GetFecha();

        int b = 0;
        foreach (string a in esto)
        {
            if (ayu.Equals(a))
            {
                nombre.text = nombres[b];
                actual = gId[b];
            }
            b++;
        }
        ActualizarFecha();
        actualFecha = auxYear+"-"+auxMes+"-"+auxDia+" 23:59:24";
        FechaS= DateTime.ParseExact(actualFecha, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
    }

    public void GetNivel()
    {
        ayu = opciones.options[opciones.value].text;
    }

    public void GetFecha()
    {
        auxYear = Dyear.options[Dyear.value].text;
        auxMes = Dmes.options[Dmes.value].text;
        auxDia = Ddia.options[Ddia.value].text;
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

    public void ActualizarFecha()
    {

        //para adaptar dias a febrero
        if (!auxMes.Equals(actualMes))
        {
            if (auxMes.Equals(conVeintiocho))
            {
                Ddia.ClearOptions();
                for (int j = 0; j < 28; j++)
                {
                    LDia.Add(numeros[j]);
                }
                Ddia.AddOptions(LDia);
            }

            for (int i = 0; i < conTreinta.Length; i++)
            {
                if (auxMes.Equals(conTreinta[i]))
                {
                    Ddia.ClearOptions();
                    for (int j = 0; j < 30; j++)
                    {
                        LDia.Add(numeros[j]);
                    }
                    Ddia.AddOptions(LDia);
                }
            }

            for (int i = 0; i < conTreintaUno.Length; i++)
            {
                if (auxMes.Equals(conTreintaUno[i]))
                {
                    Ddia.ClearOptions();
                    for (int j = 0; j < numeros.Length; j++)
                    {
                        LDia.Add(numeros[j]);
                    }
                    Ddia.AddOptions(LDia);
                }
            }
            actualMes = auxMes;
        }

    }

    public void go()
    {
        //prueba reporte
        print(FechaS);
        string esto = servicioWCF.GenerarReporteProfesor(actual, ID,FechaS);
        print(esto);
        //print("Resultado intento reporte" + esto);
    }
}
