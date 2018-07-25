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
    GameObject[] ElementsinputPrefa;
    GameObject[] ElementsoutputPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ButtonMenu = menu.GetComponent<Button>();
        ButtonMenu.onClick.AddListener(ValidateMenu);

        ButtonUpIP = upIP.GetComponent<Button>();
        ButtonUpIP.onClick.AddListener(AddElementIP);

        ButtonDownIP = downIP.GetComponent<Button>();
        ButtonDownIP.onClick.AddListener(DeleteElementIP);

        ButtonUpOP = upOP.GetComponent<Button>();
        ButtonUpOP.onClick.AddListener(AddElementOP);

        ButtonDownOP = downOP.GetComponent<Button>();
        ButtonDownOP.onClick.AddListener(DeleteElementOP);

       // ButtonSkip = skip.GetComponent<Button>();
       // ButtonSkip.onClick.AddListener(ValidateMenu);

        ButtonSubmit = submit.GetComponent<Button>();
        ButtonSubmit.onClick.AddListener(ValidateMenu);
    }

    private void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    private void AddElementIP()
    {
        Instantiate(ElementinputPrefab);
    }

    private void AddElementOP()
    {
        Instantiate(ElementoutputPrefab);
    }

    private void DeleteElementIP()
    {
        Destroy(ElementinputPrefab);
    }

    private void DeleteElementOP()
    {
        Destroy(ElementoutputPrefab);
    }
}
