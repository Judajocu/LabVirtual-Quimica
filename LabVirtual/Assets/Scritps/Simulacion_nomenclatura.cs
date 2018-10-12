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
    TextMesh letra_b;
    TextMesh letra_c;
    TextMesh letra_d;
    TextMesh letra_e;
    TextMesh letra_f;

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

    string word = null;
    int wordindex = 0;
    string alpha;
    public Text palabra = null;

    // Use this for initialization
    void Start()
    {
        //timeup = settings.Gettime();
        //CheckType();
        letra_a = GameObject.Find("letra_a").GetComponent<TextMesh>();
        letra_b = GameObject.Find("letra_b").GetComponent<TextMesh>();
        letra_c = GameObject.Find("letra_c").GetComponent<TextMesh>();
        letra_d = GameObject.Find("letra_d").GetComponent<TextMesh>();
        letra_e = GameObject.Find("letra_e").GetComponent<TextMesh>();
        letra_f = GameObject.Find("letra_f").GetComponent<TextMesh>();
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
        //CheckTime();
    }
    /*
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
        for (int i = 0; i < List_Inputprefabs.Count; i++)
        {
            Destroy(List_Inputprefabs[i].gameObject);
        }

        for (int i = 0; i < List_Outputprefabs.Count; i++)
        {
            Destroy(List_Outputprefabs[i].gameObject);
        }


        cant_fallos = 0;

        //textcant_fallos.text = "Fallos";
        //cantinput.text = "Entrada";
        //cantoutput.text = "Salida";
    }
    */

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }
}
