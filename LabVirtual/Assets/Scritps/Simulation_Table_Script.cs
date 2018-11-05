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
   
    TextMesh textcant_fallos;

    List<int> fallos_simulacion;
    static public List<int> intentos = new List<int>();
    static public List<float> tiempos = new List<float>();

    SettingsProffesorScript settings = new SettingsProffesorScript();

    int intento_nivel = 0;
    float time_left = 0.0f;
    float timeup;
    bool type;
    bool resultado;

    Scene activeScene;

    public AnimationCurve myCurve;
    private float time = 0.0f;
    public float interpolationPeriod = 0.05f;
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;
    #endregion

    // Use this for initialization
    void Start()
    {
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
        GameObject.FindGameObjectWithTag("Element").GetComponent<OnPropertyCollide_SCript>().SendMessage("enviar", gameObject);
        return resultado;
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
                    case "Tabla Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Tabla Nivel 2");
                        return;
                    case "Tabla Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Tabla Nivel 3");
                        return;
                    case "Tabla Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Tabla Nivel 4");
                        return;
                    case "Tabla Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Tabla Nivel 5");
                        return;
                    case "Tabla Nivel 5":
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
                    case "Tabla Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Tabla Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Tabla Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Tabla Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Tabla Nivel 5":
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
                    case "Tabla Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Tabla Nivel 2");
                        return;
                    case "Tabla Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Tabla Nivel 3");
                        return;
                    case "Tabla Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Tabla Nivel 4");
                        return;
                    case "Tabla Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Tabla Nivel 5");
                        return;
                    case "Tabla Nivel 5":
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
                case "Tabla Nivel 1":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Tabla Nivel 2":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Tabla Nivel 3":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Tabla Nivel 4":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Tabla Nivel 5":
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

    public void respuesta(bool valor)
    {
        resultado = valor;
    }
}
