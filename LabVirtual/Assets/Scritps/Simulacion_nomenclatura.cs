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
    float top;
    float down;

    public AnimationCurve myCurve;
    private float time = 0.0f;
    public float interpolationPeriod = 0.05f;
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

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
    

   /* void MoveElementUP(GameObject game)
    {
        game.transform.position += Vector3.up * Time.deltaTime;
    }

    void MoveElementDown(GameObject game)
    {
        game.transform.position += Vector3.down * Time.deltaTime;
    }

    void CheckPosition(GameObject game)
    {
        top = game.transform.position.y + 2.0f;
        down = game.transform.position.y - 2.0f;

        while(true)
        {
            if(top>game.transform.position.y)
            {
                MoveElementUP(game);
            }
            
        }
    }

    */ /*
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
