using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TheoryBalanceScript : MonoBehaviour {

    public Button buttonMenu;
    public Button buttonPVA;
    public Button buttonSimulacion;

    public GameObject menu;
    public GameObject pva;
    public GameObject simulacion;

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
