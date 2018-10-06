using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TheoryTopicScript : MonoBehaviour {

    #region Variables
    public Button buttonMenu;
    public Button buttonPVA;
    public Button buttonSimulacion;

    public GameObject menu;
    public GameObject pva;
    public GameObject simulacion;

    int selected = Theory_Selection.selected;
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

    public void ValidatePVA()
    {
        
    }

    public void ValidateSimulacion()
    {
        SceneManager.LoadScene("Simulation_Options");
    }


    

}
