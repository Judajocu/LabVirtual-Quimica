﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.ServiceModel;
using System;

public class Estequiometria_Script : MonoBehaviour {

    //Subindices
    //₀₁₂₃₄₅₆₇₈₉

    #region Variables
    public Button ButtonMenu;
    public Button ButtonSkip;
    public Button Buttonsubmit;

    public GameObject menu;
    public GameObject skip;
    public GameObject submit;
    public GameObject ElementFillPrefab;
    
    public InputField Answer;

    public TextMesh cantresult;
    TextMesh textcant_fallos;

    List<GameObject> List_Fillprefabs = new List<GameObject>();
    List<int> fallos_simulacion;
    static public List<int> intentos = new List<int>();
    static public List<float> tiempos = new List<float>();

    SettingsProffesorScript settings = new SettingsProffesorScript();
    
    int intento_nivel = 0;
    float time_left = 0.0f;
    float timeup;
    bool type;

    Scene activeScene;

    public string level;
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));
    #endregion

    // Use this for initialization
    void Start ()
    {
        string[] simulacionesNombre = new string[3] { "problema", "Solucion", "Contexto" };
        string[] resultados = servicioWCF.BuscarDatosD("Estequiometria", level, simulacionesNombre);
        string[] ayuda = resultados[2].Split('@');
        string lala = "";
        for (int j = 0; j < ayuda.Length; j++)
        {
            lala += ayuda[j] + Environment.NewLine;
        }
        print(lala);

        timeup = settings.Gettime();
        CheckType();
        textcant_fallos = GameObject.Find("Errores").GetComponent<TextMesh>();
        GameObject.Find("Cant_result").GetComponent<TextMesh>().text = resultados[1];
        GameObject.Find("Ecuation").GetComponent<TextMesh>().text = resultados[0];
        GameObject.Find("TextC").GetComponent<Text>().text = lala;
        cantresult = GameObject.Find("Cant_result").GetComponent<TextMesh>();
        CheckTime();
    }
	
	// Update is called once per frame
	void Update () {
        CheckTime();
    }

    public void CheckTime()
    {
        time_left += Time.deltaTime;
        TimeOver();
    }

    public void TimeOver()
    {
        if (time_left > timeup)
        {
            CheckSkip();
            CleanSimulation();
            SceneManager.LoadScene("Resultado");
            return;
        }
    }

    public void Resulttime()
    {
        if (CheckSkip())
        {
            if (intento_nivel == 0)
            {
                tiempos.Add(0.0f);
            }
            if (intento_nivel != 0)
            {
                tiempos.Add(time_left);
            }
        }
        tiempos.Add(time_left);
    }

    public void ResetTime()
    {
        time_left = 00.0f;
    }

    public string GetSceneName()
    {
        activeScene = SceneManager.GetActiveScene();
        return activeScene.name;
    }
    
    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    //Esto es lo que chequea si el resultado esperado es igual al esperado
    public bool CheckResultCorrect()
    {
        if (cantresult.text.Equals(GetInput()))
            return true;
        else
            return false;
    }

    public void FillBox(int x)
    {
        for (int i = 0; i < x; i++)
        {
            FillRow();
        }
        
    }

    public void FillRow()
    {
        float x = 0.5f;
        GameObject game;
        for (int i = 0; i < 4; i++)
        {
            if(i == 0)
            {
                game = (GameObject)Instantiate(ElementFillPrefab, new Vector3(-2.3096f, -0.86f), Quaternion.identity);
                List_Fillprefabs.Add(game);
            }
            game = (GameObject)Instantiate(ElementFillPrefab, new Vector3(-2.3096f + x, -0.86f), Quaternion.identity);
            List_Fillprefabs.Add(game);
            x +=0.5f;
        }
        
        
    }
    
    public bool CheckSubmit()
    {
        float x = float.Parse(cantresult.text);
        if(CheckResultCorrect())
        {
            Debug.Log("yes");
            intentos.Add(intento_nivel);
            Resulttime();
            return true;
        }
        else
        {
            intento_nivel++;
            Debug.Log("no paso /n"+intento_nivel);
            textcant_fallos.text = "Errores: " + intento_nivel.ToString();
            return false;
        }
    }

    //Esto es para llenar la caja de la n cantidad y se vea lo más o menos llena posible
    public void CheckForInput()
    {
        float x = float.Parse(cantresult.text);
        if (CheckResultCorrect())
        {
            Debug.Log("yes");
            FillBox(6);
        }
        else
        {
            if (float.Parse(cantresult.text) > float.Parse(Answer.text))
                FillBox(3);
            if (float.Parse(cantresult.text) < float.Parse(Answer.text))
                FillBox(10);
            Debug.Log("no paso /n" + intento_nivel);
            textcant_fallos.text = "Errores: " + intento_nivel.ToString();
        }
    }

    public bool CheckSkip()
    {
        bool check = CheckType();
        if (intento_nivel == 0)
        {
            intento_nivel++;
            intentos.Add(intento_nivel);
            Debug.Log(intentos.Count);
            return true;
        }
        if (intento_nivel != 0)
        {
            //intentos.Add(intento_nivel);
            return true;
        }

        return false;
    }

    public string GetInput()
    {
        Debug.Log(Answer.text);
        return Answer.text;
    }

    public void CleanSimulation()
    {
        for (int i = 0; i < List_Fillprefabs.Count; i++)
        {
            Destroy(List_Fillprefabs[i].gameObject);
        }

        intento_nivel = 0;
        textcant_fallos.text = "Errores: ";
    }

    public void CleanForInput()
    {
        for (int i = 0; i < List_Fillprefabs.Count; i++)
        {
            Destroy(List_Fillprefabs[i].gameObject);
        }
    }

    public void ValidateSubmit()
    {
        bool check = CheckType();
        if (check != true)
        {
            if (CheckSubmit())
            {
                switch (GetSceneName())
                {
                    case "Estequiometria Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Estequiometria Nivel 2");
                        return;
                    case "Estequiometria Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Estequiometria Nivel 3");
                        return;
                    case "Estequiometria Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Estequiometria Nivel 4");
                        return;
                    case "Estequiometria Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Estequiometria Nivel 5");
                        return;
                    case "Estequiometria Nivel 5":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                }
            }
        }
        else
        {
            if (CheckSubmit())
            {
                switch (GetSceneName())
                {
                    case "Estequiometria Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Estequiometria Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Estequiometria Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Estequiometria Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Estequiometria Nivel 5":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                }
            }
        }
    }

    public void ValidateSkip()
    {
        bool check = CheckType();
        if (check != true)
        {
            ButtonSkip.GetComponentInChildren<Text>().text = "Saltar";

            if (CheckSkip())
            {
                switch (GetSceneName())
                {
                    case "Estequiometria Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Estequiometria Nivel 2");
                        return;
                    case "Estequiometria Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Estequiometria Nivel 3");
                        return;
                    case "Estequiometria Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Estequiometria Nivel 4");
                        return;
                    case "Estequiometria Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Estequiometria Nivel 5");
                        return;
                    case "Estequiometria Nivel 5":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                }
            }
        }
        if (check == true)
        {
            switch (GetSceneName())
            {
                case "Estequiometria Nivel 1":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Estequiometria Nivel 2":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Estequiometria Nivel 3":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Estequiometria Nivel 4":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Estequiometria Nivel 5":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
            }
        }
    }

    public bool CheckType()
    {
        type = Niveles_prefab_script.levels;

        if (type.Equals(true))
        {
            ButtonSkip.GetComponentInChildren<Text>().text = "Volver";
        }

        return type;
    }

    

}
