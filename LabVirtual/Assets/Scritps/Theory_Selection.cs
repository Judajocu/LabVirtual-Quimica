using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Theory_Selection : MonoBehaviour
{

    #region Variables
    public Button buttonMenu;
    public Button buttonBalance;
    public Button buttonTable;
    public Button buttonConversion;
    public Button buttonNomenclature;
    public Button buttonEstequimetria;
    public Button buttonIonizacion;


    public GameObject menu;
    public GameObject balance;
    public GameObject table;
    public GameObject conversion;
    public GameObject nomenclature;
    public GameObject estequimetria;
    public GameObject ionizacion;
    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }
    public void ValidateBalance()
    {
        //SceneManager.LoadScene("Simulation_Selection_Options");
    }
    public void ValidateTable()
    {
        //SceneManager.LoadScene("Simulation_Selection_Options");
    }
    public void ValidateConversion()
    {
        //SceneManager.LoadScene("Simulation_Selection_Options");
    }
    public void ValidateNomenclature()
    {
        //SceneManager.LoadScene("Simulation_Selection_Options");
    }
    public void ValidateEstequimetria()
    {
        //SceneManager.LoadScene("Simulation_Selection_Options");
    }

    public void ValidateIonizacion()
    {
        //SceneManager.LoadScene("Simulation_Selection_Options");
    }


}