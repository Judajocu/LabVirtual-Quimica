using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dynamic_Selection_Script : MonoBehaviour {

    #region Variables
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
        SceneManager.LoadScene("Options_Professor");
    }
    public void ValidateBalance()
    {
        SceneManager.LoadScene("Dynamic_Balance");
    }
    public void ValidateTable()
    {
        SceneManager.LoadScene("Dynamic_Table");
    }
    public void ValidateConversion()
    {
        SceneManager.LoadScene("Dynamic_Conversion");
    }
    public void ValidateNomenclature()
    {
        SceneManager.LoadScene("Dynamic_Nomenclatura");
    }
    public void ValidateEstequimetria()
    {
        SceneManager.LoadScene("Dynamic_Estequiometria");
    }
}
