using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using SimpleJSON;
using System.ServiceModel;

public class Simulation_Balance : MonoBehaviour {

    #region Variables
    public Button ButtonMenu;
    public Button ButtonUpIP;
    public Button ButtonDownIP;
    public Button ButtonUpOP;
    public Button ButtonDownOP;
    public Button ButtonSkip;
    public Button ButtonSubmit;

    public GameObject menu;
    public GameObject upIP;
    public GameObject downIP;
    public GameObject upOP;
    public GameObject downOP;
    public GameObject skip;
    public GameObject submit;
    public GameObject ElementinputPrefab;
    public GameObject ElementoutputPrefab;

    TextMesh textcant_fallos;
    TextMesh cantinput;
    TextMesh cantoutput;
    TextMesh cantresult;

    List<GameObject> List_Inputprefabs = new List<GameObject>();
    List<GameObject> List_Outputprefabs = new List<GameObject>();
    List<int> fallos_simulacion;
    List<string> results_expected = new List<string>();
    static public List<int> intentos = new List<int>();
    static public List<float> tiempos = new List<float>();

    SettingsProffesorScript settings = new SettingsProffesorScript();

    int cant_fallos = 0;
    int intento_nivel = 0;
    float time_left = 0.0f;
    float timeup;
    bool type;

    public string level;
    private ServiceLabClient servicioWCF = new ServiceLabClient(new BasicHttpBinding(), new EndpointAddress("http://chemical.centralus.cloudapp.azure.com/servicelab.svc"));

    Scene activeScene;
    #endregion

    // Use this for initialization
    void Start ()
    {
        string[] simulacionesNombre = new string[3] { "problema", "SolIzq", "SolDer" };
        string[] resultados = servicioWCF.BuscarDatosD("Balanceo", level, simulacionesNombre);

        timeup = settings.Gettime();
        CheckType();
        
        textcant_fallos = GameObject.Find("Errores").GetComponent<TextMesh>();
        cantinput = GameObject.Find("CantInput").GetComponent<TextMesh>();
        cantoutput = GameObject.Find("CantOutput").GetComponent<TextMesh>();
        GameObject.Find("Cant_result").GetComponent<TextMesh>().text = resultados[1] + " " + resultados[2];
        GameObject.Find("Ecuation").GetComponent<TextMesh>().text = resultados[0];
        cantresult = GameObject.Find("Cant_result").GetComponent<TextMesh>();
        
        CheckTime();
    }
	
	// Update is called once per frame
	void Update ()
    {
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
        if(CheckSkip())
        {
            if(intento_nivel==0)
            {
                tiempos.Add(00.0f);
            }
            if(intento_nivel!=0)
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
        CleanSimulation();
        SceneManager.LoadScene("Options_Student");
    }

    public void AddElementIP()
    {
        if (List_Inputprefabs.Count > 4)
        {
            GameObject game = (GameObject)Instantiate(ElementinputPrefab,new Vector3(-1.4f, 4.05223f),Quaternion.identity);
            List_Inputprefabs.Add(game);
            cantinput.text = "Entrada: " + List_Inputprefabs.Count.ToString();
        }
        else
        {
            GameObject game = (GameObject)Instantiate(ElementinputPrefab);
            List_Inputprefabs.Add(game);
            cantinput.text = "Entrada: " + List_Inputprefabs.Count.ToString();
        }
        
    }

    public void AddElementOP()
    {

        if (List_Outputprefabs.Count > 4)
        {
            GameObject game = (GameObject)Instantiate(ElementoutputPrefab, new Vector3(1.4f, 4.05223f), Quaternion.identity);
            List_Outputprefabs.Add(game);
            cantoutput.text = "Salida: " + List_Outputprefabs.Count.ToString();
        }
        else
        {
            GameObject game = (GameObject)Instantiate(ElementoutputPrefab);
            List_Outputprefabs.Add(game);
            cantoutput.text = "Salida: " + List_Outputprefabs.Count.ToString();
        }
    }

    public void DeleteElementIP()
    {
        if (List_Inputprefabs.Count == 0)
            return;
        GameObject game = List_Inputprefabs[List_Inputprefabs.Count - 1];
        List_Inputprefabs.RemoveAt(index: List_Inputprefabs.Count -1);
        Destroy(game);
        cantinput.text = "Entrada: " + List_Inputprefabs.Count.ToString();

    }

    public void DeleteElementOP()
    {
        if (List_Outputprefabs.Count == 0)
            return;
        GameObject game = List_Outputprefabs[List_Outputprefabs.Count - 1];
        List_Outputprefabs.RemoveAt(index: List_Outputprefabs.Count - 1);
        Destroy(game);
        cantoutput.text = "Salida: " + List_Outputprefabs.Count.ToString();

    }

    public void CleanSimulation()
    {
        for (int i = 0; i < List_Inputprefabs.Count; i++)
        {
            Destroy(List_Inputprefabs[i].gameObject);
        }

        for (int i = 0; i < List_Outputprefabs.Count; i++)
        {
            Destroy(List_Outputprefabs[i].gameObject);
        }


        cant_fallos = 0;

        textcant_fallos.text = "Errores:";
        cantinput.text = "Entrada";
        cantoutput.text = "Salida";
    }

    public void ResultExpected()
    {
        //Aqui busca el resultado esperado, es el textmesh que esta fuera de la vista de la camara
        results_expected.Clear();
        results_expected = cantresult.text.Split(new char[] {' '}).ToList();
    }

    public bool CheckSubmit()
    {
        ResultExpected();
        //Aqui compara si lo que se espera es igual a lo que se tiene
        //Primero izuiqerdo y luego derecho
        if (List_Inputprefabs.Count == System.Convert.ToInt32(results_expected[0]) && List_Outputprefabs.Count == System.Convert.ToInt32(results_expected[1]))
        {
            Debug.Log("Bien");
            intentos.Add(cant_fallos);
            Debug.Log(intentos.Count);
            Resulttime();
            return true;
        }
        else
        {
            cant_fallos++;
            intento_nivel++;
            //Debug.Log(cant_fallos);
            Debug.Log("Total de intentos " +intento_nivel);
            textcant_fallos.text = "Errores: " + cant_fallos.ToString();
            return false;
        }
    }

    public bool CheckSkip()
    {
        bool check = CheckType();
        if (intento_nivel==0)
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
                    case "Balanceo Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Balanceo Nivel 2");
                        return;
                    case "Balanceo Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Balanceo Nivel 3");
                        return;
                    case "Balanceo Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Balanceo Nivel 4");
                        return;
                    case "Balanceo Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Balanceo Nivel 5");
                        return;
                    case "Balanceo Nivel 5":
                        SaveList();
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                }
            }
        }
        else
        {
            CleanLists();
            if (CheckSubmit())
            {
                switch (GetSceneName())
                {
                    case "Balanceo Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Balanceo Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Balanceo Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Balanceo Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                    case "Balanceo Nivel 5":
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
                    case "Balanceo Nivel 1":
                        CleanSimulation();
                        SceneManager.LoadScene("Balanceo Nivel 2");
                        return;
                    case "Balanceo Nivel 2":
                        CleanSimulation();
                        SceneManager.LoadScene("Balanceo Nivel 3");
                        return;
                    case "Balanceo Nivel 3":
                        CleanSimulation();
                        SceneManager.LoadScene("Balanceo Nivel 4");
                        return;
                    case "Balanceo Nivel 4":
                        CleanSimulation();
                        SceneManager.LoadScene("Balanceo Nivel 5");
                        return;
                    case "Balanceo Nivel 5":
                        CleanSimulation();
                        SceneManager.LoadScene("Resultado");
                        return;
                }
            }
        }
        if(check == true)
        {
            CleanLists();
            switch (GetSceneName())
            {
                case "Balanceo Nivel 1":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Balanceo Nivel 2":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Balanceo Nivel 3":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Balanceo Nivel 4":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
                case "Balanceo Nivel 5":
                    CleanSimulation();
                    SceneManager.LoadScene("Simulation_Selection_Options");
                    return;
            }
        }
    }

    public void SaveList()
    {
        string path = Application.persistentDataPath + "/Nota Balance.json";

        JSONObject resultJSON = new JSONObject();
    }

    public bool CheckType()
    {
        type = Niveles_prefab_script.levels;

        if(type.Equals(true))
        {
            ButtonSkip.GetComponentInChildren<Text>().text = "Volver";
        }

        return type;
    }

    public void CleanLists()
    {
        intentos.Clear();
        tiempos.Clear();
    }
}
