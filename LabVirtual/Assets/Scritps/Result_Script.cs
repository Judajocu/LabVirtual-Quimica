using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using SimpleJSON;
using System.IO;
using System;
using System.ServiceModel;

public class Result_Script : MonoBehaviour
{

    #region Variables
    TextMesh cant_intentos;
    TextMesh promedio_intentos;
    TextMesh promedio_tiempos;
    TextMesh nota_resultante;

    public GameObject menu;

    public Button ButtonMenu;

    List<int> intentos;
    List<float> tiempos;
    List<string> notas = new List<string>();

    Simulation_Options_Scripts simulation_Options = new Simulation_Options_Scripts();
    SettingsProffesorScript settings = new SettingsProffesorScript();

    bool type = Niveles_prefab_script.levels;

    float intervalo;
    int penalidad;

    public string grade;
    public string simulation;
    string name;

    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:21826/ServiceLab.svc"));
    private UserSession Usuario;
    private string ID;

    #endregion

    // Use this for initialization
    void Start()
    {
        Usuario = GameObject.FindObjectOfType<UserSession>();
        ID = Usuario.darID();

        cant_intentos = GameObject.Find("Intentos").GetComponent<TextMesh>();
        promedio_tiempos = GameObject.Find("Promedio_tiempo").GetComponent<TextMesh>();
        nota_resultante = GameObject.Find("Nota_resultante").GetComponent<TextMesh>();
        GetSimulationData();
        intervalo = settings.Getintervalo();
        penalidad = settings.Gettrys();
        GetIntentosCount();
        GetGrade();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ValidateMenu()
    {

        SceneManager.LoadScene("Options_Student");
    }

    public double GetAverageTrys()
    {
        float sum = 0;
        if (intentos == null)
        {
            return sum = 1;
        }
        else
        {
            for (int i = 0; i < intentos.Count; i++)
            {
                //Debug.Log(intentos[i]);
                sum += intentos[i];
            }
            Debug.Log("intentos total" + sum);
            sum /= intentos.Count;
            Debug.Log("size de intentos" + intentos.Count);
            Debug.Log("El total de intentos contados" + intentos.Count);
            //promedio_intentos.text = "Promedio por simulación :" + sum;
            return sum;
        }
    }

    public void GetIntentosCount()
    {
        int sum = 0;
        if (intentos == null)
        {
            sum = 5;
        }
        else
        {
            for (int i = 0; i < intentos.Count; i++)
            {
                sum += intentos[i];

            }
        }

        cant_intentos.text = "Total de intentos :" + sum;
    }

    public double GetAverageTime()
    {
        float sum = 0;
        float lele;
        for (int i = 0; i < tiempos.Count; i++)
        {
            // Debug.Log(tiempos[i]);
            sum += tiempos[i];
            lele = tiempos[i];
            Debug.Log("tiempos en nivel" + i + "tiempo:" + lele);
        }
        sum /= tiempos.Count;
        Debug.Log("cantidades de tiempo" + tiempos.Count);
        //sum = 60.0f - sum;

        promedio_tiempos.text = "Promedio de tiempo:" + sum;

        double tots = Math.Round(sum, 2);
        Debug.Log(tots);

        return tots;
    }

    public double CheckTrys(double trys, double time)
    {
        if (trys < penalidad)
        {
            time += 0.0f;
        }
        if (trys < penalidad * 2 && trys > penalidad)
        {
            time += 5.0f;
        }
        if (trys > penalidad * 3)
        {
            time += 10.0f;
        }

        return time;
    }

    public string AssingGrade(double final_time)
    {
        string grade = "";

        if (final_time <= intervalo)
            grade = "A";

        if (final_time >= intervalo + 0.1 && final_time <= intervalo * 2)
            grade = "B";

        if (final_time >= intervalo * 2 + 0.1 && final_time <= intervalo * 3)
            grade = "C";

        if (final_time >= intervalo * 3 + 0.1)
            grade = "D";

        return grade;
    }

    public void GetGrade()
    {
        double time = GetAverageTime();
        double tots = Math.Round(time, 2);
        double trys = GetAverageTrys();
        double final_time = CheckTrys(trys, tots);

        string grade = AssingGrade(final_time);
        if (type != true)
            GetSimulationName(grade);

        nota_resultante.text = "Calificacion resultante:" + grade;
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/Nota Simulation.json";
        if (!File.Exists(@path))
        {
            notas.Add("0");
            notas.Add("0");
            notas.Add("0");
            notas.Add("0");
            notas.Add("0");
        }
        else
        {
            string jsonString = File.ReadAllText(path);
            JSONObject GradeJSON = (JSONObject)JSON.Parse(jsonString);
            notas.Add(GradeJSON["Balanceo de Ecuaciones"]);
            notas.Add(GradeJSON["Nomenclatura"]);
            notas.Add(GradeJSON["Tabla Periodica"]);
            notas.Add(GradeJSON["Conversion de Unidades"]);
            notas.Add(GradeJSON["Estequiometria"]);
            CheckNotas();
        }
    }

    public void CheckNotas()
    {
        for (int i = 0; i < notas.Count; i++)
        {
            if (notas[i] == null || notas[i] == "")
                notas[i] = "0";
        }
    }

    public void GetSimulationName(string grade)
    {
        Load();
        JSONObject resultJSON = new JSONObject();

        switch (simulation_Options.GetSelected())
        {
            case 1:
                name = "Balanceo";
                servicioWCF.RegistrarSimulacionEst(name, ID, grade);
                //"Nomenclatura", "Balanceo", "Estequiometria", "Tabla Periodica", "Conversion"
                /*resultJSON.Add(name, grade);
                resultJSON.Add("Tabla Periodica", notas[1]);
                resultJSON.Add("Conversion de Unidades", notas[2]);
                resultJSON.Add("Nomenclatura", notas[3]);
                resultJSON.Add("Estequiometria", notas[4]);
                string path1 = Application.persistentDataPath + "/Nota Simulation.json";
                File.WriteAllText(path1, resultJSON.ToString());*/
                return;
            case 2:
                name = "Tabla Periodica";
                servicioWCF.RegistrarSimulacionEst(name, ID, grade);
                //"Nomenclatura", "Balanceo", "Estequiometria", "Tabla Periodica", "Conversion"
                /*resultJSON.Add("Balanceo de Ecuaciones", notas[0]);
                resultJSON.Add(name, grade);
                resultJSON.Add("Conversion de Unidades", notas[2]);
                resultJSON.Add("Nomenclatura", notas[3]);
                resultJSON.Add("Estequiometria", notas[4]);
                string path2 = Application.persistentDataPath + "/Nota Simulation.json";
                File.WriteAllText(path2, resultJSON.ToString());*/
                return;
            case 3:
                name = "Conversion";
                servicioWCF.RegistrarSimulacionEst(name, ID, grade);
                //"Nomenclatura", "Balanceo", "Estequiometria", "Tabla Periodica", "Conversion"
                /*resultJSON.Add("Balanceo de Ecuaciones", notas[0]);
                resultJSON.Add("Tabla Periodica", notas[1]);
                resultJSON.Add(name, grade);
                resultJSON.Add("Nomenclatura", notas[3]);
                resultJSON.Add("Estequiometria", notas[4]);
                string path3 = Application.persistentDataPath + "/Nota Simulation.json";
                File.WriteAllText(path3, resultJSON.ToString());*/
                return;
            case 4:
                name = "Nomenclatura";
                servicioWCF.RegistrarSimulacionEst(name, ID, grade);
                //"Nomenclatura", "Balanceo", "Estequiometria", "Tabla Periodica", "Conversion"
                /*resultJSON.Add("Balanceo de Ecuaciones", notas[0]);
                resultJSON.Add("Tabla Periodica", notas[1]);
                resultJSON.Add("Conversion de Unidades", notas[2]);
                resultJSON.Add(name, grade);
                resultJSON.Add("Estequiometria", notas[4]);
                string path4 = Application.persistentDataPath + "/Nota Simulation.json";
                File.WriteAllText(path4, resultJSON.ToString());*/
                return;
            case 5:
                name = "Estequiometria";
                servicioWCF.RegistrarSimulacionEst(name, ID, grade);
                //"Nomenclatura", "Balanceo", "Estequiometria", "Tabla Periodica", "Conversion"
                /*resultJSON.Add("Balanceo de Ecuaciones", notas[0]);
                resultJSON.Add("Tabla Periodica", notas[1]);
                resultJSON.Add("Conversion de Unidades", notas[2]);
                resultJSON.Add("Nomenclatura", notas[3]);
                resultJSON.Add(name, grade);
                string path5 = Application.persistentDataPath + "/Nota Simulation.json";
                File.WriteAllText(path5, resultJSON.ToString());*/
                return;
        }

    }
    public void GetSimulationData()
    {
        switch (simulation_Options.GetSelected())
        {
            case 1:
                intentos = Simulation_Balance.intentos;
                tiempos = Simulation_Balance.tiempos;
                return;
            case 2:
                intentos = Simulation_Table_Script.intentos;
                tiempos = Simulation_Table_Script.tiempos;

                return;
            case 3:
                intentos = Simulation_Convertion_Script.intentos;
                tiempos = Simulation_Convertion_Script.tiempos;

                return;
            case 4:
                intentos = Simulacion_nomenclatura.intentos;
                tiempos = Simulacion_nomenclatura.tiempos;

                return;
            case 5:
                intentos = Estequiometria_Script.intentos;
                tiempos = Estequiometria_Script.tiempos;
                return;
        }
    }
}