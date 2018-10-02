﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Simulation_Selection_Options : MonoBehaviour {

    #region Variables
    public Button buttonMenu;
	public Button buttonNiveles;
	public Button buttonEvaluacion;
    Button nivel1;
    Button nivel2;
    Button nivel3;
    Button nivel4;
    Button nivel5;

    public GameObject menu;
	public GameObject niveles;
	public GameObject evaluacion;
	public GameObject placeholder;

    bool levels;
    int selected = Simulation_Options_Scripts.selected;
    #endregion

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {		
	}

	public void ValidateMenu()
    {
        SceneManager.LoadScene("Options_Student");
    }

    public void ValidateNiveles()
    {
        //GetPlaceholder();
        Debug.Log("fuck this placeholderGO");
        Destroy(placeholder);
    }

    public void ValidateEvaluacion()
    {
        levels = Niveles_prefab_script.levels;
        Debug.Log(levels);
        CheckSimulation();
    }

    public void CheckSimulation()
    {
        switch(selected)
        {
            case 1:
                SceneManager.LoadScene("Balanceo Nivel 1");
                return;
            case 2:
                SceneManager.LoadScene("Simulation_Selection_Options");
                return;
            case 3:
                SceneManager.LoadScene("Simulation_Selection_Options");
                return;
            case 4:
                SceneManager.LoadScene("Nomenclatura");
                return;
            case 5:
                SceneManager.LoadScene("Simulation_Selection_Options");
                return;
            default:
                return;
        }
    }

}
