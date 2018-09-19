using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Simulation_Options_Scripts : MonoBehaviour {

    public Button buttonMenu;
    public Button buttonBalance;
    public Button buttonTable;
    public Button buttonConversion;
    public Button buttonNomenclature;
    public Button buttonEstequimetria;

    public GameObject menu;
    public GameObject balance;
    public GameObject table;
    public GameObject conversion;
    public GameObject nomenclature;
    public GameObject estequimetria;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }
    public void ValidateBalance()
    {
        SceneManager.LoadScene("Balanceo Nivel 1");
    }
    public void ValidateTable()
    {
       // SceneManager.LoadScene("Options_Student");
    }
    public void ValidateConversion()
    {
       // SceneManager.LoadScene("Options_Student");
    }
    public void ValidateNomenclature()
    {
        SceneManager.LoadScene("Nomenclature");
    }
    public void ValidateEstequimetria()
    {
       // SceneManager.LoadScene("Options_Student");
    }

}
