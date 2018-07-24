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
        buttonMenu = menu.GetComponent<Button>();
        buttonMenu.onClick.AddListener(ValidateMenu);

        buttonBalance = balance.GetComponent<Button>();
        buttonBalance.onClick.AddListener(ValidateMenu);

        buttonTable = table.GetComponent<Button>();
        buttonTable.onClick.AddListener(ValidateMenu);

        buttonConversion = conversion.GetComponent<Button>();
        buttonConversion.onClick.AddListener(ValidateMenu);

        buttonNomenclature = nomenclature.GetComponent<Button>();
        buttonNomenclature.onClick.AddListener(ValidateMenu);

        buttonEstequimetria = estequimetria.GetComponent<Button>();
        buttonEstequimetria.onClick.AddListener(ValidateMenu);
    }

    private void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }
    private void ValidateBalance()
    {
        //SceneManager.LoadScene("Options_Student");
    }
    private void ValidateTable()
    {
       // SceneManager.LoadScene("Options_Student");
    }
    private void ValidateConversion()
    {
       // SceneManager.LoadScene("Options_Student");
    }
    private void ValidateNomenclature()
    {
        //SceneManager.LoadScene("Options_Student");
    }
    private void ValidateEstequimetria()
    {
       // SceneManager.LoadScene("Options_Student");
    }

}
