using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Simulacion_nomenclatura : MonoBehaviour {

    public Button ButtonMenu;
    public Button ButtonSkip;
    public Button Buttonsubmit;

    public GameObject menu;

    TextMesh letra_a;
    private Vector3 MovingDirection = Vector3.up;

    Scene activeScene;

    List<int> fallos_simulacion;
    static public List<int> intentos = new List<int>();
    static public List<float> tiempos = new List<float>();

    SettingsProffesorScript settings = new SettingsProffesorScript();

    int cant_fallos = 0;
    int intento_nivel = 0;
    float time_left = 0.0f;
    float timeup;
    bool type;

    string word = null;
    int wordindex = 0;
    string alpha;
    public Text palabra = null;
    float top;
    float down;

    public AnimationCurve myCurve;
    private float time = 0.0f;
    public float interpolationPeriod = 0.05f;
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

    public TextMesh intentado = null;
    bool resultado;

    // Use this for initialization
    void Start()
    {

        //CheckTime();
    }

    public void formarpalabra(string letra)
    {
        wordindex++;
        word = word + letra;
        palabra.text = word;
    }

    // Update is called once per frame
    void Update()
    {
        /*time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            MoveElement(A);
        }*/
        float moveLR = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float moveUD = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = new Vector3(mouse.x, mouse.y, transform.position.z);
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
            CleanSimulation();
            SceneManager.LoadScene("Balanceo Resultado");
            return;
        }
    }

    public void Resulttime()
    {
        if (CheckSkip())
        {
            if (intento_nivel == 0)
            {
                tiempos.Add(00.0f);
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

    public string GetSceneName()
    {
        activeScene = SceneManager.GetActiveScene();
        return activeScene.name;
    }

    public bool ResultExpected()
    {
        //recibir el mensaje de forma booleana si es correcya la respuesta o no
        GameObject.FindGameObjectWithTag("meta").GetComponent<watchGlassBehavior>().SendMessage("enviar", gameObject);
        //Este return es momentaneo 
        //la variable resultado dice si en ese momento es real o no
        return resultado;
    }

    public bool CheckSubmit()
    {
        
        if (ResultExpected())
        {
            Debug.Log("Bien");
            intentos.Add(intento_nivel);
            Debug.Log(intentos.Count);
            Resulttime();
            return true;
        }
        else
        {
            cant_fallos++;
            intento_nivel++;
            //Debug.Log(cant_fallos);
            Debug.Log("Total de intentos " + intento_nivel);
            //textcant_fallos.text = "Fallos: " + cant_fallos.ToString();
            intentado.text = intento_nivel.ToString();
            return false;
        }

        return false;
    }

    public void ValidateSubmit()
    {
        //Debug.Log(List_Inputprefabs.Count);
        //Debug.Log(List_Outputprefabs.Count);
        bool check = CheckType();
        if (check != true)
        {
            if (CheckSubmit())
            {
                switch (GetSceneName())
                {
                    case "Nomenclatura nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Nomenclatura nivel 2");
                        return;
                    case "Nomenclatura nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Nomenclatura nivel 3");
                        return;
                    case "Nomenclatura nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Nomenclatura nivel 4");
                        return;
                    case "Nomenclatura nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Nomenclatura nivel 5");
                        return;
                    case "Nomenclatura nivel 5":
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
                    case "Nomenclatura nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Nomenclatura nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Nomenclatura nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Nomenclatura nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Nomenclatura nivel 5":
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
                    case "Nomenclatura nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Nomenclatura nivel 2");
                        return;
                    case "Nomenclatura nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Nomenclatura nivel 3");
                        return;
                    case "Nomenclatura nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Nomenclatura nivel 4");
                        return;
                    case "Nomenclatura nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Nomenclatura nivel 5");
                        return;
                    case "Nomenclatura nivel 5":
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
                case "Nomenclatura nivel 1":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Nomenclatura nivel 2":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Nomenclatura nivel 3":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Nomenclatura nivel 4":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Nomenclatura nivel 5":
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

    public void CleanSimulation()
    {
        //vaciar respuesta
        GameObject.FindGameObjectWithTag("meta").GetComponent<watchGlassBehavior>().SendMessage("BorrarFormula2", gameObject);

        cant_fallos = 0;
        //textcant_fallos.text = "Fallos";
        //cantinput.text = "Entrada";
        //cantoutput.text = "Salida";
    }

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    public void respuesta(bool valor)
    {
        resultado = valor;
    }
}
