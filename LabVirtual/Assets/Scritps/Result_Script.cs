﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using SimpleJSON;
using System.IO;

public class Result_Script : MonoBehaviour {

    #region Variables
    TextMesh cant_intentos;
    TextMesh promedio_intentos;
    TextMesh promedio_tiempos;
    TextMesh nota_resultante;

    public GameObject menu;

    public Button ButtonMenu;

    List<int> intentos;
    List<float> tiempos;

    Simulation_Options_Scripts simulation_Options = new Simulation_Options_Scripts();
    SettingsProffesorScript settings = new SettingsProffesorScript();

    bool type = Niveles_prefab_script.levels;

    float intervalo;
    int penalidad;

    public string grade;
    public string simulation;
    string name;
    #endregion

    // Use this for initialization
    void Start () {
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
	void Update () {
		
	}

    public void ValidateMenu()
    {
        
        SceneManager.LoadScene("Options_Student");
    }

    public float GetAverageTrys()
    {
        float sum = 0;
        for (int i = 0; i < intentos.Count; i++)
        {
            //Debug.Log(intentos[i]);
            sum += intentos[i];
        }
        Debug.Log("intentos total" + sum);
        sum /= intentos.Count;
        Debug.Log("size de intentos"+intentos.Count);
        Debug.Log("El total de intentos contados"+intentos.Count);
        //promedio_intentos.text = "Promedio por simulación :" + sum;

        return sum;
    }

    public void GetIntentosCount()
    {
        int sum = 0;
        for (int i = 0; i < intentos.Count; i++)
        {
            sum += intentos[i];
            
        }
        
        cant_intentos.text = "Total de intentos :" + sum;
    }

    public float GetAverageTime()
    {
        float sum = 0;
        float lele;
        for (int i = 0; i < tiempos.Count; i++)
        {
         // Debug.Log(tiempos[i]);
            sum += tiempos[i];
            lele = tiempos[i];
            Debug.Log("tiempos en nivel" + i + "tiempo:" +  lele);
        }
        sum /= tiempos.Count;
        Debug.Log("cantidades de tiempo" + tiempos.Count);
        //sum = 60.0f - sum;

        promedio_tiempos.text = "Promedio de tiempo:" + sum;

        return sum;
    }

    public float CheckTrys(float trys, float time)
    {
        if (trys < penalidad)
        {
            time += 0.0f;
        }
        if (trys < penalidad*2 && trys > penalidad)
        {
            time += 5.0f;
        }
        if (trys > penalidad*3)
        {
            time += 10.0f;
        }

        return time;
    }

    public string AssingGrade(float final_time)
    {
        string grade = "";

        if (final_time <= intervalo)
            grade = "A";

        if (final_time >= intervalo+0.1 && final_time <= intervalo*2)
            grade = "B";

        if (final_time >= intervalo*2+0.1 && final_time <= intervalo*3)
            grade = "C";

        if (final_time >= intervalo*3+0.1)
            grade = "D";

        return grade;
    }

    public void GetGrade()
    {
        float time = GetAverageTime();
        float trys = GetAverageTrys();
        float final_time = CheckTrys(trys, time);

        string grade = AssingGrade(final_time);
        if(type=true)
            GetSimulationName(grade);

        nota_resultante.text = "Calificacion resultante:" + grade;
    }

    private void Save(string grade, string Simulation)
    {
        JSONObject resultJSON = new JSONObject();
        resultJSON.Add(Simulation, grade);
        
        Debug.Log(resultJSON.ToString());

        string path = Application.persistentDataPath + "/Nota Simulation.json";
        File.WriteAllText(path, resultJSON.ToString());
    }

    public void GetSimulationName(string grade)
    {
        
        switch(simulation_Options.GetSelected())
        {
            case 1:
                name = "Balanceo de Ecuaciones";
                Save(grade,name);
                return;
            case 2:
                name = "Tabla Periodica";
                Save(grade, name);
                return;
            case 3:
                name = "Conversion de Unidades";
                Save(grade, name);
                return;
            case 4:
                name = "Nomenclatura";
                Save(grade, name);
                return;
            case 5:
                name = "Estequiometria";
                Save(grade, name);
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
                //name = "Tabla Periodica";
                
                return;
            case 3:
                //name = "Conversion de Unidades";
                
                return;
            case 4:
               // name = "Nomenclatura";
                
                return;
            case 5:
               // name = "Estequiometria";
                
                return;

        }
    }
}
