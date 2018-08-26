using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Simulation_Balance : MonoBehaviour {

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

    int cant_fallos=0;
    TextMesh text;
    TextMesh cantinput;
    TextMesh cantoutput;
    // Use this for initialization
    void Start () {
        text = GameObject.Find("Text_fails").GetComponent<TextMesh>();
        cantinput = GameObject.Find("CantInput").GetComponent<TextMesh>();
        cantoutput = GameObject.Find("CantOutput").GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        /*ButtonMenu = menu.GetComponent<Button>();
        ButtonMenu.onClick.AddListener(ValidateMenu);

       // ButtonUpIP = upIP.GetComponent<Button>();
        //ButtonUpIP.onClick.AddListener(AddElementIP);

        ButtonDownIP = downIP.GetComponent<Button>();
        ButtonDownIP.onClick.AddListener(DeleteElementIP);

        ButtonUpOP = upOP.GetComponent<Button>();
        ButtonUpOP.onClick.AddListener(AddElementOP);

        ButtonDownOP = downOP.GetComponent<Button>();
        ButtonDownOP.onClick.AddListener(DeleteElementOP);

       // ButtonSkip = skip.GetComponent<Button>();
       // ButtonSkip.onClick.AddListener(ValidateMenu);

        ButtonSubmit = submit.GetComponent<Button>();
        ButtonSubmit.onClick.AddListener(ValidateMenu);*/
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

    public void ValidateSubmit()
    {
        Debug.Log(List_Inputprefabs.Count);
        Debug.Log(List_Outputprefabs.Count);
        if(List_Inputprefabs.Count == 10 && List_Outputprefabs.Count == 15)
        {
            Debug.Log("Bien");
            return;
        }
        else
        {
            cant_fallos++;
            Debug.Log(cant_fallos);
            text.text = "Fallos: "+cant_fallos.ToString();
        }
    }
}
