using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToLevels_Scripts : MonoBehaviour {
    
    public GameObject niveles;

    Simulation_Options_Scripts simulation_Options = new Simulation_Options_Scripts();

    public Button Buttonniveles;

    bool type = Niveles_prefab_script.levels;
    int x;
	// Use this for initialization
	void Start () {
        x = simulation_Options.GetSelected();
        Debug.Log(x+"tipo sim");
        if (type == true)
            InstanciateButton();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstanciateButton()
    {
        GameObject game = Instantiate(niveles, new Vector3(-0.09997559f, -1.299957f), Quaternion.identity);
        game.transform.SetParent(GameObject.FindGameObjectWithTag("Panel").transform, false);
    }

    public void Back2Leveles()
    {
        //  simulation_Options.SetSelected(simulation_Options.GetSelected());
        SceneManager.LoadScene("Simulation_Selection_Options");
    }
}
