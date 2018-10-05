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
    #endregion

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

}
