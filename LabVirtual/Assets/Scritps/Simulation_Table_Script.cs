using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Simulation_Table_Script : MonoBehaviour
{

    //Subindices
    //₀₁₂₃₄₅₆₇₈₉

    #region Variables
    public Button ButtonMenu;
    public Button ButtonSkip;
    public Button Buttonsubmit;

    public GameObject menu;
    public GameObject skip;
    public GameObject submit;
   /* public GameObject A11;
    public GameObject A12;
    public GameObject A13;
    public GameObject A21;
    public GameObject A22;
    public GameObject A23;
    public GameObject A31;
    public GameObject A32;
    public GameObject A33;*/

    public Text Q1;
    public Text Q2;
    public Text Q3;

    TextMesh textcant_fallos;

    List<int> fallos_simulacion;
    List<string> results_expected = new List<string>();
    static public List<int> intentos = new List<int>();
    static public List<float> tiempos = new List<float>();

    SettingsProffesorScript settings = new SettingsProffesorScript();

    int intento_nivel = 0;
    float time_left = 0.0f;
    float timeup;
    bool type;

    Scene activeScene;
    #endregion

    // Use this for initialization
    void Start()
    {
        timeup = settings.Gettime();
        CheckType();
       // textcant_fallos = GameObject.Find("Text_fails").GetComponent<TextMesh>();
       // CheckTime();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckTime();
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
            //CleanSimulation();
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
    

   /* public bool CheckSubmit()
    {
        float x = float.Parse(cantresult.text);
        if (CheckResultCorrect())
        {
            Debug.Log("yes");
            intentos.Add(intento_nivel);
            Resulttime();
            return true;
        }
        else
        {
            intento_nivel++;
            Debug.Log("no paso /n" + intento_nivel);
            textcant_fallos.text = "Fallos: " + intento_nivel.ToString();
            return false;
        }
    }*/


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

    

   /* public void CleanSimulation()
    {
        for (int i = 0; i < List_Fillprefabs.Count; i++)
        {
            Destroy(List_Fillprefabs[i].gameObject);
        }

        intento_nivel = 0;
        textcant_fallos.text = "Fallos";
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
    }*/

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
