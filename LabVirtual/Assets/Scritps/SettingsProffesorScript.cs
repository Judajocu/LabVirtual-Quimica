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

    public string time;
    public string trys;
    public string intervalo;

    public static float times = 60.0f;
    public static float intervalos = 5.0f;
    public static int tries = 5;
    #endregion

    // Use this for initialization
    void Start () {
        time = inputTiempo.text+".0";
        trys = inputErrores.text;
        intervalo = inputNota.text+".0";
        ConvertChange(time,trys,intervalo);
        Debug.Log(time + " " + trys + " " + intervalo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Professor");
    }

    public void ValidateSubmit()
    {
        SceneManager.LoadScene("Options_Professor");
    }

    public void CheckChange()
    {
        time = inputTiempo.text+".0";
        trys = inputErrores.text;
        intervalo = inputNota.text + ".0";
        ConvertChange(time, trys, intervalo);
        Debug.Log(time + " " + trys + " " + intervalo);
    }

    public void ConvertChange(string FI, string SI, string TI)
    {
        times = float.Parse(FI);
        tries = int.Parse(SI);
        intervalos = float.Parse(TI);
        Debug.Log(times + " " + tries + " " + intervalos);
    }

    public float Gettime()
    {
        return times;
    }

    public int Gettrys()
    {
        return tries;
    }

    public float Getintervalo()
    {
        return intervalos;
    }

    public void SetTime(float x)
    {
        times = x;
    }

    public void SetTrys(int x)
    {
        tries = x;
    }

    public void Setintervalos(float x)
    {
        intervalos = x;
    }
}
