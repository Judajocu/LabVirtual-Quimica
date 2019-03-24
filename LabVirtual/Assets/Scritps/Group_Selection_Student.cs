using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Group_Selection_Student : MonoBehaviour {

    #region Variables
    public Dropdown dropdown;
    public Button Exit;
    public Button Submit;
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValidateSubmit()
    {
        SceneManager.LoadScene("Overview-Student");
    }

    public void ValidateExit()
    {
        SceneManager.LoadScene("Login-Student");
    }
}
