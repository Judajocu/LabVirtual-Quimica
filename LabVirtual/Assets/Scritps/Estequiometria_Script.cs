using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Estequiometria_Script : MonoBehaviour {

    //Subindices
    //₀₁₂₃₄₅₆₇₈₉

    #region Variables
    public Button ButtonMenu;
    public Button ButtonSkip;
    public Button Buttonsubmit;

    public InputField Answer;

    public GameObject menu;
    public GameObject skip;
    public GameObject submit;
    public GameObject ElementFillPrefab;

    List<GameObject> List_Fillprefabs = new List<GameObject>();

    public TextMesh cantresult;
    public TextMesh ecuation;
    #endregion

    // Use this for initialization
    void Start () {
        cantresult = GameObject.Find("Cant_result").GetComponent<TextMesh>();
        ecuation = GameObject.Find("Ecuation").GetComponent<TextMesh>();
        ecuation.text = "C + O₂ = CO₂";

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

    public bool CheckResultCorrect(string result)
    {
        if (result.Equals(Answer.text))
            return true;
        else
            return false;
    }

    public void FillBox()
    {
        FillRow();
    }

    public void FillRow()
    {
        float x = 0.5f;
        GameObject game;
        for (int i = 0; i < 3; i++)
        {
            if(i == 0)
            {
                game = (GameObject)Instantiate(ElementFillPrefab, new Vector3(-2.759f, -0.86f), Quaternion.identity);
                List_Fillprefabs.Add(game);
            }
            game = (GameObject)Instantiate(ElementFillPrefab, new Vector3(-2.759f+x, -0.86f), Quaternion.identity);
            List_Fillprefabs.Add(game);
            x *= 2;
        }
        
        
    }


}
