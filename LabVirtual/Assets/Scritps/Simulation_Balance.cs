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

    // Use this for initialization
    void Start () {
		
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
        GameObject game = (GameObject)Instantiate(ElementinputPrefab);
        List_Inputprefabs.Add(game);
    }

    public void AddElementOP()
    {
        GameObject game = (GameObject)Instantiate(ElementoutputPrefab);
        List_Outputprefabs.Add(game);
    }

    public void DeleteElementIP()
    {
        if (List_Inputprefabs.Count == 0)
            return;
        GameObject game = List_Inputprefabs[List_Inputprefabs.Count - 1];
        List_Inputprefabs.RemoveAt(index: List_Inputprefabs.Count -1);
        Destroy(game);
        
    }

    public void DeleteElementOP()
    {
        if (List_Outputprefabs.Count == 0)
            return;
        GameObject game = List_Outputprefabs[List_Outputprefabs.Count - 1];
        List_Outputprefabs.RemoveAt(index: List_Outputprefabs.Count - 1);
        Destroy(game);

    }
}
