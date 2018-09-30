using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Niveles_prefab_script : MonoBehaviour {

    #region Variables
    public Button buttonquit;
    public Button buttonnivel1;
    public Button buttonnivel2;
    public Button buttonnivel3;
    public Button buttonnivel4;
    public Button buttonnivel5;

    public GameObject niveles;
    public GameObject quit;
    public GameObject nivel1;
    public GameObject nivel2;
    public GameObject nivel3;
    public GameObject nivel4;
    public GameObject nivel5;
    public static GameObject game;
    public GameObject placeholder;

    static int selected = Simulation_Options_Scripts.selected;
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ValidateNiveles()
    {
        Debug.Log("fuck this GO");
        InstantiateNiveles();
    }

    public void Validatenivel1()
    {
        SceneManager.LoadScene("Balanceo Nivel 1");
    }

    public void Validatenivel2()
    {

    }

    public void Validatenivel3()
    {

    }

    public void Validatenivel4()
    {

    }

    public void Validatenivel5()
    {

    }

    public void InstantiateNiveles()
    {
        game = Instantiate(niveles, new Vector3(0f, 0f), Quaternion.identity);
        game.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
    }

    public void ExitNiveles()
    {
        Destroy(game);
        game = Instantiate(placeholder, new Vector3(0f, 0f), Quaternion.identity);
        game.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
    }

    public void CheckSimulation()
    {
        
    }

}
