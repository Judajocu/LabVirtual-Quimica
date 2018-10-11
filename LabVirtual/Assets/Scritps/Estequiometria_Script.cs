using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Estequiometria_Script : MonoBehaviour {

    #region Variables
    public Button ButtonMenu;
    public Button ButtonSkip;
    public Button Buttonsubmit;

    public InputField Answer;

    public GameObject menu;
    public GameObject skip;
    public GameObject submit;

    public TextMesh cantresult;
    #endregion

    // Use this for initialization
    void Start () {
        cantresult = GameObject.Find("Cant_result").GetComponent<TextMesh>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValidateSubmit()
    {

    }

    public void ValidateSkip()
    {

    }

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    public void CheckResult(string result)
    {
        result = Answer.text;
        Debug.Log(result);
    }
}
