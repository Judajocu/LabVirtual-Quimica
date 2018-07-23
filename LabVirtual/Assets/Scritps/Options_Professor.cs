using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options_Professor : MonoBehaviour {

    public Button buttonOverview;
    public Button buttonGroups;
    public Button buttonStudents;
    public Button buttonLogout;

    public GameObject overview;
    public GameObject groups;
    public GameObject students;
    public GameObject logout;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        buttonOverview = overview.GetComponent<Button>();
        buttonOverview.onClick.AddListener(ValidateOverview);
        buttonGroups = groups.GetComponent<Button>();
        buttonGroups.onClick.AddListener(ValidateGroups);
        buttonStudents = students.GetComponent<Button>();
        buttonStudents.onClick.AddListener(ValidateStudents);
        buttonLogout = logout.GetComponent<Button>();
        buttonLogout.onClick.AddListener(ValidateLogout);

    }

    private void ValidateOverview()
    {
        SceneManager.LoadScene("Overview-Professor");
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
