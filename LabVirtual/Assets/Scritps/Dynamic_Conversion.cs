using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dynamic_Conversion : MonoBehaviour {

    #region Varialbes
    public Button buttonSave;
    public InputField SolIzquierda;
    public InputField SolDerecha;
    public InputField ProbInicio;
    public InputField ProbFinal;
    public Dropdown Nivels;
    public TMP_InputField Pro;

    public GameObject ButtonAceptar;

    string sol;
    string probInicio;
    string probFinal;
    string nivels;
    string context;
    #endregion


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ValidateChange()
    {
        SceneManager.LoadScene("Dynamic_Simulations");
    }
    //Esto consigue el texto de la solucion despues que se cambia
    public void GetSol()
    {
        sol = SolIzquierda.text + " " + SolDerecha.text;
    }
    //Esto consigue el texto del problema despues que se cambia
    public void GetProbInicio()
    {
        probInicio = ProbInicio.text;
    }

    public void GetProbFinal()
    {
        probFinal = ProbFinal.text;
    }

    //Esto consigue el texto del dropdown
    public void GetNivel()
    {
        nivels = Nivels.options[Nivels.value].text;
    }
    //Esto consigue lo del contexto
    public void GetContext()
    {
        context = Pro.text;
    }
}
