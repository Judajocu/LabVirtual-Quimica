using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ServiceModel;

public class Simulation_Convertion_Script : MonoBehaviour {

    #region Variables
    public Button ButtonMenu;
    public Button ButtonSkip;
    public Button Buttonsubmit;

    public GameObject menu;
    public GameObject skip;
    public GameObject submit;

    public TextMesh QF;
    public InputField QR;
    TextMesh textcant_fallos;
    public TextMesh ExpectedF;
    public TextMesh ExpectedA;

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

    public AnimationCurve myCurve;
    private float time = 0.0f;
    public float interpolationPeriod = 0.05f;
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

    public string level;
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));
    #endregion

    // Use this for initialization
    void Start()
    {
        string[] simulacionesNombre = new string[5] { "ProInicio", "ProFinal", "Contexto", "Formula", "Valor" };
        string[] resultados = servicioWCF.BuscarDatosD("Conversion", level, simulacionesNombre);
        string[] ayuda = resultados[2].Split('@');

        GameObject.Find("TextBefore").GetComponent<Text>().text = resultados[0];
        GameObject.Find("TextAfter").GetComponent<Text>().text = resultados[1];
        
        GameObject.Find("Formula1").transform.GetChild(0).GetComponent<Text>().text = ayuda[0];
        GameObject.Find("Formula2").transform.GetChild(0).GetComponent<Text>().text = ayuda[1];
        GameObject.Find("Formula3").transform.GetChild(0).GetComponent<Text>().text = ayuda[2];
        GameObject.Find("Formula4").transform.GetChild(0).GetComponent<Text>().text = ayuda[3];
        GameObject.Find("Formula5").transform.GetChild(0).GetComponent<Text>().text = ayuda[4];
        GameObject.Find("Formula6").transform.GetChild(0).GetComponent<Text>().text = ayuda[5];

        GameObject.Find("ExpectedFormula").GetComponent<TextMesh>().text = resultados[3];
        GameObject.Find("ExpectedAnswer").GetComponent<TextMesh>().text = resultados[4];

        timeup = settings.Gettime();
        CheckType();
        textcant_fallos = GameObject.Find("Errores").GetComponent<TextMesh>();
        CheckTime();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTime();

        float moveLR = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float moveUD = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = new Vector3(mouse.x, mouse.y, transform.position.z);
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

    public bool CheckResultCorrect()
    {
        //Aqui compara si lo esperado es igual a lo que se entro
        //El primer valor es la formula y el segundo es el resultado de la operacion
        GetExpectedResult();
        if (QF.text == results_expected[0] && QR.text == results_expected[1])
        {
            return true;
        }
        else
            return false;
    }

    public void GetExpectedResult()
    {
        //Saca la formula y luego el valor de los text que estan fuera de camara
        results_expected.Add(ExpectedF.text);
        Debug.Log(results_expected[0]);
        results_expected.Add(ExpectedA.text);
        Debug.Log(results_expected[1]);

    }

    public bool CheckSubmit()
    {
        if (CheckResultCorrect())
        {
            Debug.Log("yes");
            Resulttime();
            return true;
        }
        else
        {
            intento_nivel++;
            Debug.Log("no paso /n" + intento_nivel);
            textcant_fallos.text = "Errores: " + intento_nivel.ToString();
            return false;
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
    
    public void CleanSimulation()
    {
        QR.text = "";
        QF.text = "";
        textcant_fallos.text = "Errores";
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
                    case "Conversion Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Conversion Nivel 6");
                        return;
                    case "Conversion Nivel 6":
                        CleanSimulation();
                        SceneManager.LoadScene("Conversion Nivel 7");
                        return;
                    case "Conversion Nivel 7":
                        CleanSimulation();
                        SceneManager.LoadScene("Conversion Nivel 8");
                        return;
                    case "Conversion Nivel 8":
                        CleanSimulation();
                        SceneManager.LoadScene("Conversion Nivel 9");
                        return;
                    case "Conversion Nivel 9":
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
                    case "Conversion Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Conversion Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Conversion Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Conversion Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Conversion Nivel 5":
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
                    case "Conversion Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Conversion Nivel 2");
                        return;
                    case "Conversion Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Conversion Nivel 3");
                        return;
                    case "Conversion Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Conversion Nivel 4");
                        return;
                    case "Conversion Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Conversion Nivel 5");
                        return;
                    case "Conversion Nivel 5":
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
                case "Conversion Nivel 1":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Conversion Nivel 2":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Conversion Nivel 3":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Conversion Nivel 4":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Conversion Nivel 5":
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
