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
    Simulation_Options_Scripts simulation = new Simulation_Options_Scripts();
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
        simulation.SetSelected(1);
        SceneManager.LoadScene("Theory_Balance");
    }
    public void ValidateTable()
    {
        simulation.SetSelected(2);
        SceneManager.LoadScene("Theory_Conversion");
    }
    public void ValidateConversion()
    {
        simulation.SetSelected(3);
        SceneManager.LoadScene("Theory_Estequiometria");
    }
    public void ValidateNomenclature()
    {
        simulation.SetSelected(4);
        SceneManager.LoadScene("Theory_Ionizacion");
    }
    public void ValidateEstequimetria()
    {
        simulation.SetSelected(5);
        SceneManager.LoadScene("Theory_Nomenclatura");
    }

    public void ValidateIonizacion()
    {
        SceneManager.LoadScene("Theory_Tabla");
    }


}