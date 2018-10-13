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
        
    }

    public void ValidateOverview()
    {
        SceneManager.LoadScene("Overview-Professor");
    }

    public void ValidateGroups()
    {
       SceneManager.LoadScene("Groups_Professor");
    }

    public void ValidateSetting()
    {
       SceneManager.LoadScene("Setting_Professor");
    }

    public void ValidateLogout()
    {
        SceneManager.LoadScene("Entryway");
    }
}
