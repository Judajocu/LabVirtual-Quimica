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


        buttonOverview = overview.GetComponent<Button>();
        buttonOverview.onClick.AddListener(ValidateOverview);
        buttonSimulations = simulations.GetComponent<Button>();
        buttonSimulations.onClick.AddListener(ValidateGroups);
        buttonTheory = theory.GetComponent<Button>();
        buttonTheory.onClick.AddListener(ValidateStudents);
        buttonLogout = logout.GetComponent<Button>();
        buttonLogout.onClick.AddListener(ValidateLogout);

    }

    private void ValidateOverview()
    {
        SceneManager.LoadScene("Overview-Student");
    }

    private void ValidateGroups()
    {
       // SceneManager.LoadScene("Groups");
    }

    private void ValidateStudents()
    {
       // SceneManager.LoadScene("Professor-Students");
    }

    private void ValidateLogout()
    {
        SceneManager.LoadScene("Entryway");
    }
}
