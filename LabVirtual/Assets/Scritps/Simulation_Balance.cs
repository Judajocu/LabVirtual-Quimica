using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

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

    List<GameObject> List_Inputprefabs = new List<GameObject>();
    List<GameObject> List_Outputprefabs = new List<GameObject>();
    List<int> fallos_simulacion;
    List<string> results_expected = new List<string>();

    TextMesh textcant_fallos;
    TextMesh cantinput;
    TextMesh cantoutput;
    TextMesh cantresult;

    Scene activeScene;

    int cant_fallos=0;
    #endregion

    // Use this for initialization
    void Start () {
        textcant_fallos = GameObject.Find("Text_fails").GetComponent<TextMesh>();
        cantinput = GameObject.Find("CantInput").GetComponent<TextMesh>();
        cantoutput = GameObject.Find("CantOutput").GetComponent<TextMesh>();
        cantresult = GameObject.Find("Cant_result").GetComponent<TextMesh>();
        ResultExpected();
    }
	
	// Update is called once per frame
	void Update () {

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

        textcant_fallos.text = "Fallos";
        cantinput.text = "Entrada";
        cantoutput.text = "Salida";
    }

    public void ResultExpected()
    {
        results_expected = cantresult.text.Split(new char[] {' '}).ToList();
    }

    public void ValidateSubmit()
    {
        Debug.Log(List_Inputprefabs.Count);
        Debug.Log(List_Outputprefabs.Count);
        if(List_Inputprefabs.Count == System.Convert.ToInt32(results_expected[0])  && List_Outputprefabs.Count == System.Convert.ToInt32(results_expected[1]))
        {
            Debug.Log("Bien");

            return;
        }
        else
        {
            cant_fallos++;
            Debug.Log(cant_fallos);
            textcant_fallos.text = "Fallos: "+cant_fallos.ToString();
        }
    }
       
    public void ValidateSkip()
    {
        switch(GetSceneName())
        {
            case "Balanceo Nivel 1":
                SceneManager.LoadScene("Balanceo Nivel 2");
                CleanSimulation();
                return;
            case "Balanceo Nivel 2":
                SceneManager.LoadScene("Balanceo Nivel 3");
                CleanSimulation();
                return;
            case "Balanceo Nivel 3":
                SceneManager.LoadScene("Balanceo Nivel 4");
                CleanSimulation();
                return;
            case "Balanceo Nivel 4":
                SceneManager.LoadScene("Balanceo Nivel 5");
                CleanSimulation();
                return;
            case "Balanceo Nivel 5":
                return;
        }
    }
}
