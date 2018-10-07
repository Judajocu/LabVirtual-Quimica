using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options_Student : MonoBehaviour {

    public Button buttonOverview;
    public Button buttonSimulations;
    public Button buttonTheory;
    public Button buttonLogout;

    public GameObject overview;
    public GameObject simulations;
    public GameObject theory;
    public GameObject logout;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void ValidateOverview()
    {
        SceneManager.LoadScene("Overview-Student");
    }

    public void ValidateSimulations()
    {
       SceneManager.LoadScene("Simulation_Options");
    }

    public void ValidateTheory()
    {
       SceneManager.LoadScene("Theory_Options");
    }

    public void ValidateLogout()
    {
        SceneManager.LoadScene("Entryway");
    }
}
