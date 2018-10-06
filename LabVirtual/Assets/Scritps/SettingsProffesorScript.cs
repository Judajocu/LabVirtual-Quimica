using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsProffesorScript : MonoBehaviour {

    #region Variables
    public Button buttonMenu;
    public Button buttonSubmit;

    public InputField inputTiempo;
    public InputField inputErrores;
    public InputField inputNota;

    public GameObject menu;
    public GameObject submit;
    public GameObject tiempo;
    public GameObject errores;
    public GameObject nota;

    public static string time;
    public static string trys;
    public static string intervalo;
    #endregion

    // Use this for initialization
    void Start () {
        time = inputTiempo.text;
        trys = inputErrores.text;
        intervalo = inputNota.text;
        Debug.Log(time + " " + trys + " " + intervalo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    public void CheckChange()
    {
        time = inputTiempo.text;
        trys = inputErrores.text;
        intervalo = inputNota.text;
        Debug.Log(time + " " + trys + " " + intervalo);
    }

}
