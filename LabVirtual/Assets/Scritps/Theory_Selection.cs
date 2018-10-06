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

    //Numeros
    //1 es balanceo
    //2 es tabla
    //3 es conversion
    //4 es nomenclatura
    //5 es estequiometria
    static public int selected;
    #endregion

    // Use this for initialization
    void Start()
    {
        selected = 0;
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
        selected = 1;
        SceneManager.LoadScene("Simulation_Selection_Options");
    }
    public void ValidateTable()
    {
        selected = 2;
        SceneManager.LoadScene("Simulation_Selection_Options");
    }
    public void ValidateConversion()
    {
        selected = 3;
        SceneManager.LoadScene("Simulation_Selection_Options");
    }
    public void ValidateNomenclature()
    {
        selected = 4;
        SceneManager.LoadScene("Simulation_Selection_Options");
    }
    public void ValidateEstequimetria()
    {
        selected = 3;
        SceneManager.LoadScene("Simulation_Selection_Options");
    }

    public void ValidateIonizacion()
    {
        selected = 5;
        SceneManager.LoadScene("Simulation_Selection_Options");
    }


}